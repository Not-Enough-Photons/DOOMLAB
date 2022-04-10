using System;
using System.IO;
using UnityEngine;

using System.Collections.Generic;

// Decoding DOOM Picture Files
// https://www.cyotek.com/blog/decoding-doom-picture-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data
{
    internal class DoomPictureReader
    {
        #region Private Fields

        private Color[] _palette;

        #endregion Private Fields

        #region Public Properties

        public Color[] Palette
        {
            get { return _palette; }
            set
            {
                if (value != null && value.Length != 256)
                {
                    throw new ArgumentException("Palette must be comprised of exactly 256 colors.", nameof(value));
                }

                _palette = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public static int GetInt32Le(byte[] buffer, int offset)
        {
            return buffer[offset + 3] << 24 | buffer[offset + 2] << 16 | buffer[offset + 1] << 8 | buffer[offset];
        }

        public Texture2D Read(string fileName)
        {
            using (Stream stream = File.OpenRead(fileName))
            {
                return this.Read(stream);
            }
        }

        public Texture2D Read(Stream stream)
        {
            byte[] buffer;

            buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return this.Read(buffer);
        }

        public Texture2D Read(byte[] data)
        {
            int width;
            int height;
            byte[] pixelData;

            width = WordHelpers.GetInt16Le(data, 0);
            height = WordHelpers.GetInt16Le(data, 2);

            pixelData = new byte[width * height];

            // doom images seem to use index
            // 255 for transparency, so we'll
            // set the image data to transparent
            // by default for the entire image

            for (int i = 0; i < pixelData.Length; i++)
            {
                pixelData[i] = 255;
            }

            // each column is represented by one or
            // more sub columns, called "posts" in the
            // DOOM FAQ. Each post has a starting row,
            // and a height, followed by a seemly unused
            // value, the pixel data and then another
            // unused value

            for (int column = 0; column < width; column++)
            {
                int pointer;

                pointer = WordHelpers.GetInt32Le(data, (column * 4) + 8);

                do
                {
                    int row;
                    int postHeight;

                    row = data[pointer];

                    if (row != 255 && (postHeight = data[++pointer]) != 255)
                    {
                        pointer++; // unused value

                        for (int i = 0; i < postHeight; i++)
                        {
                            if (row + i < height && pointer < data.Length - 1)
                            {
                                pixelData[((row + i) * width) + column] = data[++pointer];
                            }
                        }

                        pointer++; // unused value
                    }
                    else
                    {
                        break;
                    }
                } while (pointer < data.Length - 1 && data[++pointer] != 255);
            }

            return this.CreateTexture2D(width, height, pixelData);
        }

        public Color[] LoadPalette(string fileName)
        {
            Color[] palette;
            byte[] buffer;
            int size;

            buffer = File.ReadAllBytes(fileName);
            size = buffer.Length / 42;
            palette = new Color[size];

            for (int i = 0; i < size; i++)
            {
                int offset;

                offset = i * 3;

                palette[i] = new Color(buffer[offset] / 256f, buffer[offset + 1] / 256f, buffer[offset + 2] / 256f, 255f);
            }

            palette[255] = Color.clear;

            _palette = palette;

            return palette;
        }

        #endregion Public Methods

        #region Private Methods

        private Texture2D CreateTexture2D(int width, int height, byte[] pixelData)
        {
            Texture2D texture;
            int index = 0;

            Color[] pal = _palette;

            texture = new Texture2D(width, height);
            texture.filterMode = FilterMode.Point;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    texture.SetPixel(x, -y - 1, _palette[pixelData[index++]]);
                }
            }

            texture.Apply();

            return texture;
        }

        #endregion Private Methods
    }
}
using System.Collections.Generic;

namespace NEP.DOOMLAB.ZDOOM
{
    public class ZDSndInfo
    {
        public ZDSndInfo(string fileText)
        {
            fields = new List<ZDSndInfoField>();

            reader = new Reader();
            tokenizer = new Tokenizer();
            parser = new Parser();

            List<string> tokens = new List<string>();

            var lines = reader.ReadAllLines(fileText);

            for(int i = 0; i < lines.Length; i++)
            {
                // tokens.Add(tokenizer.Tokenize(lines[i]));
            }

            var sndInfoArray = parser.Parse(tokenizer, tokens.ToArray());
            // fields.Add(sndInfoArray);
        }

        class Reader
        {
            public string[] ReadAllLines(string file)
            {
                return file.Split('\n');
            }
        }

        class Tokenizer
        {
            public string[] Tokenize(string line, char splitChar = ' ')
            {
                if (!char.IsWhiteSpace(splitChar))
                {
                    return line.Split(splitChar);
                }
                else
                {
                    return line.Split();
                }
            }

            public string[] Filter(string[] tokens)
            {
                List<string> cleanedTokens = new List<string>();

                for (int i = 0; i < tokens.Length; i++)
                {
                    string token = tokens[i];

                    // a comment
                    if (token.StartsWith("//"))
                    {
                        break;
                    }

                    cleanedTokens.Add(token);
                }

                return cleanedTokens.ToArray();
            }
        }

        class Parser
        {
            public ZDSndInfoField[] Parse(Tokenizer tokenizer, string[] lines)
            {
                List<ZDSndInfoField> soundData = new List<ZDSndInfoField>();

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] tokens = tokenizer.Tokenize(line);
                    string[] filteredTokens = tokenizer.Filter(tokens);
                    var soundInfo = new ZDSndInfoField();

                    for (int j = 0; j < filteredTokens.Length; j++)
                    {
                        string token = filteredTokens[j];

                        if (token.Contains("/"))
                        {
                            string[] subToken = tokenizer.Tokenize(token, '/');
                            // soundInfo.ClassName = subToken[0];
                            // soundInfo.ClassSound = subToken[1];
                        }
                        else
                        {
                            // soundInfo.TargetSound = token;
                        }

                        soundData.Add(soundInfo);
                    }
                }

                return soundData.ToArray();
            }
        }

        public List<ZDSndInfoField> fields;

        private Reader reader;
        private Tokenizer tokenizer;
        private Parser parser;
    }
}
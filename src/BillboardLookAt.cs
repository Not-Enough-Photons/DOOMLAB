using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NEP.DOOMLAB
{
    public class BillboardLookAt : MonoBehaviour
    {
        private Camera camera;

        private void Update()
        {
            camera = Camera.main;
            Vector3 cameraPosition = camera.transform.position;
            Quaternion rotation = Quaternion.LookRotation(cameraPosition - transform.position, Vector3.up);
            Vector3 targetRotationEuler = new Vector3(transform.eulerAngles.x, rotation.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(targetRotationEuler);
        }
    }

}

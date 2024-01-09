using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{


    public GameObject FirstCamera, ThirdCamera;
    public int CameraMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera")) { 
            if (CameraMode == 1) {
                CameraMode = 0;
            } else
            {
                CameraMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CameraMode == 0) {
            ThirdCamera.SetActive(true);
            FirstCamera.SetActive(false);
        }
        if (CameraMode == 1)
        {
            FirstCamera.SetActive(true);
            ThirdCamera.SetActive(false);
        }
    }
}

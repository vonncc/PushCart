using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject[] cameras;
    int cameraTarget;
    public void OnClick()
    {
        cameras[cameraTarget].SetActive(false);
        cameraTarget += 1;
        if (cameraTarget >= cameras.Length)
        {
            cameraTarget = 0;
        }
        cameras[cameraTarget].SetActive(true);
       
    }
}

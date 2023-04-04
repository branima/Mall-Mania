using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMannequinCustomization : MonoBehaviour
{
    public GameObject mannequinCustomizationCanvas;
    void OnCollisionEnter()
    {
        mannequinCustomizationCanvas.SetActive(true);
        CameraSwitch.Instance.ChangeCamera();
    }
}

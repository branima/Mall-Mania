using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOrganizing : MonoBehaviour
{
    public GameObject organizationCanvas;
    void OnCollisionEnter()
    {
        organizationCanvas.SetActive(true);
        CameraSwitch.Instance.ChangeCamera();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepentendGameObjectEnable : MonoBehaviour
{
    public GameObject waitingOnObject;
    public GameObject willBeEnabled;

    void Update()
    {
        if (waitingOnObject.activeSelf)
        {
            willBeEnabled.SetActive(true);
            this.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependentEnable : MonoBehaviour
{

    public GameObject waitingOnObject;
    public BoxCollider willBeEnabled;

    void Update()
    {
        if (waitingOnObject.activeSelf)
        {
            willBeEnabled.enabled = true;
            this.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningTransition : MonoBehaviour
{

    public List<GameObject> objectsToBeEnabled;

    void Start() => Invoke("Begin", 0.5f);

    void Begin()
    {
        CameraSwitch.Instance.ChangeCamera();
        Invoke("EnableObjects", 0.5f);
    }

    void EnableObjects()
    {
        foreach (GameObject item in objectsToBeEnabled)
            item.SetActive(true);
    }
}

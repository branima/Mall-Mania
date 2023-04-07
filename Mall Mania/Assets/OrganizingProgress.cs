using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizingProgress : MonoBehaviour
{

    public Transform positions;

    bool done;

    public string stepChangeMethodName;

    void Update()
    {

        done = true;
        foreach (Transform position in positions)
        {
            if (position.childCount == 0)
            {
                done = false;
                break;
            }
        }

        if (done)
        {
            OrganizingLogic.Instance.CallMethodByName(stepChangeMethodName);
            this.enabled = false;
        }
    }

}

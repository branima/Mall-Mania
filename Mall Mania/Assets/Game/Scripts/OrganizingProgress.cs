using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizingProgress : MonoBehaviour
{

    public Transform positions;
    public Transform indicatorPositions;

    bool done;

    public string stepChangeMethodName;

    void Update()
    {

        done = true;
        foreach (Transform position in positions)
        {
            if (position.childCount == 0)
                done = false;
            else if (indicatorPositions != null)
                indicatorPositions.GetChild(position.GetSiblingIndex()).gameObject.SetActive(false);
        }

        if (done)
        {
            OrganizingLogic.Instance.ResetActivePrefab();
            OrganizingLogic.Instance.CallMethodByName(stepChangeMethodName);
            this.enabled = false;
        }
    }

}

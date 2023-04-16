using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public void ChangeRingBoxMat(Material newMat) => GetComponentInChildren<Renderer>().sharedMaterial = newMat;
}

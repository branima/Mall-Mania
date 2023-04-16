using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRotation : MonoBehaviour
{
    public float speed;
    void Update() => transform.Rotate(0f, 90 * speed * Time.deltaTime, 0f);
}

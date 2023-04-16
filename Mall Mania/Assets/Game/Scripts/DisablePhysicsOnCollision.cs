using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePhysicsOnCollision : MonoBehaviour
{

    public Collider objectCollider;
    public Rigidbody rb;

    void OnCollisionEnter()
    {
        Destroy(rb);
        objectCollider.enabled = false;
    }
}

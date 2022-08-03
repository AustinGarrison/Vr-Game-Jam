using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    Vector3 force = Vector3.zero;

    private Rigidbody rb;
    public GameObject ship;
    public GameObject shipNose;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Accelerate()
    {
        force.x = shipNose.transform.forward.x * 2f;
        force.z = shipNose.transform.forward.z * 2f;

        rb.AddForce(force, ForceMode.Force);
    }

    public void Decelerate()
    {
        force.x = 0f;
        force.z = 0f;

        rb.AddForce(force, ForceMode.Force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForward : MonoBehaviour
{
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.white);
    }
}

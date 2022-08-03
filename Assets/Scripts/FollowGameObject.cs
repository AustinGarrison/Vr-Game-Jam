using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public GameObject objectFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = objectFollow.transform.position;
        transform.rotation = objectFollow.transform.rotation;
    }
}

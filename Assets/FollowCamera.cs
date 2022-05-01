using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // This thing's position should be the same as the car's position
    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}

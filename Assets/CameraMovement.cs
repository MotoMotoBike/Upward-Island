using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, target.position.y, transform.position.z);
        }
    }
}

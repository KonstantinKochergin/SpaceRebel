using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{

    private float speed = 8f * Time.deltaTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
    }

}

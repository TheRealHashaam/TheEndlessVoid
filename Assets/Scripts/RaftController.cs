using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public Transform Model;
    void Update()
    {
        // Move forward based on input
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        // Turn based on input
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
            //Model.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
            //Model.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
    }
}

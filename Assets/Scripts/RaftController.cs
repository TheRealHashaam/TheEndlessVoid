using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftController : MonoBehaviour
{
    public Vector3 COM;
    public float speed= 1.0f;
    public float Steerspeed = 1.0f;
    public float moveThreshold = 10f;
    Rigidbody _rigidbody;
    public Transform m_COM;
    float _movementFactor;
    float _steerAmount;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Balance();
        Movement();
        Steer();
    }
    void Balance()
    {
        _rigidbody.centerOfMass = m_COM.position;
    }
    void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _movementFactor = Mathf.Lerp(_movementFactor, verticalInput, Time.deltaTime/ moveThreshold);
        transform.Translate(0, 0,_movementFactor * speed);
    }
    void Steer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _steerAmount = Mathf.Lerp(_steerAmount, horizontalInput, Time.deltaTime / moveThreshold);
        transform.Rotate(0, _steerAmount * Steerspeed, 0);
    }

    void RotateOnAxis()
    {

    }
}

using StylizedWater2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftController : MonoBehaviour, IInteractable
{
    public Vector3 COM;
    public float speed= 1.0f;
    public float Steerspeed = 1.0f;
    public float moveThreshold = 10f;
    Rigidbody _rigidbody;
    public Transform m_COM;
    float _movementFactor;
    float _steerAmount;
    public GameManager gameManager;
    public AlignToWaves alignToWaves;
    public bool CanGetoff;
    public Transform RaftOffset;
    public bool isPlayeron = false;
    float maxSpeed = 10.0f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Balance();
        Movement();
        Steer();
        if(isPlayeron)
        {
            if(CanGetoff)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    GetOff();
                }
            }
        }

    }
    void Balance()
    {
        _rigidbody.centerOfMass = m_COM.position;
    }
    void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _movementFactor = Mathf.Lerp(_movementFactor, verticalInput, Time.deltaTime/ moveThreshold);
        float clampedSpeed = Mathf.Clamp(_movementFactor, 0, maxSpeed);
        transform.Translate(0, 0, clampedSpeed * speed);
    }
    void Steer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _steerAmount = Mathf.Lerp(_steerAmount, horizontalInput, Time.deltaTime / moveThreshold);
        transform.Rotate(0, _steerAmount * Steerspeed, 0);
    }
    public void Interact()
    {
        GetOn();
    }

    void GetOn()
    {
        gameManager.EnableRaft();
        isPlayeron = true;
        _rigidbody.isKinematic = false;
    }

    void GetOff()
    {
        gameManager.DisableRaft();
        isPlayeron = false;
        _rigidbody.isKinematic = true;
    }

}

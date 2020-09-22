using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    public float mass = -0.9f;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, mass, 0f);
    }

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider FrontLeftCollider;
    [SerializeField] private WheelCollider FrontRightCollider;
    [SerializeField] private WheelCollider RearLeftCollider;
    [SerializeField] private WheelCollider RearRightCollider;

    [SerializeField] private Transform FrontLeftTransform;
    [SerializeField] private Transform FrontRightTransform;
    [SerializeField] private Transform RearLeftTransform;
    [SerializeField] private Transform RearRightTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        FrontLeftCollider.motorTorque = verticalInput * motorForce;
        FrontRightCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        if(isBreaking)
        {
            ApplyBreaking();
        }
        else
        {
        FrontRightCollider.brakeTorque = 0;
        FrontLeftCollider.brakeTorque = 0;
        RearLeftCollider.brakeTorque = 0;
        RearRightCollider.brakeTorque = 0;
        }
    }

    private void ApplyBreaking()
    {
        FrontRightCollider.brakeTorque = currentbreakForce;
        FrontLeftCollider.brakeTorque = currentbreakForce;
        RearLeftCollider.brakeTorque = currentbreakForce;
        RearRightCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        FrontLeftCollider.steerAngle = currentSteerAngle;
        FrontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftCollider, FrontLeftTransform);
        UpdateSingleWheel(FrontRightCollider, FrontRightTransform);
        UpdateSingleWheel(RearLeftCollider, RearLeftTransform);
        UpdateSingleWheel(RearRightCollider, RearRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}

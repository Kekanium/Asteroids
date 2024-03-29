﻿using System;
using UnityEngine;


/// <summary>
/// Ship driving
/// </summary>
public class Ship : MonoBehaviour
{
    //thrust and rotation support
    private Rigidbody2D _rigidbody2D;
    [Range(0, 10)] public float thrustForce = 5f;
    [Range(0, 10)] public float slowingForce = 1f;
    [Range(0, 180)] public float degreesPerSecond = 180f;
    private Vector2 _thrustDirection = new Vector2(1f, 0f);

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //moving
        if (Input.GetAxis(axisName: "Thrust") > 0)
        {
            Vector2 force = _thrustDirection * (thrustForce * Input.GetAxis(axisName: "Thrust"));
            if (_rigidbody2D.velocity.magnitude < 15 || Vector2.Dot(force.normalized, _rigidbody2D.velocity.normalized)<0)
            {
                _rigidbody2D.AddForce(force: thrustForce * _thrustDirection, mode: ForceMode2D.Force);
            }
        }
        else if (_rigidbody2D.velocity.magnitude > 0)
        {
            _rigidbody2D.AddForce(force: -slowingForce * _rigidbody2D.velocity, ForceMode2D.Force);
        }
    }

    private void Update()
    {
        float rotationInput = Input.GetAxis("Spin");
        if (Mathf.Abs(rotationInput) > Single.Epsilon)
        {
            float rotationAmount = degreesPerSecond * Time.fixedDeltaTime * rotationInput;
            Transform transform1;
            (transform1 = transform).Rotate(Vector3.forward, rotationAmount);

            //Change direction vector
            float zRotation = transform1.eulerAngles.z * Mathf.Deg2Rad;
            _thrustDirection.x = Mathf.Cos(zRotation);
            _thrustDirection.y = Mathf.Sin(zRotation);
        }

        if (Math.Abs(_rigidbody2D.angularVelocity) > Single.Epsilon)
            _rigidbody2D.angularVelocity = 0;
    }
    
}
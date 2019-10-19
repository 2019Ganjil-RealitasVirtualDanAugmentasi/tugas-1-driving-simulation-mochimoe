using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnRate = 5f;
    [SerializeField] float brakeRate = 10f;
    int gear = 0;
    Rigidbody rb = null;
    float gas = 0f;
    float steer = 0f;

    int turnDir = 0;
    Vector3 vel = new Vector3();
    WheelCollider fLeft, fRight, rLeft, rRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fLeft = transform.GetChild(0).GetComponent<WheelCollider>();
        fRight = transform.GetChild(1).GetComponent<WheelCollider>();
        rLeft = transform.GetChild(2).GetComponent<WheelCollider>();
        rRight = transform.GetChild(3).GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        gas = Input.GetAxis("Gaz");
        steer = Input.GetAxis("Steer");

        rLeft.motorTorque = gas * moveSpeed * gear;
        rRight.motorTorque = gas * moveSpeed * gear;

        fLeft.steerAngle = steer * turnRate;
        fRight.steerAngle = steer * turnRate;

        if(gas == 0)
        {
            Debug.Log("brake");
            rLeft.brakeTorque = brakeRate;
            rRight.brakeTorque = brakeRate;
        }
        else
        {
            rLeft.brakeTorque = 0;
            rRight.brakeTorque = 0;
        }

        //if (gas >= 0.1f)
        //{
        //    vel = transform.forward * moveSpeed * gear * gas;
        //    //vel.y = rb.velocity.y;
        //    //rb.velocity = vel;
        //    rb.AddForce(vel, ForceMode.Acceleration);
        //}
        //else
        //{
        //    vel *= 0;
        //    //vel.y = rb.velocity.y;
        //    //rb.velocity = vel;
        //    rb.AddForce(vel, ForceMode.Acceleration);
        //}

        //if(rb.velocity != Vector3.zero)
        //    Turn();

        if(Input.GetButtonDown("Shift Up"))
        {
            ShiftUp();
        }
        else if(Input.GetButtonDown("Shift Down"))
        {
            ShiftDown();
        }
    }

    public void ShiftUp()
    {
        gear += 1;
        if(gear > 0)
        {
            turnDir = 1;
        }
    }

    public void ShiftDown()
    {
        gear -= 1;
        if(gear < 0)
        {
            turnDir = -1;
        }
    }

    public void Turn()
    {
        transform.Rotate(Vector3.up, turnRate * steer * gas * turnDir * Time.deltaTime);
        rb.AddRelativeForce(-Vector3.right * rb.velocity.magnitude * steer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))] 

public class playermotor : MonoBehaviour {
    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    Vector3 rotation = Vector3.zero;
    [SerializeField]
    private Camera cam;
    Vector3 cameraRotation = Vector3.zero;
    Vector3 thrusterForce = Vector3.zero;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
    public void move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;

    }
    public void RotateCamera(Vector3 _camerarRotation)
    {
        cameraRotation = _camerarRotation;
    }
    public void applyThrusterForce(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;


    }

    // Update is called once per frame
    void Update () {
		
	}
    private void FixedUpdate()
    {
        performMovement(); //perform movement based on velocity variable
        performRotation();

    }
    private void performMovement()
    {
        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);

        }
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
            
        }
    }
    private void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
   
}

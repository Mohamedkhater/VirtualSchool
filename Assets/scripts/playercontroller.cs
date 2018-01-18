using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playermotor))]

public class playercontroller : MonoBehaviour {
    playermotor motor;
    [SerializeField]
    private float speed;
    [SerializeField]
    float looksesitivity = 3f;
    [SerializeField] private float thrusterForce;

	// Use this for initialization
	void Start () {
     motor = GetComponent<playermotor>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");
        Vector3 _moveHorizontal = transform.right* _xMov;
        Vector3 _moveVertical = transform.forward* _zMov;
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
        motor.move(_velocity);
        //calculate rotation as a 3d vector
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f,_yRot,0f)* looksesitivity;
        motor.rotate(_rotation);



        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * looksesitivity;
        motor.rotate(_rotation);
        //apply rotation
        motor.RotateCamera(_cameraRotation);
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
        }
        motor.applyThrusterForce(_thrusterForce);
    }
}

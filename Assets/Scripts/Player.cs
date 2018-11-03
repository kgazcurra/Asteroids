using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

	public float impulseSpeed = 3f;
	public float rotateAngle = 100f;

	private Rigidbody _rb;
	
	// Use this for initialization
	void Start (){
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") == 1){
			Impulse();
		}
		
		Rotate(Input.GetAxisRaw("Horizontal"));
	}

	private void Impulse(){
		_rb.velocity += transform.forward * impulseSpeed * Time.deltaTime;
	}

	private void Rotate(float rotateDirection){
		var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle * Time.deltaTime, Vector3.up);
		transform.forward = rotation * transform.forward;
	}
}

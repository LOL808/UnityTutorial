using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {

	private Animator _animator;
	public float speed  = 10f;

	private Rigidbody _rigidBody;
	// Use this for initialization

	void Start () {
		print ("Start");
		_animator = GetComponent<Animator> ();
		_rigidBody = GetComponent<Rigidbody> ();
		Debug.Assert (_rigidBody, "RIGIDBODY IS NULL");
		Debug.Assert (_animator, "ANIMATOR IS NULL");
		_animator.SetInteger ("LocomotionType",1);
	}
	
	// Update is called once per frame
	void Update () {
		float XInput = Input.GetAxis ("Horizontal");
		float YInput = Input.GetAxis ("Vertical");



//		if (Input.GetAxis("Horizontal")!=0f) {
//			print (Input.GetAxisRaw ("Horizontal"));
//		}
//		_rigidBody.MovePosition (transform.position + transform.forward);
//		if (XInput != 0f) {
//			
//		}
//
		_animator.SetFloat ("PX",XInput);
		_animator.SetFloat ("PY",YInput);



//		print (transform.forward);
	}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {

	public enum WeaponStyle{
		PISTOL,
		RIFEL
	}
	public WeaponStyle weaponStyle;
	private Animator _animator;
	private Rigidbody _rigidBody;
	// Use this for initialization

	void Start () {
		print ("Start");
		_animator = GetComponent<Animator> ();

		Debug.Assert (_animator, "ANIMATOR IS NULL");
//		_animator.SetInteger ("LocomotionType",1);
		switch(weaponStyle){
		case WeaponStyle.PISTOL:
			_animator.SetInteger ("LocomotionType", 0);
			break;
		case WeaponStyle.RIFEL:
			_animator.SetInteger ("LocomotionType", 1);
			break;

		}

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

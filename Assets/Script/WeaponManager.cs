using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
////	[SerializeField]
//	public ArrayList[] weapons;

	private Animator _animator;
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_animator.SetInteger ("LocomotionType",1);
			_animator.SetFloat ("WeaponStyle",1.0f);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_animator.SetFloat ("WeaponStyle",0.0f);
			_animator.SetInteger ("LocomotionType",0);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			print ("F");
			_animator.SetTrigger("DrawGun");
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			print ("R");
			_animator.SetTrigger ("Reload");
			_animator.SetFloat ("WeaponStyle", 1f);
		}
	}

	void IsHandOnGun(){
		print ("IsHandOnGun");
	}

	void NewClipInLeftHand(){
		print ("NewClipInLeftHand");
	}

	void NewClipOffLeftHand(){
		print ("NewClipOffLeftHand");
	}

	void ReloadDone() {
		print ("Reloaded");
	}
}

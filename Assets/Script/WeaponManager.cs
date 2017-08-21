using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
////	[SerializeField]
//	public ArrayList[] weapons;
	private enum WeaponType{
		PISTOL,
		RIFEL
	}
	private WeaponType _weaponType = WeaponType.PISTOL;
	private Animator _animator;
	private int 	 _locomotionType=0;
	private float    _weaponStyle = 0f;
	private bool 	 _isGunOnHand = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_weaponType = WeaponType.RIFEL;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_weaponType = WeaponType.PISTOL;
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			// print ("F");
			if (_isGunOnHand==false)
				_animator.SetTrigger("DrawGun");
			else 
				_animator.SetTrigger("Holster");
		}

		// if (Input.GetKeyDown (KeyCode.R)) {
		// 	print ("R");
		// 	_animator.SetTrigger ("Reload");
		// 	_animator.SetFloat ("WeaponStyle", 1f);
		// }
	}

	void IsHandOnGun(){
		// print ("IsHandOnGun");
		_isGunOnHand = true;
		switch(_weaponType) {
			case WeaponType.PISTOL:			
				_animator.SetFloat ("WeaponStyle",0.0f);
				_animator.SetInteger ("LocomotionType",0);
			break;
			case WeaponType.RIFEL:
				_animator.SetInteger ("LocomotionType",1);
				_animator.SetFloat ("WeaponStyle",1.0f);
			break;
		}
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

	void IsHandAwayFromGun(){
		_isGunOnHand = false;
		_animator.SetFloat ("WeaponStyle",0.0f);
		_animator.SetInteger ("LocomotionType",0);
	}
}

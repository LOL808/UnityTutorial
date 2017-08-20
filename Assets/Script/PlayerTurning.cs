using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurning : MonoBehaviour {

	private int _floorMask;
	private int _rayLen = 1000;
	private Rigidbody _rigidBody;
	// Use this for initialization
	void Start () {
		_floorMask = LayerMask.GetMask ("Floor");
		_rigidBody = GetComponent<Rigidbody> ();
		Debug.Assert (_rigidBody, "RIGIDBODY IS NULL");
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo = new RaycastHit ();
		if (Physics.Raycast (ray, out hitInfo, _rayLen, _floorMask)) {
			Vector3 direction = hitInfo.point - transform.position;
			direction.y = 0f;
			direction.Normalize ();
			Quaternion rot = Quaternion.LookRotation (direction);
//			tag.MoveRotation (rot);
			transform.rotation = rot;
		}
	}
}

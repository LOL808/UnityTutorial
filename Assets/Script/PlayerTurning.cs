using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurning : MonoBehaviour {

	private int _floorMask;
	private int _rayLen = 1000;
	void Start () {
		_floorMask = LayerMask.GetMask ("Floor");
		//_rig = transform.Find ("Alpha_Surface");
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
			transform.rotation = rot;
		}
	}
}

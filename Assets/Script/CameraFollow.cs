using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float speed = 5f;
	Vector3 offset;

	// Use this for initialization
//	void Start () {
		
//	}
	void Awake()
	{
		offset = target.position - transform.position;
	}
		
	// Update is called once per frame
	void Update () {
		Vector3 newPostion = target.position - offset;
		transform.position = Vector3.Lerp (transform.position, newPostion, speed * Time.deltaTime);
	}
}

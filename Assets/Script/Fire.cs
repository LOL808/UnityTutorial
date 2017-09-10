using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {


	private float fireRate = .3f;
	private float lastTime;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		lastTime = 0f;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//lastTime += Time.deltaTime;
		if (Input.GetMouseButton (0)) {
			if (Time.time - lastTime > fireRate) {
				print ("Fire");
				audioSource.Play ();
				lastTime = Time.time;
			}
		}
	}
}

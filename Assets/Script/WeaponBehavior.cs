using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WeaponAttr))]
public class WeaponBehavior : MonoBehaviour {
	// AudioSource _audioSource;
	// Use this for initialization
	private float lastFireTime = 0f;
	private WeaponAttr attr;

	void Start () {
		//_audioSource = GetComponent<AudioSource> ();
		attr = GetComponent<WeaponAttr>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (Time.time - lastFireTime > attr.firingRate) {
				DoFire ();
				lastFireTime = Time.time;
			}
		}			
	
	}
		
	private void soundEffect() {

	}

	public void DoFire() {
		print ("Fire");
	}

	public void DoReload() {
	
	}
}

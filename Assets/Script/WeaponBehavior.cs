using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WeaponAttr))]
public class WeaponBehavior : MonoBehaviour {
	AudioSource _audioSource;
	private int count = 0;
	private float lastFireTime = 0f;
	private WeaponAttr attr;

	private bool shouldPlayDry = true;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
		attr = GetComponent<WeaponAttr>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (Time.time - lastFireTime > attr.firingRate) {
				DoFire ();
			}
		}			
		if (Input.GetMouseButtonUp (0)) {
			shouldPlayDry = true;
		}

	}

	public void pullTrigger() {
		if (Time.time - lastFireTime > attr.firingRate) {
			DoFire ();
		}		
	}

	public void reload() {
		DoReload ();	
	}


	private void soundEffect(bool haveBullet) {
		if (haveBullet) {
			AudioClip clip = (AudioClip)Resources.Load ("m4Fire01");
			_audioSource.PlayOneShot (clip);
		}
		else {
			if (shouldPlayDry) {
				AudioClip clip = (AudioClip)Resources.Load ("Dry");
				_audioSource.PlayOneShot (clip);
				shouldPlayDry = false;
			}
		}
	}

	public void DoFire() {
		if (attr.BulletsInMag > 0) {
			count = count + 1;
			print (count);
			attr.BulletsInMag--;
			soundEffect (true);
			lastFireTime = Time.time;
		}
		else {
			soundEffect (false);
		}
	}

	private void DoReload() {
		attr.BulletsInMag = attr.MagazineSize;
	}
}

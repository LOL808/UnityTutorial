using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponAttr : MonoBehaviour {

	public int MagazineSize;
	public int BulletsInMag;
	public float range;
	public float dmg;
	public float reloadTime;
	public string ammoName;
	public float firingRate;
}

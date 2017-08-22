using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour {
	public GameObject item;
	public List<GameObject> items;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
//	void Update () {
//		item.transform.R
//	}
	void FixedUpdate() {
		item.transform.Rotate (0, 2, 0);
	}
}

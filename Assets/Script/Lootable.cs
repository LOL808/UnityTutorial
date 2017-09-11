using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour {
	public GameObject item;
//	public List<GameObject> items;
	private int _playerLayerMask;
	// Use this for initialization
	void Start () {
		_playerLayerMask = LayerMask.GetMask ("Player");
	}

	void OnTriggerEnter(Collider other) {
//		print (other.gameObject.layer);
//		print (_playerLayerMask);
		print (other.gameObject.tag);
	
		if (other.gameObject.tag == "Player") {
//			GameObject leftHand = GameObject.Find ("mixamorig:LeftHand");
//			GameObject leftHand = other.gameObject.transform.Find ("mixamorig:LeftHand").gameObject;	
		//	Transform holdPos = GameObject.Find("handHoldPos").gameObject.transform;
//			item.transform.parent = leftHand.transform;
//			item.transform = holdPos;
		//	item.transform.position = holdPos.position;
		//	item.transform.rotation = holdPos.rotation;
			Destroy (gameObject);
		}

	}
	// Update is called once per frame
//	void Update () {
//		item.transform.R
//	}
	void FixedUpdate() {
		item.transform.Rotate (0, 2, 0);
	}
}

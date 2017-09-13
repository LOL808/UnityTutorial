using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestIK : MonoBehaviour {

	protected Animator animator;
	public bool ikActived = false;

	public Transform Holdpos = null;
	public Transform RightHand = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}


	void OnAnimatorIK() {
		if (animator) {
			if (ikActived) {
				animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1f);
				animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1f);
				animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1f);
				animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1f);		
				if (Holdpos) {
					animator.SetIKPosition (AvatarIKGoal.LeftHand, Holdpos.position);
					animator.SetIKRotation (AvatarIKGoal.LeftHand, Holdpos.rotation);
				}
				if (RightHand) {
					animator.SetIKPosition (AvatarIKGoal.RightHand, RightHand.position);
					animator.SetIKRotation (AvatarIKGoal.RightHand, RightHand.rotation);					
				}
			}
			else {
				animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 0f);
				animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 0f);
				animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 0f);
				animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 0f);
			}
		}

	} 
}

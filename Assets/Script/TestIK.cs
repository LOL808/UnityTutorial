using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestIK : MonoBehaviour {

	protected Animator animator;
	public bool ikActived = false;

	public Transform Holdpos = null;
	public Transform RightArm = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}


	void OnAnimatorIK() {
		if (animator) {
			if (ikActived) {
				animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 0.5f);
				animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 0.5f);
				animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 0.5f);
				animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 0.5f);		
				if (Holdpos) {
					animator.SetIKPosition (AvatarIKGoal.LeftHand, Holdpos.position);
					animator.SetIKRotation (AvatarIKGoal.LeftHand, Holdpos.rotation);
				}
				if (RightArm) {
					animator.SetIKPosition (AvatarIKGoal.RightHand, RightArm.position);
					animator.SetIKRotation (AvatarIKGoal.RightHand, RightArm.rotation);					
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

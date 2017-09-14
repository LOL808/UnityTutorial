using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestIK : MonoBehaviour {

	protected Animator animator;
	public bool ikActived = false;

	public Transform LeftHandPos = null;
	public Transform LeftHandRot = null;
	public Transform RightHandPos = null;
	public Transform RightHandRot = null;

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
				if (LeftHandPos) {
					animator.SetIKPosition (AvatarIKGoal.LeftHand, LeftHandPos.position);
					animator.SetIKRotation (AvatarIKGoal.LeftHand, LeftHandRot.localRotation);
				}
				if (RightHandPos) {
					animator.SetIKPosition (AvatarIKGoal.RightHand, RightHandPos.position);
					animator.SetIKRotation (AvatarIKGoal.RightHand, RightHandRot.localRotation);					
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

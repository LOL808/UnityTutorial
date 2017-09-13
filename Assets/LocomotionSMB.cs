using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionSMB : StateMachineBehaviour {

	private static readonly int state_pistol = Animator.StringToHash("Locomotion.locomotion");
	private static readonly int ht_rifle = Animator.StringToHash("rifle");
	private static readonly int test_pistol = Animator.StringToHash("pistol");

//	string.GetHashCode("hello");
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		base.OnStateEnter (animator, stateInfo, layerIndex);

		if (stateInfo.shortNameHash == ht_rifle) {
			Debug.Log ("Rifle");
		}
		else if (stateInfo.shortNameHash == test_pistol) {
			Debug.Log ("Pistol");
		}

//		if (stateInfo.IsName ("pistol")) {
//			Debug.Log("pistolpistolpistolpistol");
			//Debug.Log(test_pistol.)
//		}
//		Debug.Log (stateInfo.fullPathHash);
//		Debug.Log(ht_rifle);
//		Debug.Log(state_pistol);
//		stateInfo.GetHashCode
//		Debug.Log (stateInfo.fullPathHash);
	}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateUpdate (animator, stateInfo, layerIndex);
	//	Debug.Log (stateInfo.fullPathHash);
	}

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateExit (animator, stateInfo, layerIndex);
	//	Debug.Log (stateInfo.fullPathHash);	
	}

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateMove (animator, stateInfo, layerIndex);
		animator.ApplyBuiltinRootMotion ();
		//Debug.Log (stateInfo.fullPathHash);	
	}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateIK (animator, stateInfo, layerIndex);
	}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
		base.OnStateMachineEnter (animator, stateMachinePathHash);
		Debug.Log(state_pistol);
		Debug.Log ("OnStateMachineEnter" + stateMachinePathHash);
	}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
		base.OnStateMachineExit (animator, stateMachinePathHash);
	}
}

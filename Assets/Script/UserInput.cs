using UnityEngine;
using System.Collections.Generic; 

namespace Player {
	[RequireComponent(typeof(PlayerAttributes))]
	public class UserInput : MonoBehaviour {
//		private Animator _animator;
//		private 
		public float Horizontal {get; private set;}
		public float Vertical{ get; private set;} 

		public float LastInput{ get; private set;}

//		private void Awake() {
				
//		}

		private void Start() {
			foreach (BaseSMB smb in GetComponent<Animator>().GetBehaviours<BaseSMB>())
				smb.OnStart ();
		}

		private void OnEnable() {
			BaseSMB[] smbs = GetComponent<Animator> ().GetBehaviours<BaseSMB> ();
			for (int i = 0; i < smbs.Length; i++) {
				smbs [i]._userInput = this;
				smbs [i]._player = GetComponent<PlayerAttributes> ();
				smbs [i].OnEnabled (GetComponent<Animator> ());
			}
			LastInput = Time.time;			
		}

		private void Update() {
			Horizontal = Input.GetAxis ("Horizontal");
			Vertical = Input.GetAxis ("Vertical");

			if (Horizontal != 0 || Vertical != 0) {
				LastInput = Time.time;
			}
 		}		



	}
}
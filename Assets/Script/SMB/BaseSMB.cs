using UnityEngine;

namespace Player {
	public class BaseSMB : StateMachineBehaviour {
		[HideInInspector]
		public UserInput _userInput;
		[HideInInspector]
		public PlayerAttributes _player;

		public virtual void OnEnabled(Animator animator) {
		
		}
		public virtual void OnStart() {
		
		}
	}
}

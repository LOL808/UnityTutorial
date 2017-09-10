using UnityEngine;
using Player.Triggers;

namespace Player {
	public enum HPredefinedLocomType { FreeWithKeys, StaticWithKeys, WithNavmesh, DeactivatedLayer }
	public enum HMoveType {Idle,Walk,Run,Sprint}

	public class HLocomotionParams {
		
	}

	public class HLocomotionStaticParams : HLocomotionParams {
		public Transform TurnToObject { get; private set;}
		public int LocomotionIndex { get; private set;}

		public HLocomotionStaticParams(Transform _turnToObject, int _locomStyleIndex) {
			TurnToObject = _turnToObject;
			LocomotionIndex = _locomStyleIndex;
		}
	}

	public class HLocmotionFreeParams : HLocomotionParams {
//		public int Lo
	}



	public class HLocomotionCSMB : HCustomPlayerSystemSMB {

		//const
		private const string overrideKey = "HLocomotionSMB";
		private static readonly int ht_Locomotion = Animator.StringToHash("Locomotion");
		private static readonly int ht_Turning = Animator.StringToHash("Turning");

		private static readonly int cap_VelX = Animator.StringToHash("VelX");
		private static readonly int cap_VelY = Animator.StringToHash("VelY");
		private static readonly int cap_Angle= Animator.StringToHash("Angle");

		private static readonly int cap_Speed= Animator.StringToHash("Speed");
		private static readonly int cap_QuickTurn = Animator.StringToHash("QuickTurn");
	
		//getters and setters

		public HLocomotionEvents locomotion_events { get; private set;}
		public bool IsSprinting { get; private set;}
		public bool IsWalking { get; private set;}
		public bool IsCrouching {get;private set;}
		public bool AllowSprint { get; set;}
		public bool IsMovingWithAgent { get; set;}

//		public HPre
		public HPredefinedLocomType LocomType{get;set;}
		public Transform TurnToTransform{ get; set;}
		public Transform MoveToTransformWithAgent{ get; set;}
		public Vector3 MoveToPosWithAgent{ set; get;}
		public float LayerWeightTarget{ get; private set;}
		public bool PathPending {get;private set;}
		public bool IsFreeLooking{ get; private set;}
	
		public bool IsLocomoting{
			get { return LocomType != HPredefinedLocomType.DeactivatedLayer;}
			private set { }
		}


		private HLocomotionParams cProps;
//		private bool crouch
		private HMoveType moveType;
		private float lastAngle, lastVelX,lastVelY;
		private Transform transform;
		private Rigidbody rb;
		private Vector2 smoothDeltaPosition;
		private Vector2 velocity;
		private Animator animator;


		#region Starters
		public override void OnEnabled(Animator animator) {
			TriggS = new HLayerWithDefValue<HSysTrigger> (new HLocomotionTrigger());
			locomotion_events = new HLocomotionEvents ();
			transform = animator.transform;
			animator = _userInput.GetComponent<Animator> ();
//			animator = userInput.GetComponent<Animator>();
		}
		#endregion

		public override void OnStateUpdate(Animator animtor, AnimatorStateInfo stateInfo, int layerIndex) {
			UpdateLayerWeight (layerIndex);
			LocomotionWithKeysFree (animtor, layerIndex, false);
		}

		private void UpdateLayerWeight(int layerIndex) {
//			/animator.SetLayerWeight (layerIndex,Mathf.Lerp(animator.GetLayerWeight(layerIndex),0,
			//	(LayerWeightTarget < .5f?HLocomotionStyle.layerDisableSpeed:HLocomotionStyle.layerEnableSpeed)*Time.deltaTime));
		}

		private void LocomotionWithKeysFree(Animator animator, int layerIndex, bool turnTo) {
			Vector3 moveDirection = Vector3.zero;
			float targetAngle = 0.0f;
			bool shouldMove = true;

		}


		public void CalculateRefs(
			ref Vector3 targetMoveDirection,
			ref float targetAngle,
			ref bool shouldMove,
			bool useKeys = true,
			bool moveWithNavMesh = false,
			bool turnTo = false
		)	{
				
		}

	}
	
}
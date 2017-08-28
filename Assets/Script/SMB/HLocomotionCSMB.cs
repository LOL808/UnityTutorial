using UnityEngine;

namespace Player {
	public enum HPredefinedLocomType { FreeWithKeys, StaticWithKeys, WithNavmesh, DeactivatedLayer }
	public enum HMoveType {Idle,Walk,Run,Sprint}

	public class HLocomotionParameters {
		
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

		#region Starters
		public override void OnEnabled(Animator animator) {
//			HTriggers = new HLayerWithDefValue<HLocomotionEvents> (new HLocomotionTrigger());
		}
		#endregion
	}
	
}
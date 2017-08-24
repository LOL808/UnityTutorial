using System;
using UnityEngine;
[Serializable]

//using U
public class RootMotionMgr  {
	
	public struct SurfaceInfo{
		public RaycastHit currentHit;
		public RaycastHit predictHit;
		public Vector3 currentMotion;
		public Vector3 predictMotion;

		public SurfaceInfo(RaycastHit cur, RaycastHit pre, Vector3 cm, Vector3 pm){
			currentHit = cur;
			predictHit = pre;
			currentMotion = cm;
			predictMotion = pm;
		}	
	}

	public float motionMultiplier = 1f;             // Percent of root motion application, 0.5 is half speed, 2 is double speed.
	public bool overrideVerticalMotion = true;      // Whether or not the root motion overrides any vertical velocity the character has.

	private Animator m_Animator;                    // Reference to the animator component.
	private Transform m_Transform;                  // Reference to the transform component.
	private Rigidbody m_Rigidbody;                  // Reference to the rigidbody component.
	private CapsuleCollider m_Capsule;              // Reference to the capsule collider.
	private LayerMask mask;                         // The layer which root motion should be applied tangentially too.

	private const float k_RayDistance = 1.5f;       // The distance of the raycasts for detecting the surface the character is on.
	private const float k_ErrorMargin = 0.01f;      // A small margin to avoid any errors when casting rays and detecting surfaces.

	public void Init(Animator animator) {
		m_Animator = animator;
		m_Transform = animator.GetComponent<Transform> ();
		m_Rigidbody = animator.GetComponent<Rigidbody> ();
		m_Capsule = animator.GetComponent<CapsuleCollider> ();
		mask = LayerMask.GetMask ("Collision");
	}

	private SurfaceInfo GetSurFaceInfo() {
		RaycastHit currentHit;
		RaycastHit predictHit;

		Ray ray = new Ray (m_Transform.position+m_Transform.up,-m_Transform.up);
		Physics.Raycast (ray, out currentHit, k_RayDistance, mask);

		ray.origin += m_Animator.deltaPosition.normalized*(m_Capsule.radius+k_ErrorMargin);
		Physics.Raycast (ray, out predictHit, k_RayDistance, mask);

		float mag = m_Animator.deltaPosition.magnitude;
		Vector3 cm = Vector3.ProjectOnPlane (m_Animator.deltaPosition, currentHit.normal).normalized * mag;
		Vector3 pm = Vector3.ProjectOnPlane (m_Animator.deltaPosition, predictHit.normal).normalized * mag;
		return new SurfaceInfo (currentHit,predictHit,cm,pm);
	}

	private void RigidbodyApplication(Vector3 deltaPos) {
		if (!overrideVerticalMotion) {
			deltaPos.y = m_Rigidbody.velocity.y * Time.deltaTime / motionMultiplier;
		}
		if (Time.deltaTime > 0) // workaround for enabling timescale in game wo warning
			m_Rigidbody.velocity = deltaPos * motionMultiplier / Time.deltaTime;
	}

	private Vector3 handleStepUp(Vector3 stepHitPoint) {
		Vector3 contactpt = m_Capsule.ClosestPointOnBounds (stepHitPoint);
		Vector3 rootToContact = stepHitPoint - m_Transform.position;
		Vector3 movement = rootToContact.normalized * m_Animator.deltaPosition.magnitude;
		return movement;
	}

	public void ApplyToRigidbodyAlongSurface() {
		SurfaceInfo info = GetSurFaceInfo ();
		float diff = info.predictHit.point.y - info.currentHit.point.y;
		//水平走
		if (diff < k_ErrorMargin || diff > -k_ErrorMargin) {
			RigidbodyApplication (info.currentMotion);
			return;
		}
		//上坡
		if (info.predictMotion.y > k_ErrorMargin) {
			RigidbodyApplication (info.predictMotion);
			return;
		}
		//即将爬完上坡
		if (info.currentMotion.y > k_ErrorMargin) {
			RigidbodyApplication (info.currentMotion);
			return;
		}
		//下坡
		if (info.currentMotion.y < -k_ErrorMargin || info.predictMotion.y < -k_ErrorMargin) {
			RigidbodyApplication (m_Animator.deltaPosition);
			return;
		}

		if (info.currentMotion.y < -k_ErrorMargin && info.predictMotion.y < -k_ErrorMargin) {
			Vector3 movement = info.currentMotion.y < info.predictMotion.y ? info.predictMotion : info.currentMotion;
			RigidbodyApplication (movement);
			return;
		}
		//下楼梯
		if (diff < 0f) {
			RigidbodyApplication (m_Animator.deltaPosition);
			return;
		}
		//上楼梯
		Vector3 stepMovement = handleStepUp (info.predictHit.point);
		RigidbodyApplication (stepMovement);
		
	}

	public void ApplyRotation() {
		m_Transform.rotation *= m_Animator.deltaRotation;

	}
}

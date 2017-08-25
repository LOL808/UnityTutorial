using System.Collections.Generic;
using UnityEngine;

namespace Player{
	public class PlayerAttributes : MonoBehaviour {
		public LayerMask groundLayer;
		public int defaultLocomStyleIndex = 0;
		[Space]
		public List<HLocomotionStyle> _locomotionStyles;

	}
}
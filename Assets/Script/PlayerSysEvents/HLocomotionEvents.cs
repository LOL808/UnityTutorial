namespace Player {
	public class HLocomotionEvents{
		public delegate void EVT_HLocomotionChanged(HLocomotionStyle oldStyle,HLocomotionStyle newStyle);
		public event EVT_HLocomotionChanged onHLocomotionStyleChanged;

		public void InvokeLocomotionStyleChanged(HLocomotionStyle oldStyle, HLocomotionStyle newStyle) {
			if (onHLocomotionStyleChanged!=null) {
				onHLocomotionStyleChanged(oldStyle,newStyle);
			}
		}
	}
}
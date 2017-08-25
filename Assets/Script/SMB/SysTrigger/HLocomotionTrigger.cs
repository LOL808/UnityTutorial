namespace Player.HTriggers{
	public class HLocomotionTrigger : HSysTrigger {
		public const string ct_move = "Move";
		public HLocomotionTrigger() {
			_tirggers.Add (ct_move, true);
		}
		public HLocomotionTrigger(bool isMove) {
			_tirggers.Add (ct_move, isMove);
		}
	}
}
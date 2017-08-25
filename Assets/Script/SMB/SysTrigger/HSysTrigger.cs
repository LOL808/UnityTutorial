using System.Collections.Generic;

namespace Player.HTriggers {
	public class HSysTrigger{
		protected Dictionary<string,bool> _tirggers;
		public HSysTrigger() {
			_tirggers = new Dictionary<string,bool> ();
		}

		public bool GetTrigger(string name) {
			return _tirggers [name];
		}
	}
}
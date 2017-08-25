using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player {
	public class HLayerWithDefValue<TVal> {
	

		private class Layer<TVal> {
			public short _priority { get ; private set;}
			public string _key { get; private set;}
			public TVal _value{ get; set;}

			public Layer(string key, short priority,TVal val) {
				_priority = priority;
				_key = key;
				_value = val;
			}
		}
	}
}
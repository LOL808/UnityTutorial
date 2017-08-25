using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player {
	public class HLayerWithDefValue<TVal> {
	

		private class Layer<T> {
			public short _priority { get ; private set;}
			public string _key { get; private set;}
			public T _value{ get; set;}

			public Layer(string key, short priority,T val) {
				_priority = priority;
				_key = key;
				_value = val; 
			}
		}
	}
}
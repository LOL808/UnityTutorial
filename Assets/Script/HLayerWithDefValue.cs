using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player {
	public class HLayerWithDefValue<TVal> {
	

		private List<Layer<TVal>> layers;
		public TVal LastValue { get; private set;}
		public string LastId{ get; private set;}
		public string Name{ get; private set;}

		public HLayerWithDefValue(TVal constVal,string name = "") {
			layers = new List<Layer<TVal>> ();
			Name = name;
			Override ("Default",short.MaxValue,constVal);
		}

		public void Override(string _key, short _priority,TVal _val){
			if (IsOverrideWithKey (_key)) {
				Debug.Log ("key already exists");
				return;
			}
			layers.Add(new Layer<TVal>(_key,_priority,_val));
			SortLayersAndGetLasts ();
		}

		public bool Contains(string _key) {
			return layers.Find (x => x.key == _key) != null;
		}

		private void SortLayersAndGetLasts() {
			layers = layers.OrderByDescending (x => x.priority).ToList ();
			LastValue = layers.Last ().value;
			LastId = layers.Last ().key;
		}

		public void Modify(string _key,TVal _val) {
			if (IsOverrideWithKey (_key) == false) {
				Debug.Log("Key does not exists (skipping modify):" + _key + " " + ToString());
				return;
			}
			layers.Find (x => x.key == _key).value = _val;

		}

		public void Release(string _key) {
			if (!IsOverrideWithKey (_key)) {
				Debug.Log ("Key does not exist "+_key+ToString());
				return;
			}

			if (layers.Count == 1) {
				Debug.Log ("Count == 1");
				return;
			}
			layers.Remove (layers.Find (x => x.key == _key));
			SortLayersAndGetLasts ();
		}

		public bool IsOverrideWithKey(string id) {
			return layers.Find (x => x.key == id) != null;
		}

		private class Layer<T> {
			public short priority { get ; private set;}
			public string key { get; private set;}
			public T value{ get; set;}

			public Layer(string key, short priority,T val) {
				this.priority = priority;
				this.key = key;
				value = val; 
			}
		}
	}
}
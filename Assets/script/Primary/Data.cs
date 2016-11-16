using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data:MonoBehaviour{

	protected Dictionary<string,GameObject> model;
	
	void Awake() {
		model = new Dictionary<string, GameObject>();
		for (int i = 0; i < this.transform.childCount; i++) {
			GameObject child = this.transform.GetChild(i).gameObject;
			model.Add(child.name,child);
			child.SetActive(false);
		}
	}

	public void ResetModel(){
		foreach (KeyValuePair<string,GameObject> pair in model) {
			pair.Value.SetActive(false);
		}
	}

	public void SetChildView(string key,bool station){
		GameObject child;
		if (model.TryGetValue (key, out child)) {
			child.SetActive(station);
		}
	}
}

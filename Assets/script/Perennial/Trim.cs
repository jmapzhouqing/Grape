using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trim : MonoBehaviour {
	public string[] list;

	private List<string> result;

	private List<string> correct;

	public int Confirm(){
		result = new List<string> ();
		correct = new List<string> (list);

		for (int i=0; i<this.transform.childCount; i++) {
			result.Add(this.transform.GetChild(i).name);
		}

		foreach (string value in correct) {
			if(result.Contains(value)){
				correct.Remove(value);
				result.Remove(value);
			}
		}

		if (correct.Count == 0 && result.Count == 0) {
			
		}else{
			if(correct.Count == list.Length){

			}
		}

		return 0;
	}
}

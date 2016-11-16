using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeleteConfirm : MonoBehaviour {

	public string[] correct;

	private List<string> correct_list;

	private List<string> compare;
	// Use this for initialization
	void Awake () {
		correct_list = new List<string> (correct);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetValue(){
		int score = 0;

		for (int i=0; i<this.transform.childCount; i++) {
			compare.Add(this.transform.name);
		}

		foreach (string value in correct_list) {
			if(compare.Contains(value)){
				compare.Remove(value);
				correct_list.Remove(value);
			}
		}

		if (correct_list.Count != correct.Length) {
			if(correct_list.Count!=compare.Count){
				score = 3;
			}else{
				score = 5;
			}
		}
		return score;
	}
}

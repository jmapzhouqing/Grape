using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CaculateGrade : MonoBehaviour {
    public string key;

	public Text text;
	// Use this for initialization
	void OnEnable () {
		Dictionary<string,int> dic = SceneManager.instance.achievement [key];
		float score = 0;
		foreach (KeyValuePair<string,int> pair in dic) {
			score += pair.Value;
		}
		print (score);
		text.text = score+"分";
    }

	public void Confirm(){
		SceneManager.instance.ExecuteOperation ();
	}
}

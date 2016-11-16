using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Option:PickUp {
	public string correct;

	public Sprite check;
	public Sprite uncheck;

	private string result;

	public void PickUp(GameObject pick){
		ClearPickUp (pick.transform.parent);
		pick.GetComponent<Image>().sprite = check;
		result = pick.name;
	}

	private void ClearPickUp(Transform parent){
		for (int i=0; i<parent.childCount; i++) {
			parent.GetChild(i).GetComponent<Image>().sprite = uncheck;
		}
	}

	public override bool Error(){
		bool error = true;
		if (correct.Equals (result)) {
			error = false;
		}
		return error;
	}

	public void Confirm(){
		if (correct.Equals (result)) {
			SceneManager.instance.Grade(key,5);
		} else {
			SceneManager.instance.Grade(key,5);
			if(error_stop){
                UIRootManager.instance.GetViewChild("error").SetActive(true);
				return;
			}
		}
        if (callback != null) {
            callback();
        }
		SceneManager.instance.ExecuteOperation ();
	}
}

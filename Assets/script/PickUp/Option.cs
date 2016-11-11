using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option : MonoBehaviour {
	public string correct;
	public string key;

	public bool error_stop;

	private string result;

	public void PickUp(GameObject pick){
		ClearPickUp ();
		pick.GetComponent<Image> ().color = Color.red;
		result = pick.name;
	}

	private void ClearPickUp(){
		for (int i=0; i<this.transform.childCount; i++) {
			this.transform.GetChild(i).GetComponent<Image>().color = Color.green;
		}
	}

	public void Confirm(){
		if (correct.Equals (result)) {
			SceneManager.instance.Grade(key,5);
		} else {
			SceneManager.instance.Grade(key,5);
			if(error_stop){
				return;
			}
		}
		SceneManager.instance.ExecuteOperation ();
	}
}

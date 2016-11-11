using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour {
	public string correct;
	public string key;

	public bool error_stop;

	private string result;

	public void Confirm(){
		foreach (Toggle child in this.GetComponentsInChildren<Toggle>()) {
			if(child.isOn){
				result = child.name;
			}
		}

		if(result.Equals(correct)){
			SceneManager.instance.Grade(key,5);
		}else{
			SceneManager.instance.Grade(key,0);
			if(error_stop){
				return;
			}
		}
		SceneManager.instance.ExecuteOperation ();
	}
}

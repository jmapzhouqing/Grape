using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MultiCheckBox : PickUp {
	public string[] correct_name;
	public string[] correct_value;
	

	private float score;

	private Dictionary<string,string> result;

	void Awake(){
		result = new Dictionary<string, string> ();
	}
	
	public void Confirm(){
		foreach (ToggleGroup group in this.GetComponentsInChildren<ToggleGroup>()) {
			foreach(Toggle child in group.GetComponentsInChildren<Toggle>()){
				if(child.isOn){
					result.Add(group.name,child.name);
				}
			}
		}

		for (int i=0; i<correct_name.Length; i++) {
			string name = correct_name[i];
			string value = correct_value[i];

			if(result.ContainsKey(name)&&value.Equals(result[name])){
				score +=5.0F/correct_name.Length;
			}
		}

		SceneManager.instance.Grade(key,Mathf.CeilToInt(score));

		if ((Mathf.Abs (score - 5.0F) > Mathf.Pow (1, -2))&&error_stop) {
            UIRootManager.instance.GetViewChild("error").SetActive(true);
            result.Clear();
            return;
		}

		if (!string.IsNullOrEmpty (video_name)) {
			UIRootManager.instance.PlayVideo(video_name,delegate {
				if (callback != null)
				{
					callback();
				}
				SceneManager.instance.ExecuteOperation ();
			});
			this.gameObject.SetActive(false);
			return;
		}

        if (callback != null)
        {
            callback();
        }

        SceneManager.instance.ExecuteOperation ();
	}
}

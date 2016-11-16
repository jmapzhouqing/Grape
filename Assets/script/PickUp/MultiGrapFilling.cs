using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MultiGrapFilling : PickUp {
	public string[] correct_name;
	public string[] correct_value;
	private Dictionary<string,string> result;

	private float score;
	// Use this for initialization
	void Awake () {
		result = new Dictionary<string, string> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool Error(){
		bool error = false;
		score = 0;
		foreach (InputField field in this.GetComponentsInChildren<InputField>()) {
			result.Add(field.name,field.text);
		}
		
		for (int i=0; i<correct_name.Length; i++) {
			string name = correct_name[i];
			string value = correct_value[i];
			
			if(result.ContainsKey(name)){
				if(value.Contains("-")){
					float pre = float.Parse(value.Split('-')[0]);
					float next =float.Parse(value.Split('-')[1]);
					float input = float.Parse(result[name]);
					if(input >=pre&&input<=next){
						score +=5.0F/correct_name.Length;
					}
				}else{
					if(value.Equals(result[name])){
						score +=5.0F/correct_name.Length;
					}
				}
			}
		}
		if (Mathf.Abs (score - 5.0F) > Mathf.Pow (1, -2)){
			error = true;
		}
		return error;
	}

	public void Confirm(){
		bool error = Error ();
		SceneManager.instance.Grade(key,Mathf.CeilToInt(score));
		if (error&&error_stop) {
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

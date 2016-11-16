using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckBox : PickUp {
	public string correct;
	private string result;

	public override bool Error(){
		bool error = true;
		foreach (Toggle child in this.GetComponentsInChildren<Toggle>()) {
			if(child.isOn){
				result = child.name;
			}
		}
		
		if (result.Equals (correct)) {
			error = false;
		}

		return error;
	}

	public void Confirm(){
		if(!Error()){
			SceneManager.instance.Grade(key,5);
		}else{
			SceneManager.instance.Grade(key,0);
			if(error_stop){
                UIRootManager.instance.GetViewChild("error").SetActive(true);
                return;
			}
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

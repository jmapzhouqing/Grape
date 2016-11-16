using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace perennial{
	public class Step_Nine : PickUp {

		public InputField field;

		public void Confirm(){
			float value = float.Parse (field.text);
			if (value >= 3.0F && value <= 5.0F) {
				SceneManager.instance.Grade (key, 5);
			} else {
				SceneManager.instance.Grade (key, 0);
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
}

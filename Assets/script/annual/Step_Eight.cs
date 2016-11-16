using UnityEngine;
using System.Collections;
namespace annual{
	public class Step_Eight : PickUp{


		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void Confirm(){
			bool error = false;
			foreach (MultipleChoice choice in this.GetComponentsInChildren<MultipleChoice>()) {
				error |= choice.Error(); 
			}

			if(error_stop && error){
				UIRootManager.instance.GetViewChild("error").SetActive(true);
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

	        SceneManager.instance.ExecuteOperation();
	    }
	}
}

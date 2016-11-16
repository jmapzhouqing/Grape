using UnityEngine;
using System.Collections;

public class Step_Thirteen : PickUp {
	public void Confirm(){
		bool error = false;
		for (int i=0; i<this.transform.childCount; i++) {
			PickUp pickup = this.transform.GetChild(i).GetComponent<PickUp>();
			if(pickup!=null){
				error = error || pickup.Error();
			}
		}

		if (error && error_stop) {
			UIRootManager.instance.GetViewChild("error").SetActive(true);
			return;
		}
		
		if (callback != null)
		{
			callback();
		}
		
		SceneManager.instance.ExecuteOperation();
	}
}

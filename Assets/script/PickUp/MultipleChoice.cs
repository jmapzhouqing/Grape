using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class MultipleChoice:PickUp {
	private List<string> pickup_list;

	public Sprite check;
	public Sprite uncheck;

	

	public string[] correct;

	void Awake(){
		pickup_list = new List<string> ();
	}

	public void PickUp(GameObject pick){
		if(pickup_list.Contains (pick.name)){
			pick.GetComponent<Image>().sprite = uncheck;
			pickup_list.Remove(pick.name);
		}else{
			/*
			if (pickup_list.Count == correct.Length) {
				return;
			}*/
			pick.GetComponent<Image>().sprite = check;
			pickup_list.Add(pick.name);
		}
	}

	public override bool Error(){
		bool error = false;
		if(correct.Length != pickup_list.Count) {
			error = true;
		}else{
			for(int i=0;i<correct.Length;i++){
				if(!pickup_list.Contains(correct[i])){
					error = true;
					break;
				}
			}
		}
		return error;
	}

	public void Confirm(){
		if(error_stop && Error()){
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace framework{
	public class MultipleChoice:MonoBehaviour {
		private List<string> pickup_list;

		public string key;

		public bool error_stop;

		public string[] correct;

		void Awake(){
			pickup_list = new List<string> ();
		}

		public void PickUp(GameObject pick){
			if(pickup_list.Contains (pick.name)){
				pick.GetComponent<Image>().color = Color.green;
				pickup_list.Remove(pick.name);
			}else{
				pick.GetComponent<Image>().color = Color.red;
				pickup_list.Add(pick.name);
			}
		}

		public void Confirm(){
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
			/*
			if(error_stop && error){
				
			}*/

			SceneManager.instance.ExecuteOperation ();
		}
	}
}

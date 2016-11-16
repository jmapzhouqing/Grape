using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace perennial{
	public class Step_TwentyThree : PickUp {
		
		private int index = 0;
		
		public Image xf; 
		public Image wx;
		
		public Transform select;
		
		public string[] video_list;
		
		private List<Vector3> position_list;
		
		private Vector3[] position = new Vector3[]{
			new Vector3(0,151,0),
			new Vector3(0,-34,0),
			new Vector3(0,-233,0)
		};
		
		// Use this for initialization
		void Awake(){
			position_list = new List<Vector3>(position);
			TransformSort();
		}
		
		public void PickUp(GameObject pick){
			print (pick.name.Equals(index.ToString()));
			if (pick.name.Equals(index.ToString()))
			{
				pick.GetComponent<Button>().interactable = false;
				if(index == 0){
					xf.gameObject.SetActive(true);
				}else if(index == 1){
					wx.gameObject.SetActive(true);
				}else if(index == 2){
					//UIRootManager.instance.PlayVideo();
				}
				++index;
				//this.gameObject.SetActive(false);
			}
			else
			{
				index = 0;
				position_list = new List<Vector3> (position);
				TransformSort();
				UIRootManager.instance.GetViewChild("error").SetActive(true);
			}
		}
		
		public void TransformSort(){
			for (int i = 0; i < select.childCount; i++){
				RectTransform rect = select.GetChild(i).GetComponent<RectTransform>();
				int value = Random.Range(0, position_list.Count - 1);
				rect.anchoredPosition3D = position_list[value];
				position_list.RemoveAt(value);
				rect.GetComponent<Button>().interactable = true;
			}
		}
		
		public void XF_Confrim(){
			bool error = xf.GetComponentInChildren<PickUp> ().Error ();
			string child_key = xf.GetComponentInChildren<PickUp> ().key;
			if (error) {
				SceneManager.instance.Grade (child_key, 0);
				UIRootManager.instance.GetViewChild("error").SetActive(true);
				return;
			} else {
				SceneManager.instance.Grade (child_key, 5);
			}
			xf.gameObject.SetActive (false);
		}

		public void WX_Confrim(){
			bool error = wx.GetComponentInChildren<PickUp> ().Error ();
			string key = wx.GetComponentInChildren<PickUp> ().key;
			if (error) {
				SceneManager.instance.Grade (key, 0);
			} else {
				SceneManager.instance.Grade (key, 5);
			}
			wx.gameObject.SetActive (false);
		}
	}
}

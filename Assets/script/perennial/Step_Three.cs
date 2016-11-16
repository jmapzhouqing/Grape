using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace perennial{
	public class Step_Three : PickUp {
		private int index = 0;
		
		public Transform select;
		
		public string[] video_list;
		
		private List<Vector3> position_list;
		
		private Vector3[] position = new Vector3[]{
			new Vector3(0,211,0),
			new Vector3(0,80,0),
			new Vector3(0,-48,0),
			new Vector3(0,-179,0),
			new Vector3(0,-302,0)
		};
		
		// Use this for initialization
		void Awake(){
			position_list = new List<Vector3>(position);
			TransformSort();
		}
		
		public void PickUp(GameObject pick){
			if (pick.name.Equals(index.ToString()))
			{
				pick.GetComponent<Button>().interactable = false;
				/*
				UIRootManager.instance.PlayVideo(video_list[index], delegate{
					if (index == 4){
						if(callback != null){
							callback();
						}
						SceneManager.instance.ExecuteOperation();
					}else{
						this.gameObject.SetActive(true);
					}
					
				});*/
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
				print (value);
				rect.anchoredPosition3D = position_list[value];
				position_list.RemoveAt(value);
				rect.GetComponent<Button>().interactable = true;
			}
		}
	}
}

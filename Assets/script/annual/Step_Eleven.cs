using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
namespace annual{
	public class Step_Eleven : PickUp {
		private int index = 0;

		public Transform select;

	    public Sprite origin;

		public Sprite[] sprite_list;

		public Image effect;

		private Vector3[] position = new Vector3[]{
			new Vector3(0,195,0),
			new Vector3(0,61,0),
			new Vector3(0,-72,0),
			new Vector3(0,-207,0)
		};

		private List<Vector3> position_list;
		// Use this for initialization
		void Awake () {
			position_list = new List<Vector3> (position);
			TransformSort ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void PickUp(GameObject pick){
			if (pick.name.Equals (index.ToString())) {
				pick.GetComponent<Button>().interactable = false;
				effect.sprite = sprite_list[index];
				++index;
	            if (index == 4) {
					if (callback != null)
					{
						callback();
					}
	                SceneManager.instance.ExecuteOperation();
	            }
			} else {
				index = 0;
	            effect.sprite = origin;
	            position_list = new List<Vector3> (position);
				TransformSort();
	            UIRootManager.instance.GetViewChild("error").SetActive(true);
			}
		}

		public void TransformSort(){
			for (int i=0; i<select.childCount; i++) {
				RectTransform rect = select.GetChild(i).GetComponent<RectTransform>();
				int value = Random.Range(0,position_list.Count-1);

				rect.anchoredPosition3D = position_list[value];
				position_list.RemoveAt(value);
				rect.GetComponent<Button>().interactable = true;
			}
		}
	}
}

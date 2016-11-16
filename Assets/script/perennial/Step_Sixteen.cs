using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace perennial{
	public class Step_Sixteen : PickUp {
		public Image correct;
		private string result;
		public string path_key;
		void OnEnable(){
			int index = Random.Range (0,this.GetComponentsInChildren<Toggle>().Length-1);
			correct.sprite = Resources.Load ("texture/"+path_key+"/" + index, typeof(Sprite)) as Sprite;
			this.GetComponentInChildren<CheckBox> ().correct = index.ToString ();
		}
	}
}

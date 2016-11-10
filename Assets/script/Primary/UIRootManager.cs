using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIRootManager : MonoBehaviour {
	private Canvas canvas;
	public static UIRootManager instance;

	private Dictionary<string,GameObject> viewList;

	private Dictionary<string,int> achievement;

	void Awake(){
		instance = this;
		achievement = new Dictionary<string,int>();
		canvas = this.GetComponentInChildren<Canvas> ();
		CreateChildDic();
	}

	//
	private void CreateChildDic(){
		viewList = new Dictionary<string, GameObject> ();
		for (int i=0; i<this.transform.childCount; i++) {
			GameObject child = this.transform.GetChild(i).gameObject;
			child.SetActive(false);
			viewList.Add(child.name,child);
		}
	}
	//根据key值获取指定UI
	public GameObject GetViewChild(string key){
		GameObject child;
		if (viewList.TryGetValue (key, out child)) {
			return child;
		} else {
			return null;
		}
	}

	//给定步骤打分
	public void Grade(string key,int value){
		if(!achievement.ContainsKey(key)){
			achievement.Add(key,value);
		}
	}

	//显示对话框信息
	public void ExhibitionDialogBox(PerformanceInfo info){
		if (!string.IsNullOrEmpty (info.describe)) {
			//dialog.SetActive (true);
			//dialog.GetComponentInChildren<Text> ().text = message;
		} else {
			HiddenDialogBox();
		}
	}

	//隐藏对话框
	public void HiddenDialogBox(){
		//viewList ["dialog"]
	}

	//清除子物体
	private void RemoveChild(Transform parent){
		for (int i=0; i<parent.childCount; i++){
			GameObject.Destroy(parent.GetChild(i).gameObject);
		}
	}

	void OnEnable () {
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		canvas.worldCamera = SceneManager.instance.UICamera;
	}
}

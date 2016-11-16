using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class UIRootManager : MonoBehaviour {
	private Canvas canvas;
	public static UIRootManager instance;

	private PerformanceInfo performanceInfo;

	private Dictionary<string,GameObject> viewList;

	void Awake(){
		instance = this;
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



	//显示对话框信息
	public void ExhibitionDialogBox(PerformanceInfo info){
      
        RemoveChild(GetViewChild("control").transform);
		this.performanceInfo = info;
		if (!string.IsNullOrEmpty (info.describe)) {
			GetViewChild("dialog").SetActive (true);
			GetViewChild("dialog").GetComponentInChildren<Text> ().text = info.describe;
		} else {
			HiddenDialogBox();

		}
	}

	//隐藏对话框
	public void HiddenDialogBox(){
		GetViewChild("dialog").SetActive(false);
		GameObject prefab = Resources.Load(SceneManager.instance.scene_key+"/"+this.performanceInfo.key,typeof(GameObject)) as GameObject;
		if(prefab!=null){
			RectTransform child = (GameObject.Instantiate(prefab) as GameObject).GetComponent<RectTransform>();

            PickUp pickup = child.GetComponentInChildren<PickUp>();

            if (this.performanceInfo.callback != null && pickup != null) {
                pickup.callback = this.performanceInfo.callback;
            }

			child.SetParent(GetViewChild("control").transform);
			
			child.transform.localPosition = prefab.transform.position;
			child.transform.localScale = prefab.transform.localScale;
			child.transform.rotation = prefab.transform.rotation;
			
			if(!GetViewChild("control").activeSelf){
				GetViewChild("control").SetActive(true);
			}
		}else{
            /*
			GameObject complete = GetViewChild("complete");
			if(complete!=null){
				complete.SetActive(true);
			}*/
            SceneManager.instance.ExecuteOperation();
		}
		Resources.UnloadUnusedAssets ();
	}

	public void PlayVideo(string name,Action callback){
		GetViewChild ("VideoPlay").SetActive (true);
		VideoPlay videoPlay = GetViewChild ("VideoPlay").GetComponent<VideoPlay> ();
		videoPlay.SetCallback (callback);
		videoPlay.Play (name);
	}

	//清除子物体
	public void RemoveChild(Transform parent){
		for (int i=0; i<parent.childCount; i++){
			GameObject.Destroy(parent.GetChild(i).gameObject);
		}
	}

	void OnEnable () {
		//canvas.renderMode = RenderMode.ScreenSpaceCamera;
		//canvas.worldCamera = SceneManager.instance.UICamera;
	}

    public void HideError() {
        GetViewChild("error").SetActive(false);
    }
}

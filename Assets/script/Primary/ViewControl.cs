using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class ViewControl : MonoBehaviour {
	public static ViewControl instance;

	public RectTransform task_container;

	private Dictionary<string,GameObject> viewList;

	public List<string> placeSeedling;

	public List<string> tool_list;

	public GameObject task_prefab;

	private GameObject dialog;
	private GameObject time;
	private GameObject task;
	private GameObject toolcontrol;
	private GameObject tool_panel;
	private GameObject error;

	private GameObject video;

	private GameObject control;

	public GameObject user;

	public GameObject camera;

	public GameObject tip;

	public int index = 1;

	public Dictionary<string,int> score;

	private string[] dialog_list = new string[]{
		"欢迎来到定植温室,请进行整地施肥的操作.请选择相应的工具",
		"对于农家肥来说,每667㎡撒施多少优质农家肥?",
		"",
		"请用铁锹将农家肥铺平",
		"摊平农家肥后,请对地面进行旋耕操作,请设置旋耕深度",
		"请按照大行距和小行距间隔的方式作畦",
		"",
		"请在小高畦上开两条定植沟",
		"",
		"您已经完成了整地施肥的操作步骤，接下来请进行定植操作，或者再练习一次整地施肥操作",
		"请进行选苗操作",
		"请进行栽苗操作,注意苗之间的间距",
		"请在摆好的苗间施肥,肥料采用三元复合肥,用量约17克",
		"请调整封垄埋土的深度",
		"请在两行苗中间开沟,选择正确的深度和宽度",
		"接下来时铺设滴灌环节,请在工具栏内选择滴灌管",
		"请将地膜铺设到定植好的畦上,并按照幼苗的位置在地膜上开口,引出膜外",
		"请将地膜两侧覆土压严",
		""
	};


	// Use this for initialization
	void Awake () {
		instance = this;
		tool_list = new List<string> ();
		score = new Dictionary<string, int> ();
		viewList = new Dictionary<string, GameObject> ();
		placeSeedling = new List<string> ();
		for (int i=0; i<this.transform.childCount; i++) {
			GameObject child = this.transform.GetChild(i).gameObject;
			child.SetActive(false);
			viewList.Add(child.name,child);
		}

		dialog = GetViewChild ("dialog");
		task = GetViewChild ("task");
		control = GetViewChild ("control");
		toolcontrol = GetViewChild ("toolcontrol");
		tool_panel = GetViewChild ("tool_panel");
		video = GetViewChild ("video");
		error = GetViewChild ("error");
	}

	public void ExhibitionDialogBox(string message){
		if (dialog != null &&!string.IsNullOrEmpty (message)) {
			dialog.SetActive (true);
			dialog.GetComponentInChildren<Text> ().text = message;
		} else {
			HiddenDialogBox();
		}
	}

	public void HiddenDialogBox(){
		if (dialog != null) {
			dialog.SetActive(false);
			GameObject prefab = Resources.Load("Planting/"+index,typeof(GameObject)) as GameObject;
			if(prefab!=null){
				RectTransform child = (GameObject.Instantiate(prefab) as GameObject).GetComponent<RectTransform>();
				child.SetParent(control.transform);

				child.transform.localPosition = prefab.transform.position;
				child.transform.localScale = prefab.transform.localScale;
				child.transform.rotation = prefab.transform.rotation;

				if(!control.activeSelf){
					control.SetActive(true);
				}
			}else{
				GameObject complete = GetViewChild("complete");
				if(complete!=null){
					complete.SetActive(true);
				}
			}
			++index;
		}
	}

	private void RemoveChild(Transform parent){
		for (int i=0; i<parent.childCount; i++) {
			GameObject.Destroy(parent.GetChild(i).gameObject);
		}
	}

	public GameObject GetViewChild(string key){
		GameObject child;
		if (viewList.TryGetValue (key, out child)) {
			return child;
		} else {
			return null;
		}
	}

	public void SetScore(string key,int value){
		if(!score.ContainsKey(key)) {
			score.Add(key,value);
		}
	}

	public void ExecuteOperation(){
		int sum = 0;
		foreach (KeyValuePair<string,int> pair in ViewControl.instance.score) {
			sum += pair.Value;
		}

		print (sum);

		if (index <= dialog_list.Length) {
			RemoveChild(control.transform);
			ExhibitionDialogBox(dialog_list[index-1]);
		}
	}

	public void ControlTool(){
		if (tool_panel.activeSelf) {
			tool_panel.SetActive (false);
		} else {
			tool_panel.SetActive(true);
		}
	}

	public void ExhibitionTool(Action action = null){
		toolcontrol.SetActive (true);
		SetCallBack (action);
	}

	public void HiddenTool(){
		toolcontrol.SetActive (false);
		SetCallBack (null);
	}

	public void SetCallBack(Action action){
		//tool_panel.GetComponent<ToolControl>().callback = action;
	}

	public void PlayVideo(string fileName,Action action){
		video.SetActive (true);
		VideoPlay play = video.GetComponent<VideoPlay> (); 
		play.SetCallback (action);
		play.Play (fileName);
	}

	public void AddTask(string key,string info){
		RectTransform child = (GameObject.Instantiate (task_prefab) as GameObject).GetComponent<RectTransform>();
		child.name = key;
		child.GetComponent<Text> ().text = info;
		child.SetParent (task_container.transform);

		child.anchoredPosition3D = Vector3.zero;
		child.localScale = new Vector3 (1,1,1);

		if (!task.activeSelf) {
			task.SetActive(true);
		}
	}

	public void UpdateTask(string key,string info,Color color){
		Transform child = task_container.FindChild (key);
		if (child != null) {
			child.GetComponent<Text> ().text = info;
			child.GetComponent<Text> ().color = color;
		}
	}

	public void ClearTask(){
		for (int i=0; i<task_container.childCount; i++) {
			GameObject.Destroy(task_container.GetChild(i).gameObject);
		}
	}

	public void ExhibitonError(bool station){
		error.SetActive (station);
	}
}

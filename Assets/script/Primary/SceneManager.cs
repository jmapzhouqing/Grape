using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {
	public static SceneManager instance;

	public Camera UICamera;

	public List<PerformanceInfo> performance;

	private Dictionary<string,int> achievement;

	private int index = 1;
	// Use this for initialization
	void Awake () {
		achievement = new Dictionary<string,int>();
		DontDestroyOnLoad (this.gameObject);
	}
	
	static SceneManager(){
		GameObject manager = new GameObject ("SceneManager");
		instance = manager.AddComponent<SceneManager> ();
	}

	public void ExecuteOperation(){
		if (index <= performance.Count) {
			UIRootManager.instance.ExhibitionDialogBox(performance[index-1]);
		}
	}

	//给定步骤打分
	public void Grade(string key,int value){
		if(!achievement.ContainsKey(key)){
			achievement.Add(key,value);
		}
	}
}

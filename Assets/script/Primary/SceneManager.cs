using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {
	public static SceneManager instance;

	public Camera UICamera;

	public string scene_key;

	public List<PerformanceInfo> performance;

	public Dictionary<string,Dictionary<string,int>> achievement;

	public Dictionary<string,string> ephemeral_data;

	public int index = 1;
	// Use this for initialization
	void Awake () {
		ephemeral_data = new Dictionary<string, string> ();
		achievement = new Dictionary<string, Dictionary<string, int>>();
		DontDestroyOnLoad (this.gameObject);
	}
	
	static SceneManager(){
		GameObject manager = new GameObject ("SceneManager");
		instance = manager.AddComponent<SceneManager> ();
	}

	public void ExecuteOperation(){
		if (index <= performance.Count){
			UIRootManager.instance.ExhibitionDialogBox(performance[index-1]);
			index++;
		}
	}



	//给定步骤打分
	public void Grade(string key,int value){
        if (!achievement.ContainsKey(scene_key)) {
            achievement.Add(scene_key, new Dictionary<string, int>());
        }

        Dictionary<string, int> cur_dic = achievement[scene_key];
        if (!cur_dic.ContainsKey(key)){
            cur_dic.Add(key, value);
        }
    }
}

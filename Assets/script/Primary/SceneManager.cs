using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {
	public static SceneManager instance;

	public Camera UICamera;

	public List<PerformanceInfo> performance;

	private int index = 1;
	// Use this for initialization
	void Awake () {
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
}

using UnityEngine;
using System.Collections;

public class SceneInit : MonoBehaviour {
	public string key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		//SceneManager.instance.performance = DataManager.data [key];
		//SceneManager.instance.key = key;
		//SceneManager.instance.ExecuteOperation ();
	}
}

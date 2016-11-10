using UnityEngine;
using System.Collections;

public class UICameraControl : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		SceneManager.instance.UICamera = this.camera;
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

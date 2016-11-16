using UnityEngine;
using System.Collections;

public class UICameraControl : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		SceneManager.instance.UICamera = this.camera;
		DontDestroyOnLoad (this.gameObject);
        StartCoroutine(Load());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator Load() {
        AsyncOperation operation = Application.LoadLevelAsync("primary");
        yield return operation;
    }
}

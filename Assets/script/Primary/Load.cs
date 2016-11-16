using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	public string key;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Redo() {
        SceneManager.instance.index = 1;
		FindObjectOfType<Data> ().ResetModel ();
        SceneManager.instance.ExecuteOperation();
    }

    public void Remain() {
        SceneManager.instance.index = 1;
        StartCoroutine(OnMouseDown());
    }

	IEnumerator OnMouseDown(){
		AsyncOperation operation = Application.LoadLevelAsync (key);
		yield return operation;
	}
}

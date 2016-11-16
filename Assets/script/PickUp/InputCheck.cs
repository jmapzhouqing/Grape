using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputCheck : MonoBehaviour {
	private InputField field;
	public string correct;
	public bool error_stop;
	public string key;
	// Use this for initialization
	void Awake () {
		field = this.GetComponentInChildren<InputField> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}

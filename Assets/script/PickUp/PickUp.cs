using UnityEngine;
using System.Collections;
using System;

public class PickUp : MonoBehaviour {
    public Action callback;
    public string key;
    public string video_name;
    public bool error_stop;

	public virtual bool Error (){
		return false;
	}
}

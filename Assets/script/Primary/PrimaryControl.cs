using UnityEngine;
using System.Collections;

public class PrimaryControl : MonoBehaviour {

	void OnEnable(){
		UIRootManager.instance.RemoveChild (UIRootManager.instance.GetViewChild("control").transform);
	}
}

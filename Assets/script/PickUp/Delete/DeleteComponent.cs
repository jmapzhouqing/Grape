using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DeleteComponent : MonoBehaviour{
	private RaycastHit hit;
	private Ray ray;

	private Camera camera;
	// Use this for initialization
	void Awake () {
		camera = GameObject.Find("UICamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			print ("Hello");
			ray = camera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				print (hit.transform.name);
			}
		}
	}

	public void OnPointerClick(PointerEventData data){
		print ("Hello");
		GameObject.Destroy (this.gameObject);
	}
}

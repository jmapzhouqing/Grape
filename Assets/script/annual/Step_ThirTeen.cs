using UnityEngine;
using System.Collections;

namespace annual{
	public class Step_ThirTeen : MonoBehaviour {
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
					GameObject.Destroy(hit.transform.gameObject);
				}
			}
		}
	}
}

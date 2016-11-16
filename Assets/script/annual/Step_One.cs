using UnityEngine;
using System.Collections;

namespace annual{
	public class Step_One : MonoBehaviour {
		private RaycastHit hit;

		public string correct;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			LayerMask mask = 1 << LayerMask.NameToLayer ("annual_center");
			if(Physics.Raycast(ray,out hit,Mathf.Infinity,mask.value)){
				if(hit.transform.name.Equals(correct)){
					UIRootManager.instance.PlayVideo("",delegate {
						SceneManager.instance.ExecuteOperation();
					});
				}
			}
		}

        void OnEnable() {
            SceneManager.instance.ExecuteOperation();
        }
    }
}

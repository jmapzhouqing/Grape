using UnityEngine;
using System.Collections;

public class RandomCreate : MonoBehaviour {
	public float angle;

	public GameObject[] prefab_list;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		Create();
	}

	private void Create(){
		RemoveChild ();
		GameObject prefab = prefab_list [Random.Range (0, prefab_list.Length)];
		RectTransform child = (GameObject.Instantiate (prefab) as GameObject).GetComponent<RectTransform>();
		child.SetParent (this.transform);

		child.localScale = prefab.transform.localScale;
		child.localPosition = Vector3.zero;
		child.localEulerAngles = new Vector3 (0,angle,0);
	}

	private void RemoveChild(){
		for (int i=0; i<this.transform.childCount; i++) {
			GameObject.Destroy(this.transform.GetChild(i).gameObject);
		}
	}
}

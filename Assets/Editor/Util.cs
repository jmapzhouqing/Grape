using UnityEngine;
using UnityEditor;
using System.Collections;

public class Util:EditorWindow {
	[MenuItem("Util/AddMeshCollider")]
	public static void AddMeshCollider(){
		foreach (Renderer render in Selection.activeGameObject.GetComponentsInChildren<Renderer>()) {
			render.gameObject.AddComponent<MeshCollider>();
		}
	}
}

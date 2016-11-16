using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class SetObjectLightingMap:EditorWindow {

	static SetObjectLightingMap window = null;
	string path = "";
	string materialPath = "";
	int index;
	[MenuItem("Tools/Material/SetMaterialColor")]
	
	static void SetColor(){
		foreach (Renderer render in Selection.activeGameObject.GetComponentsInChildren<Renderer>()) {
			foreach(Material mat in render.sharedMaterials){
				mat.SetColor("_Color",Color.white);
			}
		}
	}


	[MenuItem("Tools/Material/SetObjectLightingMap")]
	
	static void Init(){
		window = (SetObjectLightingMap)EditorWindow.GetWindow(typeof(SetObjectLightingMap));
		window.position = new Rect(0, 0, 300, 100);
		window.Show();
	}
	
	void OnGUI(){
		
		EditorGUILayout.BeginHorizontal("Box");
		
		EditorGUILayout.LabelField("ImagePath: ",path);
		if(GUILayout.Button("Select",GUILayout.Width(60))){
			path = EditorUtility.OpenFolderPanel("ImageFolder",Application.dataPath,"");
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal("Box");
		
		EditorGUILayout.LabelField("MaterialPath: ",materialPath);
		if(GUILayout.Button("Select",GUILayout.Width(60))){
			materialPath = EditorUtility.OpenFolderPanel("MaterialFolder",Application.dataPath,"");
		}
		
		EditorGUILayout.EndHorizontal();
		
		
		if(GUILayout.Button("Close",GUILayout.Width(50),GUILayout.Height(20))){
			path = FileUtil.GetProjectRelativePath(path);
			materialPath = FileUtil.GetProjectRelativePath(materialPath);
			/*
			if(path.Contains(Application.dataPath)){
				path = path.Replace(Application.dataPath+"/","");
				
				if(path.Length<=9){
					if(path.Equals("Resources")){
						path = "";
					}else{
						path = EditorUtility.OpenFolderPanel("SelectFolder",Application.dataPath,"");
					}
				}else{
					if(path.Substring(path.Length-10,10).Equals("/Resources")){
						path = "";
					}else if(path.Substring(0,10).Equals("Resources/")){
						path = path.Substring(11,path.Length-11)+"/";
					}else{
						index = path.LastIndexOf("/Resources/");
						if(index!=-1){
							path = path.Substring(index+11,path.Length-(index+11))+"/";
						}else{
							path = EditorUtility.OpenFolderPanel("SelectFolder",Application.dataPath,"");
						}
						
					}
					
				}
				
			}else{
				path = EditorUtility.OpenFolderPanel("SelectFolder",Application.dataPath,"");
			}*/
			SetLightMaterial(path,materialPath);
			window.Close();
		}
	}
	
	
	
	
	static void SetLightMaterial(string folderPath,string materialPath){
		
		GameObject[] selectedObjects = Selection.gameObjects;
		
		foreach(GameObject child in selectedObjects){
			changeShader(child,folderPath,materialPath);
		}
	}
	
	
	static void changeShader(GameObject child,string folderPath,string materialPath){

		foreach(Renderer render in child.GetComponentsInChildren<Renderer>(true)){
			
			Material[] materials =  render.materials;

            string name = render.name;

            if (name.Contains("MeshPart")) {
                int index = name.IndexOf("MeshPart");
                name = name.Substring(0,index-1);
            }

			string fileName = Path.Combine(folderPath,name+"VRayCompleteMap.tga");

			Debug.Log(fileName);

			Texture2D _BaseTexture = AssetDatabase.LoadAssetAtPath(fileName,typeof(Texture2D)) as Texture2D;

			for(int i=0;i<materials.Length;i++){
				Material material = materials[i];
				Shader shader = material.shader;
				if(_BaseTexture!=null){
					Material copy = null;
					if("Diffuse".Equals(shader.name)){
						copy = new Material(Shader.Find("Legacy Shaders/Lightmapped/Diffuse"));

						copy.color = material.color;
						
						copy.SetTexture("_LightMap",_BaseTexture);	
						
						copy.SetTexture("_MainTex",material.mainTexture);
					}else if("Bumped Diffuse".Equals(shader.name)){
						copy = new Material(Shader.Find("Legacy Shaders/Lightmapped/Bumped Diffuse"));
						
						//copy.color = new Color(155.0F/255,155.0F/255,155.0F/255,155.0F/255);
						copy.color = material.color;

						copy.SetTexture("_LightMap",_BaseTexture);	
						
						copy.SetTexture("_MainTex",material.mainTexture);

						copy.SetTexture("_BumpMap",material.GetTexture("_BumpMap"));
					}else{
						copy = material;
					}

					string materialName = Path.Combine(materialPath,render.name+"_"+i+".mat");
					
					AssetDatabase.CreateAsset(copy,materialName);
					
					materials[i] = copy;
				}else{
					var copy = material;

					string materialName = Path.Combine(materialPath,render.name+"_"+i+".mat");

					AssetDatabase.CreateAsset(copy,materialName);
					
					materials[i] = copy;
				}
			}
			
			render.materials = materials;
		}
			//UnityEditor.Editor.Instantiate()
	}
}

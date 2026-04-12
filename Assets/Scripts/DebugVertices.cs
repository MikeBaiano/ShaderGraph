using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;

	void OnDrawGizmos()
	{
		if (vertices == null)
		{
			mesh = GetComponent<MeshFilter>().sharedMesh;
			vertices = mesh.vertices;
		}
		foreach (Vector3 v in vertices)
		{
			Vector3 viewVert = SceneView.GetAllSceneCameras()[0].GetComponent<Camera>().WorldToViewportPoint(transform.position + v);
			string vert = "v: " + v.ToString();
			string worldVert = " wv: " + (transform.position + v).ToString();
			string screenVert = " vv: " + viewVert.ToString();
            UnityEditor.Handles.Label(transform.position + v, vert + worldVert + screenVert);
		}
	}
}

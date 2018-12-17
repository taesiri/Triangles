using UnityEngine;

public class Colorify : MonoBehaviour
{

	private void LateUpdate()
	{
		VertsColor(gameObject);
	}

	public void VertsColor(GameObject selectedGameObject)
	{
		Mesh mesh = selectedGameObject.GetComponent<MeshFilter>().mesh;
		int[] triangles = mesh.triangles;	
		Vector3[] vertices = mesh.vertices;
		Vector3[] verticesModified = new Vector3[triangles.Length];
		int[] trianglesModified = new int[triangles.Length];
		var currentColor = new Color();
		var colors = new Color[triangles.Length];

		for (int i = 0; i < trianglesModified.Length; i++)
		{
			// Makes every vertex unique
			verticesModified[i] = vertices[triangles[i]];
			trianglesModified[i] = i;
			// Every third vertex randomly chooses new color
			if(i % 3 == 0){
				currentColor = new Color(
					Random.Range (0.0f, 1.0f),
					Random.Range (0.0f, 1.0f),
					Random.Range (0.0f, 1.0f),
					1.0f
				);
			}
			colors[i] = currentColor;
		}

		mesh.vertices = verticesModified;
		mesh.triangles = trianglesModified;
		mesh.colors = colors;
	}
}

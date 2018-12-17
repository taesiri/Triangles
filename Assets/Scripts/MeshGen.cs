using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
	public int GridX = 3;
	public int GridY = 3;

	void Start()
	{

		var vertices = new List<Vector3>();
		var colors = new List<Color>();

		
		for (int i = 0; i < GridX; i++)
		{
			for (int j = 0; j < GridY; j++)
			{
				vertices.Add(new Vector3(i + Random.Range(-0.1f, 0.1f), j + Random.Range(-0.1f, 0.1f),0));

//				if ((i + j) % 3 == 0)
//				{
//					colors.Add(new Color(0.87f, 0f, 0f));
//				}
//				else
//				{
//					colors.Add(new Color(1f,0.1f,0.1f,1.0f));
//				}
				
				
			}
		}

		var triangles = new List<int>();

		for (int i = 0; i < GridX - 1; i++)
		{
			for (int j = 0; j < GridY - 1; j++)
			{
				// Triangle 1  [i, j]  - [i, j+1] - [i+1, j+1] 
				triangles.Add(i * GridX + j);
				triangles.Add(i * GridX + (j + 1));
				triangles.Add((i + 1) * GridX + (j + 1));
				// Triangle 1  [i, j]  - [i+1, j+1] - [i+1, j] 
				triangles.Add(i * GridX + j);
				triangles.Add((i + 1) * GridX + (j + 1));
				triangles.Add((i + 1) * GridX + j);
			}
		}

		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = vertices.ToArray(); //newVertices;
		mesh.triangles = triangles.ToArray();
		mesh.colors = colors.ToArray();

		
	}
}
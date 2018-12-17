using System.Collections.Generic;
using UnityEngine;

public class TriangledGrid : MonoBehaviour
{

	public int GridX = 3;
	public int GridY = 3;
	public Color MasterColor = new Color(1f, 0.83f, 0f);
	public Color CurrentColor;
	public float ColorMultiplier = 3f;

	public float RandomRangeDown = 1f;
	public float RandomRangeUP = 1f;
	public float RandomRangeZUP = 1f;
	public float RandomRangeZDown = 1f;
	
	void Start()
	{
		var mm = 1 + (ColorMultiplier / 1000f);

		var triangles = new List<int>();
		var vertices = new List<Vector3>();
		var colors = new List<Color>();
		var vCounter = 0;

		var vPositions = new Vector3[GridX, GridY];

		CurrentColor = MasterColor;

		for (int i = 0; i < GridX; i++)
		{
			for (int j = 0; j < GridY; j++)
			{
				vPositions[i, j] = new Vector3(i + Random.Range(RandomRangeDown, RandomRangeUP), j + Random.Range(RandomRangeDown, RandomRangeUP),
					Random.Range(RandomRangeZDown,RandomRangeZUP));
			}
		}

		for (int i = 0; i < GridX - 1; i++)
		{
			for (int j = 0; j < GridY - 1; j++)
			{
				// create 6 vertices
				// create two pair of triangles
				// create 2 color

				var p0 = vPositions[i, j];
				var p3 = vPositions[i, j + 1];
				var p2 = vPositions[i + 1, j + 1];
				var p1 = vPositions[i + 1, j];

				vertices.Add(p0);
				vertices.Add(p3);
				vertices.Add(p2);

				CurrentColor = new Color(
					Mathf.Clamp((CurrentColor.r * mm)  , 0, 1f),
					Mathf.Clamp((CurrentColor.g * mm)  , 0, 1f),
					Mathf.Clamp((CurrentColor.b * mm)  , 0, 1f));

				colors.Add(CurrentColor);
				colors.Add(CurrentColor);
				colors.Add(CurrentColor);

				triangles.Add(vCounter);
				triangles.Add(vCounter + 1);
				triangles.Add(vCounter + 2);
				vCounter += 3;

				vertices.Add(p0);
				vertices.Add(p2);
				vertices.Add(p1);

				CurrentColor = new Color(
					Mathf.Clamp((CurrentColor.r * mm) , 0, 1f),
					Mathf.Clamp((CurrentColor.g * mm) , 0, 1f),
					Mathf.Clamp((CurrentColor.b * mm) , 0, 1f));

				colors.Add(CurrentColor);
				colors.Add(CurrentColor);
				colors.Add(CurrentColor);

				triangles.Add(vCounter);
				triangles.Add(vCounter + 1);
				triangles.Add(vCounter + 2);
				vCounter += 3;
			}
		}

		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = vertices.ToArray(); //newVertices;
		mesh.triangles = triangles.ToArray();
		mesh.colors = colors.ToArray();


	}
}
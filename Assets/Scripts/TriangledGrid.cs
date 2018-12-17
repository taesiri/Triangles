using System.Collections.Generic;
using UnityEngine;

public class TriangledGrid : MonoBehaviour
{

	public int GridX = 3;
	public int GridY = 3;
	public Color MasterColor = new Color(1f, 0.83f, 0f);

	public Color CornerA = Color.blue;
	public Color CornerB = Color.red;
	public Color CornerC = Color.green;


	public Color CurrentColor = Color.white;
	
	public float ColorMultiplier = 3f;

	public float RandomRangeDown = 1f;
	public float RandomRangeUP = 1f;
	public float RandomRangeZUP = 1f;
	public float RandomRangeZDown = 1f;

	
	void Start()
	{

	

		var triangles = new List<int>();
		var vertices = new List<Vector3>();
		var colors = new List<Color>();
		var vCounter = 0;

		var vPositions = new Vector3[GridX, GridY];

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

				var r1 = Mathf.Lerp(MasterColor.r, CornerB.r, (2f * i) / (3f * GridX));
				var r2 = Mathf.Lerp(MasterColor.r, CornerA.r, (2f * j) / (3f * GridY));
				var g1 = Mathf.Lerp(MasterColor.g, CornerB.g, (2f * i) / (3f * GridX));
				var g2 = Mathf.Lerp(MasterColor.g, CornerA.g, (2f * j) / (3f * GridY));
				var b1 = Mathf.Lerp(MasterColor.b, CornerB.b, (2f * i) / (3f * GridX));
				var b2 = Mathf.Lerp(MasterColor.b, CornerA.b, (2f * j) / (3f * GridY));

				CurrentColor = new Color(r1 + r2 / 2f, g1 + g2 / 2f, b1 + b2 / 2f, 1.0f);

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

				r1 = Mathf.Lerp(MasterColor.r, CornerB.r, (2f * i + 1f) / (3f * GridX));
				r2 = Mathf.Lerp(MasterColor.r, CornerA.r, (2f * j + 1f) / (3f * GridY));
				g1 = Mathf.Lerp(MasterColor.g, CornerB.g, (2f * i + 1f) / (3f * GridX));
				g2 = Mathf.Lerp(MasterColor.g, CornerA.g, (2f * j + 1f) / (3f * GridY));
				b1 = Mathf.Lerp(MasterColor.b, CornerB.b, (2f * i + 1f) / (3f * GridX));
				b2 = Mathf.Lerp(MasterColor.b, CornerA.b, (2f * j + 1f) / (3f * GridY));

				CurrentColor = new Color(r1 + r2 / 2f, g1 + g2 / 2f, b1 + b2 / 2f, 1.0f);

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
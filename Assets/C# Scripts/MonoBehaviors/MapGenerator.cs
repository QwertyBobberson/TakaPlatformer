using UnityEngine;


public class MapGenerator : MonoBehaviour 
{
	private static MapGenerator mg;
	[SerializeField] GameObject[] parts;

	private void Start()
	{
		mg = this;
	}

	public static void GenerateNextPiece(float spawnDistance)
	{
		Instantiate(mg.parts[Random.Range(0, mg.parts.Length)], new Vector3(spawnDistance, 0, 0), Quaternion.identity, null);
	}

}
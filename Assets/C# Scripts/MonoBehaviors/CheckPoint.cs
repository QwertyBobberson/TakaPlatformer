using UnityEngine;

public class CheckPoint : MonoBehaviour 
{
	private bool hasSpawned = false;

	private void OnTriggerEnter(Collider collision)
	{
		if (hasSpawned || GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;

		if (collision.transform.gameObject.tag == "Player")
		{
			hasSpawned = true;
			float largestX = 0;
			foreach (Transform obj in GetComponentInChildren<Transform>())
			{
				if (obj.lossyScale.x > largestX)
				{
					largestX = obj.lossyScale.x;
				}
			}

			MapGenerator.GenerateNextPiece(largestX/2 + transform.position.x + 60);
			GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Health>().score++;
		}
	}
}
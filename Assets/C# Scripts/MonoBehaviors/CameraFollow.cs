using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	//Sets distance from player and speed of camera
	[SerializeField] Vector3 offset;
	[SerializeField] int followSpeed;

	//Player variable
	private GameObject target;

	private void Start()
	{
		//Find the player
		target = GameObject.FindGameObjectWithTag("Player");
	}

	private void FixedUpdate()
	{
		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Put the camera in the right place
		Vector3 targetPosition = target.transform.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

		//Point the camera at the player
		transform.LookAt(target.transform);
	}
}
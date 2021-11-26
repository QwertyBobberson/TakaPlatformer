using UnityEngine;

public class MovingPlatform : MonoBehaviour 
{
	[SerializeField] int range;
	[SerializeField] Direction dir;
	[SerializeField] int speed;

	private GameObject player;
	private Vector3 origin;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	private void Update()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if (Mathf.Abs((origin - transform.position).magnitude) >= range)
		{
			speed *= -1;
		}

		transform.position += dir == Direction.RightAndLeft ? (Vector3.right * speed * Time.deltaTime) : (Vector3.up * speed * Time.deltaTime);

	}

	private void OnCollisionEnter(Collision collision)
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if (collision.transform.gameObject == player)
		{
			player.transform.parent = this.gameObject.transform;
		}
	}

	private void OnCollisionStay(Collision collision)
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if (collision.transform.gameObject == player)
		{
			player.transform.parent = this.gameObject.transform;
		}
	}

	private void OnCollisionExit(Collision collision)
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if (collision.transform.gameObject == player)
		{
			player.transform.parent = null;
		}
	}
}

public enum Direction{ RightAndLeft, UpAndDown};
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LandSharkEnemy : Enemy 
{
	[SerializeField] int speed;

	private GameObject target;
	private Rigidbody rb;
	private bool hasAttacked = false;

	private void Start()
	{
		//Do not kill or die when touching something
		dieOnTouch = false;
		killOnTouch = true;
		hasAttacked = false;

		//Get a refrence to the player and the rigidbody on this object
		target = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();
	}

	protected override void Attack()
	{
		if (hasAttacked || GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Move towards the player
		transform.LookAt(target.transform);

		rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
		transform.Rotate(new Vector3(0, 0, -transform.rotation.z));
	}


	private void LateUpdate()
	{
		if (transform.position.y < -5)
		{
			Destroy(gameObject);
		}

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (hasAttacked || GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;

		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Health>().health -= 1;
			hasAttacked = true;
		}
	}
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BomberEnemy : Enemy 
{
	[SerializeField] GameObject projectile;
	[SerializeField] float fireRate = 1;


	private GameObject target;
	private Rigidbody rb;
	private float timer = 0;

	
	private void Start()
	{
		//Do not kill or die when touching something
		dieOnTouch = false;
		killOnTouch = false;


		//Get a refrence to the player and the rigidbody on this object
		target = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();

		//Freeze the position of the turret, this is the only difference between the turret and the land shark
		rb.constraints = RigidbodyConstraints.FreezePosition;
	}

	protected override void Attack()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Look at target and fire a projectile every <fireRate> seconds
		timer += Time.deltaTime / fireRate;
		transform.LookAt(target.transform);
		if (timer >= 1)
		{
			Instantiate(projectile, transform.position + transform.forward * transform.localScale.z, transform.rotation, null);
			timer = 0;
		}
	}

	private void LateUpdate()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}
}
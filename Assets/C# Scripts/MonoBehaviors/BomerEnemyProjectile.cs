using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BomerEnemyProjectile : MonoBehaviour 
{
	//The strength the bomb is launched with and the strength of the explosion
	[SerializeField] int explosionSize;
	[SerializeField] int explosionForce;
	[SerializeField] int launchForce;
	[SerializeField] GameObject explosionEffect;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(Vector3.forward * launchForce * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Health>().health -= 1;
		}
		Collider[] colliderArray = Physics.OverlapSphere(transform.position, explosionSize);

		foreach (Collider collider in colliderArray)
		{
			Rigidbody rbOther = collider.transform.GetComponent<Rigidbody>();
			if (rbOther != null)
			{
				GameObject explosion = GameObject.Instantiate(explosionEffect, collision.contacts[0].point, Quaternion.Euler(collision.contacts[0].normal));
				rbOther.AddExplosionForce(explosionForce, transform.position, explosionSize);
				Destroy(explosion, 3);
			}
		}
		Destroy(gameObject);
	}

	private void LateUpdate()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}

}
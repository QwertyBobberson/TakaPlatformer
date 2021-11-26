using UnityEngine;

public class Enemy : MonoBehaviour 
{
	//Weather to kill the player or die when touched
	public bool killOnTouch = true;
	public bool dieOnTouch = false;

	private Vector3 distance;

	private void Update()
	{
		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		if ((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude < 100)
		{
			Attack();
		}
	}


	protected virtual void Attack()
	{

		//Never call base.Attack();
		throw new System.Exception("NotYetImplementedException");
	}
}
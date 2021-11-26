using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour 
{
	//Variables controlling mobility and max values
	[SerializeField] private int speed;
	[SerializeField] private int jumpHeight;
	[SerializeField] private int maxSpeed;
	[SerializeField] private int maxJumpSpeed;
	[SerializeField] private int maxJumps;
	[SerializeField] private int forceMultiplier;
	

	//Variables set through script
	private int jumps = 0;
	private Vector3 move = Vector3.zero;
	private Rigidbody rb;

	private void Start()
	{
		//Get a refrence to the rigidbody attached to the game object and stop the player from rotating
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	private void Update()
	{
		if (transform.position.y < -20)
		{
			gameObject.GetComponent<Health>().health--;
		}

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Turn the input into a vector and store it
		move = GetInput();
	}

	private void FixedUpdate()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Apply movement and limit speed values
		rb.AddForce(move * forceMultiplier);
		rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxJumpSpeed, maxJumpSpeed), 0);
	}

	private void LateUpdate()
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.75f);
	}

	private Vector3 GetInput()
	{
		//The vector to be returned 
		Vector3 _move = Vector3.zero;

		//Turns arrow keys and a/d into x = -1, 0, or 1
		_move.x = Input.GetAxisRaw("Horizontal") * speed;

		//Limits jumps to one click at a time and limits the number of jumps before touching the ground
		if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumps < maxJumps)
		{
			jumps++;
			_move.y = jumpHeight * jumps;
		}

		//return the input as a vector (x = -1, 0, or 1, y = 0 or 1, and z = 0)
		return _move;
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().gameOver)
			return;
		//Reset the number of jumps if on the ground
		if (collision.gameObject.tag == "Ground")
		{
			jumps = 0;
		}
	}

}
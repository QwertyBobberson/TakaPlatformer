using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotatingPlatform : MonoBehaviour 
{
	[SerializeField] int rotateSpeed;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.isKinematic = true;
	}

	private void Update()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 0, rotateSpeed));
	}



}
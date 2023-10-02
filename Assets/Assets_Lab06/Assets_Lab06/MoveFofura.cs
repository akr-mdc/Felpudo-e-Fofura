using System.Collections;
using UnityEngine;

public class MoveFofura : MonoBehaviour
{
	public Vector3 moveSpeed;
	public float spawnTime = 2f;
	public float spawnDelay = 2f;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start()
	{
		moveSpeed = Vector3.left * Time.deltaTime;
		originalPosition = transform.position; // Store the original position.
		InvokeRepeating("ChangeSpeed", spawnDelay, spawnTime);
	}

	void ChangeSpeed()
	{
		moveSpeed = new Vector3(Random.Range(-1, -2), 0, 0) * 0.03f;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += moveSpeed;
	}

	// OnTriggerEnter2D is called when the GameObject enters a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ResetPosition"))
		{
			// Reset the GameObject to its original position.
			transform.position = originalPosition;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFelpudo : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody2D rb;
	private Vector3 startPosition;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position; // Store the initial position of the character.
	}

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontal, vertical);
		rb.velocity = movement * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			// Reset the character to the original position.
			transform.position = startPosition;
			rb.velocity = Vector2.zero; // Reset velocity to zero.
		}
	}
}
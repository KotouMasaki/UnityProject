using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class test : MonoBehaviour
{
	private CharacterController characterController;
	private Vector3 velocity;
	[SerializeField]
	private float walkSpeed;
	[SerializeField]
	private float runSpeed;
	private float walk;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		walk = walkSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		if (characterController.isGrounded)
		{
			velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			if (velocity.magnitude > 0.1f)
			{
				animator.SetFloat("Speed", velocity.magnitude);
				transform.LookAt(transform.position + velocity);
			}
			else
			{
				animator.SetFloat("Speed", 0f);
			}
			if(Input.GetKey(KeyCode.Space))
            {
				walkSpeed = runSpeed;
				animator.SetFloat("Speed", 0f);
				animator.SetBool("Run", true);
            }
            else
            {
				walkSpeed = walk;
				animator.SetBool("Run", false);
				animator.SetFloat("Speed", velocity.magnitude);
			}
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * walkSpeed * Time.deltaTime);
	}
}

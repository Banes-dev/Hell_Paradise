using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    CharacterController Cac;
    Animator PlayerAnimator;

    public float speed = 6f;
    public float jump_speed = 8f;
    public float gravity = 9.81f;
    private Vector3 moveD = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerAnimator = GetComponent<Animator>();
        Cac = GetComponent<CharacterController>();
    }

    void Update()
    {
            // // Rotation by cursor
            Vector3 viewDir = transform.position - new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
            transform.forward = viewDir.normalized;
			// if (Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1 && Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1)
            // {
            //     Vector3 viewDir = transform.position - new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
            //     transform.forward = viewDir.normalized;
            // }

            // Calculate direction based on player input
            Vector3 inputDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

            // Sprint mode for Shift control
            if (speed != 6)
            {
                speed = 6f;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = speed * 2;
                PlayerAnimator.SetBool("run", true);
            }
            else
            {
                PlayerAnimator.SetBool("run", false); 
            }
            // Do the mouvement for the direction
            if (Input.GetAxis("Vertical") > 0.05 || Input.GetAxis("Vertical") < -0.05 && Input.GetAxis("Horizontal") > 0.05 || Input.GetAxis("Horizontal") < -0.05)
            {
                moveD = new Vector3(0, 0, 0);
                moveD = inputDir.normalized * (speed / 2);
            }
            else
            {
                moveD = new Vector3(0, 0, 0);
                moveD = inputDir.normalized * speed;
            }

            // Set status for animation
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                PlayerAnimator.SetBool("walk", true);
            }
            else
            {
                PlayerAnimator.SetBool("walk", false);
                PlayerAnimator.SetBool("run", false);
            }

			// Rotation by control
            if (inputDir.magnitude != 0f)
            {
                transform.rotation = Quaternion.LookRotation(inputDir);
            }

			if (Cac.isGrounded)
			{
				// Do the jump & set animation jump
				if (moveD.y < 0)
				{
					moveD.y = -1f;
				}
				if (Input.GetButton("Jump"))
				{
					PlayerAnimator.SetBool("jump", true);
					StartCoroutine(EndAnimJump());
					moveD.y = jump_speed;
				}
			}
			else
			{
				moveD.y -= gravity * Time.deltaTime;
			}

		Cac.Move(moveD * Time.deltaTime);
    }
	private IEnumerator EndAnimJump()
	{
		yield return new WaitForSeconds(0.8f);
		PlayerAnimator.SetBool("jump", false);
	}
}
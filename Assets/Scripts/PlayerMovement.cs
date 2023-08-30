using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D rb;

	[SerializeField] private float speed;
	[SerializeField] private FeetController feetController;
	[SerializeField] private GrabController grabController;
	[SerializeField] private float jumpSpeed;
	private bool isOnGround;
	private bool isGrabbing;
	private bool canJump;

	public Animator animator;
	[SerializeField] private AudioClip jumpClip;
	[SerializeField] private AudioClip grabClip;

	public bool canMove = true;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		canMove = true;
		feetController.OnGroundContact += OnGroundContact;
		grabController.OnGrab += OnGrab;
	}

	private void OnGrab(bool isGrabbing) {
		if (isGrabbing) {
			if (!isOnGround) {
				SfxManager.Instance.PlayClip(grabClip);
				canJump = true;
			}
			animator.SetTrigger("Grab");
		}
		else {
			if (!isOnGround) {
				animator.SetTrigger("Jump");
			}
		}
		this.isGrabbing = isGrabbing;
	}

	private void OnGroundContact(bool touchedGround) {
		isOnGround = touchedGround;
		canJump = touchedGround;
		animator.SetBool("Grounded", touchedGround);
	}

	private void Update() {
		float horizontalInput = Input.GetAxis("Horizontal");
		if (canMove) {
			rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

			//sprite a destra se vado a destra
			if (horizontalInput > 0.01f)
				transform.localScale = Vector3.one;

			//sprite a sinistra se vado a sinistra
			else if (horizontalInput < -0.01f)
				transform.localScale = new Vector3(-1, 1, 1);

			animator.SetBool("Run", horizontalInput != 0);
			//setto i parametri dell'animator, se premo destra o sinistra parte l'animazione
			if (!canJump) { }
			else {
				if (Input.GetKey(KeyCode.Space)) {
					Jump();
				}
			}
		}
		else {
			rb.velocity = Vector3.zero;
		}
	}

	private void Jump() {
		SfxManager.Instance.PlayClip(jumpClip);
		animator.SetTrigger("Jump");
		rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
		canJump = false;
	}
}
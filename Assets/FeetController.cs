using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour {
	public bool isOnGround;
	public event Action<bool> OnGroundContact;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			isOnGround = true;
			OnGroundContact?.Invoke(isOnGround);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			isOnGround = false;
			OnGroundContact?.Invoke(isOnGround);
		}
	}
}
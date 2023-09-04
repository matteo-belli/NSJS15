using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GrabController : MonoBehaviour {
	[FormerlySerializedAs("isOnGround")] public bool isGrabbing;
	public event Action<bool> OnGrab;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			isGrabbing = true;
			OnGrab?.Invoke(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			isGrabbing = false;
			OnGrab?.Invoke(false);
		}
	}
}
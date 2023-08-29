using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomScript : MonoBehaviour {
	public Collider2D shroomcollider; // Reference to the player's collider
	public GameObject objectsToActivate;
	public GameObject objectsToDeactivate;
	public GameObject Self;
	public GameObject OtherShroom;
	public AudioSource source;
	public AudioClip Shroms;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other != shroomcollider) {
			objectsToActivate.SetActive(true);

			objectsToDeactivate.SetActive(false);
			source.PlayOneShot(Shroms);

			Self.SetActive(false);
			OtherShroom.SetActive(true);
			MusicManager.Instance.SwitchToPsychedelic();
			PostProcessPsychedelic.Instance.isPsychedelic = true;
		}
	}
}
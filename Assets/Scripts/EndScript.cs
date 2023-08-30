using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

public class EndScript : MonoBehaviour {
	public AudioClip finalClip;

	private Animator anim;

	private PlayerMovement player;
	public Canvas canvasText;
	public Canvas canvasEnd;

	private void Awake() {
		canvasEnd.worldCamera = Camera.main;
		canvasEnd.enabled = false;
		canvasText.worldCamera = Camera.main;
		canvasText.enabled = false;
	}

	private void Start() {
		player = FindObjectOfType<PlayerMovement>();
		anim = player.GetComponent<Animator>();
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			canvasText.enabled = true;

			player.canMove = false;
			//playermovement.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
			//player.enabled = false;
			anim.SetBool("Grounded", true);
			anim.SetBool("Run", false);


			SfxManager.Instance.PlayClip(finalClip);
			StartCoroutine(DelayLittle());

			IEnumerator DelayLittle() {
				yield return new WaitForSeconds(5); //wait 5 secconds
				canvasText.enabled = false;
				canvasEnd.enabled = true;
				MusicManager.Instance.Stop();
				Application.Quit();
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		canvasEnd.enabled = false;
	}
}
using UnityEngine;
using Utility;

public class ShroomScript : MonoBehaviour {
	[SerializeField] private AudioClip pickupSound;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			SfxManager.Instance.PlayClip(pickupSound, 0.1f);
			MusicManager.Instance.SwitchToPsychedelic();
			PostProcessPsychedelic.Instance.isPsychedelic = true;
			WorldSwitcher.Instance.SwitchWorld(false);
		}
	}
}
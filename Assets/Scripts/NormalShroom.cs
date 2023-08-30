using UnityEngine;
using UnityEngine.Serialization;
using Utility;

public class NormalShroom : MonoBehaviour {
	public AudioClip pickupSound;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			SfxManager.Instance.PlayClip(pickupSound, 0.1f);
			MusicManager.Instance.SwitchToNormal();
			PostProcessPsychedelic.Instance.isPsychedelic = false;
			WorldSwitcher.Instance.SwitchWorld(true);
		}
	}
}
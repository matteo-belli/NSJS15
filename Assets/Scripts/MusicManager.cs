using UnityEngine;

public class MusicManager : MonoBehaviour {
	public static MusicManager Instance;
	public float maxPitch;
	public bool isPsychedelic;
	private AudioSource audioSource;

	private void Awake() {
		if (Instance != null) {
			Destroy(this);
		}
		else {
			Instance = this;
		}
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = 1;
	}

	public void SwitchToPsychedelic() {
		isPsychedelic = true;
	}

	public void SwitchToNormal() {
		isPsychedelic = false;
	}

	public void Stop() {
		audioSource.Stop();
	}

	private void Update() {
		if (isPsychedelic) {
			audioSource.pitch = 1 + maxPitch * Mathf.Sin(Time.time);
			Time.timeScale = 1 + maxPitch;
		}
		else {
			audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1, .2f);
			Time.timeScale = 1;
		}
	}
}
using UnityEngine;

public class WorldSwitcher : MonoBehaviour {
	public static WorldSwitcher Instance;
	[SerializeField] private GameObject[] normalWorldGameObjects;
	[SerializeField] private GameObject[] psychedelicWorldGameObjects;

	private void Awake() {
		if (Instance != null) {
			Destroy(this);
		}
		else {
			Instance = this;
		}
	}

	public void SwitchWorld(bool isNornmal) {
		foreach (var toActivate in normalWorldGameObjects) {
			toActivate.SetActive(isNornmal);
		}
		foreach (var toActivate in psychedelicWorldGameObjects) {
			toActivate.SetActive(!isNornmal);
		}
	}
}
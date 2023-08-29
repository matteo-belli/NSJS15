using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessPsychedelic : MonoBehaviour {
	public static PostProcessPsychedelic Instance;
	private Volume localVolume;
	public bool isPsychedelic;

	private void Awake() {
		if (Instance != null) {
			Destroy(this);
		}
		else {
			Instance = this;
		}
		localVolume = GetComponent<Volume>();
		localVolume.weight = 0;
	}

	private void Update() {
		if (isPsychedelic) {
			localVolume.weight = Mathf.Lerp(localVolume.weight, 1, 0.01f);
		}
		else {
			localVolume.weight = Mathf.Lerp(localVolume.weight, 0, 0.01f);
		}
	}
}
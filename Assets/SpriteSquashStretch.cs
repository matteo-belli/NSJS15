using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSquashStretch : MonoBehaviour {
	public float amount;
	public float speed;

	private void Update() {
		transform.localScale = new Vector2(1 + Mathf.Sin(Time.time * speed) * amount, 1 + Mathf.Cos(Time.time * speed) * amount);
	}
}
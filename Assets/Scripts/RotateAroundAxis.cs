using UnityEngine;

public class RotateAroundAxis : MonoBehaviour {
	public float speed;

	private void Update() {
		transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
using System;
using UnityEngine;

namespace Utility {
	public class SnapToGrid : MonoBehaviour {
		public bool localPosition;
		public Vector3 snap = Vector3.one;
		public SnapAxis snapAxis;

		private void OnDrawGizmos() {
			if (localPosition) {
				transform.localPosition = Snapping.Snap(transform.localPosition, snap, snapAxis);
			}
			else {
				transform.position = Snapping.Snap(transform.position, snap, snapAxis);
			}
		}

		private void Awake() {
			Destroy(this);
		}
	}
}
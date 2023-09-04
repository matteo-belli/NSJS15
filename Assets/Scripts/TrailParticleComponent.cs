using UnityEngine;

public class TrailParticleComponent : MonoBehaviour {
	private ParticleSystem particleSystem;
	[SerializeField] private SpriteRenderer playerSpriteRenderer;

	private void Awake() {
		particleSystem = GetComponent<ParticleSystem>();
	}

	private void Update() {
		var textureSheetAnimation = particleSystem.textureSheetAnimation;
		textureSheetAnimation.SetSprite(0, playerSpriteRenderer.sprite);
	}
}
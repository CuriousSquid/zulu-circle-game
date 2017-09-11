using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteProgressor : MonoBehaviour {

	[SerializeField]
	private List<Sprite> images;

	[SerializeField]
	private int index = 0;

	private SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	public void UpdateSprite() {
		sprite.sprite = images[index % images.Count];
	}
	
	public void Increment() {
		++index;
		UpdateSprite();
	}

	public void Decrement() {
		--index;
		UpdateSprite();
	}
}

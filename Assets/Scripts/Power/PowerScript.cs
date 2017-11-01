using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;



	private PowerScript power;

		// Use this for initialization
		void Start () {
		power = GetComponentInParent<PowerScript>();

		}
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D col)
	{
		{
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
			if (spriteRenderer.sprite == sprite1) {
				spriteRenderer.sprite = sprite2;
			} else {
				if (spriteRenderer.sprite == sprite2) {
					spriteRenderer.sprite = null;
				} else {
					if (spriteRenderer.sprite == null) {
						
					}	else{
					spriteRenderer.sprite = sprite1;

				}
					
}	
}
}

	}
}


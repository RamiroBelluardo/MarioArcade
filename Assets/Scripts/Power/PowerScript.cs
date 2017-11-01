using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;



	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D col)
	{if (col.gameObject.tag == "Player")
		{ 
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
			if (spriteRenderer.sprite == sprite1) {
				spriteRenderer.sprite = sprite2;
			} else {
				if (spriteRenderer.sprite == sprite2) {
					//spriteRenderer.sprite = null;
					Destroy (this.gameObject);

					}	else{
					spriteRenderer.sprite = sprite1;

				}
					
}	
}
}

	}



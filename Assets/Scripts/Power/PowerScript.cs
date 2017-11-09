using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	public AudioSource touchSound;



	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D col)
	{if (col.gameObject.tag == "Player")
		{ 
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
			if (spriteRenderer.sprite == sprite1) {
				touchSound.Play ();
				spriteRenderer.sprite = sprite2;
				allArounds ();
				CameraShake.Shake(0.08f, 0.08f);
			} else {
				if (spriteRenderer.sprite == sprite2) {
					allArounds ();
					touchSound.Play ();
					Destroy (this.gameObject);
					CameraShake.Shake(0.08f, 0.08f);

					}	else{
					touchSound.Play ();
					spriteRenderer.sprite = sprite1;
					allArounds ();
					CameraShake.Shake(0.08f, 0.08f);

				}
					
}	
}
}
	private void  allArounds(){

		GameObject[] enemyAll=GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject enemy in enemyAll) {
			enemy.SendMessage ("Around");
		}
	}
	}




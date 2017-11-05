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
				allArounds ();
				CameraShake.Shake(0.08f, 0.08f);
			} else {
				if (spriteRenderer.sprite == sprite2) {
					allArounds ();
					Destroy (this.gameObject);
					CameraShake.Shake(0.08f, 0.08f);

					}	else{
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




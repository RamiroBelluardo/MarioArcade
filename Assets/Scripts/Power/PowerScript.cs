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
	private void OnColliderEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			changeTheSprite ();
		}


	}
	void changeTheSprite(){

		if (power.GetComponent<SpriteRenderer>().sprite== sprite1) {
			power.GetComponent<SpriteRenderer>().sprite= sprite1 = sprite2;
		} else {
			power.GetComponent<SpriteRenderer>().sprite= sprite1;

	}
	}
	

}

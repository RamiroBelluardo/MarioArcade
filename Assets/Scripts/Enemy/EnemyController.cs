using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegsController : MonoBehaviour {
	
	public float maxSpeed=1f ;
	public float speed=1f ;
	private Rigidbody2D rb2d;

	void Start () {

		rb2d = GetComponent<Rigidbody2D>();

	}


    // Update is called once per frame
    void FixedUpdate () {
		rb2d.AddForce (Vector2.right * speed);
		float limiteVelocidad = Mathf.Clamp (rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limiteVelocidad, rb2d.velocity.y);
		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f) {
			speed = -speed;
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		}
		if (speed < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			//transform.GetChild(0).localScale= new Vector3(-1f, 1f, 1f);
		}
		if (speed > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			//transform.GetChild(0).localScale= new Vector3(1f, 1f, 1f);
		
		}
	}
		void CheckBounds(){
		//Chequear Tubos inferiores
		if (transform.position.x< -3.776f && transform.position.y< -1.807253f){
			speed = -speed;
			transform.position = new Vector2 (-3.897f, 0.21f);
			transform.localScale = new Vector3 (1f, 1f, 1f);

		}
		if (transform.position.x> -1.024f && transform.position.y< -1.807253f){
			speed = -speed;
			transform.position = new Vector2 (-0.896f, 0.21f);
			transform.localScale = new Vector3 (-1f, 1f, 1f);


		}
			
			if (transform.position.x < -3.9199f) {
				transform.position = new Vector2 (-0.8802f, transform.position.y);
			}
			if (transform.position.x > -0.8802f) {
				transform.position = new Vector2 (-3.9199f, transform.position.y);
			}


		}

	void Update(){
		CheckBounds ();
	}
		
	}




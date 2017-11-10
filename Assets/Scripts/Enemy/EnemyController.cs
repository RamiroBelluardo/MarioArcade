using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	
	public float maxSpeed=0.2f ;
	public float speed=0.2f ;
	private Rigidbody2D rb2d;
	public bool  isAround;
	private Animator myAnimator;
	public GameObject coin;
	public bool enemy2;

	void Start () {

		rb2d = GetComponent<Rigidbody2D>();
		isAround = false;
		myAnimator = GetComponent<Animator>();

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
		if (speed < 0.1f) {
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
		myAnimator.SetFloat("Speed", Mathf.Abs(speed));
		myAnimator.SetBool("isAround", isAround);
		myAnimator.SetBool ("enemy2", enemy2);
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

		if (transform.position.y < -2.01464f) {
			Destroy (this.gameObject);
		}
			
		}

	private void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") { 
			if (isAround) {
				GetComponent<BoxCollider2D> ().enabled = false;
				col.gameObject.SendMessage ("sumarScore");
				Instantiate(coin, transform.position, Quaternion.identity);
				Rigidbody2D coinrbd=coin.GetComponent<Rigidbody2D>();
				coinrbd.AddForce(new Vector2(Random.Range(3, -3), 7), ForceMode2D.Impulse);
			} else {
				col.gameObject.SendMessage ("Death");
			}
		}
	}
	private void isTriggerEnter2D(Collider2D col){


			if (col.gameObject.tag == "Enemy") { 
				speed = -speed;
			}


	}

	void Around(){
		isAround = !isAround;

		if (isAround) {
			maxSpeed = 0;
			speed = 0;
			StartCoroutine ("tiempo");
		} else {
			if (enemy2) {
				speed = 0.2f;
				maxSpeed = 0.2f;
				speed = -speed;
			} else {
				speed = 0.4f;
				maxSpeed = 0.4f;
				speed = -speed;
			}
		}

	}
	void Update(){
		CheckBounds ();

	}
		
	IEnumerator tiempo (){
		yield return new WaitForSeconds (5f);
		isAround = false;
		speed = 0.4f;
		maxSpeed = 0.4f;
		enemy2 = true;
	}

	}




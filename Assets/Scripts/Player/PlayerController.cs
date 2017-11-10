using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

		public float maxSpeed = 3f;
		public float speed = 3f;
		public bool tocandoPiso;
		public float fuerzaSalto = 3f;
		public GameManager game;
		public int score=0;
		public AudioSource jumpSound;
		public AudioSource dieSound;
		
		
		




		public Rigidbody2D myRigidbody2D;
		private Animator myAnimator;
		private bool jump;


		// Use this for initialization
		void Start()
		{
			myRigidbody2D = GetComponent<Rigidbody2D>();
			myAnimator = GetComponent<Animator>();

			
		}

		// Update is called once per frame
		void Update()
		{
		
				Movement();
				CheckBounds ();
		if (score == 3) {
			game.SendMessage ("Winner");
		}
			}

		private void Movement()
		{
			// Hacemos que cambie el sprite pero comprobando siempre contra un valor positivo (0.1).
			// Por eso usamos Abs (valor absoluto)

			myAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));
			myAnimator.SetBool("TocandoPiso", tocandoPiso);




			if (Input.GetKeyDown(KeyCode.UpArrow) && tocandoPiso)
			{
				jump = true;
			}

			




			// Clamp toma un valor y le aplica un filtro (un valor mínimo y un valor máximo)
			float limiteVelocidad = Mathf.Clamp(myRigidbody2D.velocity.x, -maxSpeed, maxSpeed);
			
			myRigidbody2D.velocity = new Vector2(limiteVelocidad, myRigidbody2D.velocity.y);

		if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
			myRigidbody2D.AddForce(Vector2.right * speed * 1);

			}
		if (Input.GetKey(KeyCode.LeftArrow))
			{
			myRigidbody2D.AddForce(Vector2.left* speed * 1);
				transform.localScale = new Vector3(-1f, 1f, 1f);
			}

			if (jump)
			{
			jumpSound.Play ();
			myRigidbody2D.velocity = new Vector2(limiteVelocidad, myRigidbody2D.velocity.y);
				myRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

				jump = false;
			}
		}

		private void FixedUpdate()
		{

			Vector3 fixedVelocity = myRigidbody2D.velocity;
			fixedVelocity.x *= 0.75f;

			if (tocandoPiso)
			{
				myRigidbody2D.velocity = fixedVelocity;
			}

			// Lo de arriba es para solucionar que no se mueva siempre, ya que pusimos
			// que las plataformas no tengan fricción.


		}

	void CheckBounds(){

		if (transform.position.x < -3.9199f) {
			transform.position = new Vector2 (-0.8802f, transform.position.y);
		}
		if (transform.position.x > -0.8802f) {
			transform.position = new Vector2 (-3.9199f, transform.position.y);
		}


	}
	void Death(){
		UpdateState("MarioMuerto");
		dieSound.Play ();
		game.SendMessage ("GameOver");
		GetComponent<PlayerController>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = false;

	}

	void UpdateState(string state  = null){
		if (state != null) {
			myAnimator.Play (state);


		}
	}
	public void sumarScore(){
		score+=1;
		}


}
		
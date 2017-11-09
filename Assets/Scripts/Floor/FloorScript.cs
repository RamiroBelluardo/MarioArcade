using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

	public GameObject anterior;
	public GameObject posterior;
	public List<GameObject> enemies=  new List<GameObject>();

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") { 
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.05f, transform.position.z);
			StartCoroutine ("tiempo");

			if (anterior != null) {
				anterior.transform.position = new Vector3 (anterior.transform.position.x, anterior.transform.position.y + 0.025f, anterior.transform.position.z);

				BoxCollider2D[] coll = anterior.GetComponents<BoxCollider2D> ();
				foreach(BoxCollider2D col1 in coll) {
					col1.GetComponent<BoxCollider2D>().enabled = false;

				}
				StartCoroutine ("tiempoAnterior");
			}
			if (posterior != null) {
				posterior.transform.position = new Vector3 (posterior.transform.position.x, posterior.transform.position.y + 0.025f, posterior.transform.position.z);
				BoxCollider2D[] coll = posterior.GetComponents<BoxCollider2D> ();
				foreach(BoxCollider2D col1 in coll) {
					col1.GetComponent<BoxCollider2D>().enabled = false;
				}
				StartCoroutine ("tiempoPosterior");
			}
		
		} 

	}

	private void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") { 
			col.gameObject.SendMessage ("Around");
		}
	
	}

		

	

	IEnumerator tiempo (){
		yield return new WaitForSeconds (0.3f);
		transform.position=new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z);

	}
	IEnumerator tiempoAnterior (){
		yield return new WaitForSeconds (0.3f);
		anterior.transform.position = new Vector3 (anterior.transform.position.x, anterior.transform.position.y - 0.025f, anterior.transform.position.z);
		BoxCollider2D[] coll = anterior.GetComponents<BoxCollider2D> ();
		foreach (BoxCollider2D col1 in coll) {
			col1.GetComponent<BoxCollider2D> ().enabled = true;

		}
	}
	IEnumerator tiempoPosterior (){
		yield return new WaitForSeconds (0.3f);
		posterior.transform.position=new Vector3(posterior.transform.position.x, posterior.transform.position.y-0.025f, posterior.transform.position.z);
			BoxCollider2D[] coll = posterior.GetComponents<BoxCollider2D> ();
			foreach(BoxCollider2D col1 in coll) {
				col1.GetComponent<BoxCollider2D>().enabled = true;

	}


}
}

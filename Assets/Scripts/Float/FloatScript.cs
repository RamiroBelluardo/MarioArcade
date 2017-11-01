using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{if (col.gameObject.tag == "Player")
		{ 
			transform.position=new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z);
			StartCoroutine ("tiempo");

			} 
	


}

	IEnumerator tiempo (){
		yield return new WaitForSeconds (0.5f);
		transform.position=new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z);

	}
}


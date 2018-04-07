using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private GameObject targetChara = null;
	private bool foundPlayerFlug = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
		if (foundPlayerFlug) {
			float x = 0f;
			float y = rb.velocity.y;
			float z = 0f;
			if (targetChara.transform.position.x < this.transform.position.x) {
				x = -2.1f;
			} else {
				x = 2.1f;
			}
			if (targetChara.transform.position.z < this.transform.position.z) {
				z = -2.1f;
			} else {
				z = 2.1f;
			}
			rb.velocity = new Vector3 (x, y, z);
		} else {
			rb.velocity = new Vector3 (0f, 0f, 0f);
		}
	}


	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			foundPlayerFlug = true;
			targetChara = col.gameObject;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			foundPlayerFlug = false;
			targetChara = null;
		}
	}


	void OnCollisionEnter(Collision col){
		if(targetChara != null && col.gameObject.tag == "Player"){
			Debug.Log ("ゲームオーバー");
			targetChara = col.gameObject;
		}
	}
}

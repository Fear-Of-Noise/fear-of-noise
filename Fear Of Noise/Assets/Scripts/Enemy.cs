using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private GameObject targetChara = null;
	private bool foundPlayerFlug = false;

	private const float EVENT_TIME = 3.0f;
	private float waitTime = 0;

	private int eventCnt = 0;

    private GameObject _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
		if (foundPlayerFlug) {
			if(waitTime>0){
				waitTime -= 0.01666f;
				return;
			}
			float x = 0f;
			float y = rb.velocity.y;
			float z = 0f;
			if (targetChara.transform.position.x + 0.1f < this.transform.position.x) {
				x = -2.1f;
			}
			if (targetChara.transform.position.x - 0.1f > this.transform.position.x) {
				x = 2.1f;
			}
			if (targetChara.transform.position.z + 0.1f < this.transform.position.z) {
				z = -2.1f;
			}
			if (targetChara.transform.position.z - 0.1f > this.transform.position.z) {
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
			if (eventCnt <= 0) {
				waitTime = EVENT_TIME;
				CameraControll.SetCameraEvent (this.gameObject, EVENT_TIME);
                Player pl = _player.GetComponent<Player>();
                pl.setWaitTime (EVENT_TIME);
				eventCnt++;
			}
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

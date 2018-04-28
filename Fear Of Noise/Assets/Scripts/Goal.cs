using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	bool isGoaled = false;
	int wait =30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isGoaled) {
			wait--;
		}
		if (wait <= 0) {
			SceneManager.LoadScene ("Top");
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			Debug.Log ("ゴール");
			isGoaled = true;
		}
	}
}

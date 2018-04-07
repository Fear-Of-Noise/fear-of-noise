using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 offset = Vector3.zero;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");

		if(_player != null){
			offset = this.transform.position - _player.transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
		//float x = _player.transform.position.x;
		//float y = _player.transform.position.y;
		//float z = this.gameObject.transform.position.z;

		Vector3 newPosition = this.transform.position;
		newPosition.x = _player.transform.position.x + offset.x;
		newPosition.y = _player.transform.position.y + offset.y;
		newPosition.z = this.gameObject.transform.position.z;

		this.gameObject.transform.position = newPosition;
	}
}

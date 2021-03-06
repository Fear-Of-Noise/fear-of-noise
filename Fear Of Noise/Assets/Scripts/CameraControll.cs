﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	private GameObject _player;
	private Vector3 offset = Vector3.zero;
	private static bool isEventTime =false;
	private static float eventTime = 0f;
	private static GameObject target;
    private const float CENTER_MARGIN= 3f;


	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");

		if(_player != null){
			offset = this.transform.position - _player.transform.position;
		}
	}

	void Update () {

		if(isEventTime){
			cameraEvent ();
			return;
		}

        Vector3 cameraPos = this.transform.position;
        Vector3 plPos = _player.transform.position;
        Vector3 newPosition = new Vector3(cameraPos.x, plPos.y + offset.y, cameraPos.z);
        if (plPos.x + offset.x - CENTER_MARGIN > cameraPos.x){

            newPosition.x = plPos.x + offset.x - CENTER_MARGIN;
        }
         if (plPos.x + offset.x + CENTER_MARGIN < cameraPos.x){

            newPosition.x = plPos.x + offset.x + CENTER_MARGIN;
        }
		this.gameObject.transform.position = newPosition;
	}

	public static void SetCameraEvent(GameObject go,float time){
		target = go;
		eventTime = time;
		isEventTime = true;
	}

    public static bool GetIsEventTime() {
        return isEventTime;
    }

	private void cameraEvent(){
		Vector3 targetPos = target.transform.position;
		Vector3 newPosition = this.transform.position;
		newPosition.x = targetPos.x + offset.x;
		newPosition.y = targetPos.y + offset.y;
		newPosition.z = this.gameObject.transform.position.z;
		if (eventTime > 0) {
			eventTime -= 0.01666f;
		}
		if (eventTime <= 0) {
			isEventTime = false;
			eventTime = 0f;
		}
		this.gameObject.transform.position = newPosition;
	}
}

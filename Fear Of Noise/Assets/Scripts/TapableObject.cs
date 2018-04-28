using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapableObject : MonoBehaviour{


    private GameObject _player;

    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTaped(){
        Player pl = _player.GetComponent<Player>();
        pl.setDestination(this.gameObject.transform.position);
        Debug.Log(this.gameObject.name+"がタップされました。");
        return ;
    }
}
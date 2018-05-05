using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    private const float RAY_RANGE = 15f;


    private bool playerInSearchArea = false;
	private bool foundPlayerFlug = false;

	private const float EVENT_TIME = 3.0f;
	private float waitTime = 0;

	private int eventCnt = 0;

    private GameObject _player;



    private int turnCnt = 0;



    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Player");
    }

    void searchTargetByRay()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 rayDir = (playerPos - transform.position).normalized;
        RaycastHit hit;
        int layerMask = (1 << LayerMask.NameToLayer("Default"));
        if (Physics.Raycast(transform.position, rayDir, out hit, RAY_RANGE, layerMask))
        {
            if(hit.collider.tag == _player.tag)
            {
                foundPlayerFlug = true;
                if (eventCnt <= 0)
                {
                    waitTime = EVENT_TIME;
                    CameraControll.SetCameraEvent(this.gameObject, EVENT_TIME);
                    Player pl = _player.GetComponent<Player>();
                    pl.setWaitTime(EVENT_TIME);
                    eventCnt++;
                }
            }
            else
            {
                foundPlayerFlug = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (playerInSearchArea)
        {
            searchTargetByRay();
        }

        if (waitTime > 0)
        {
            waitTime -= 0.01666f;
            return;
        }





        if(turnCnt%800 == 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else if(turnCnt%800 == 400)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        turnCnt++;



        Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
		if (foundPlayerFlug) {
			float x = 0f;
			float y = rb.velocity.y;
			float z = 0f;
			if (_player.transform.position.x + 0.1f < this.transform.position.x) {
				x = -2.1f;
			}
			if (_player.transform.position.x - 0.1f > this.transform.position.x) {
				x = 2.1f;
			}
			if (_player.transform.position.z + 0.1f < this.transform.position.z) {
				z = -2.1f;
			}
			if (_player.transform.position.z - 0.1f > this.transform.position.z) {
				z = 2.1f;
			}
			rb.velocity = new Vector3 (x, y, z);
		} else {
			rb.velocity = new Vector3 (0f, 0f, 0f);
		}
	}

    
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == _player.tag)
        {
            playerInSearchArea = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == _player.tag) {
            playerInSearchArea = false;
		}
	}
    

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == _player.tag)
        {
            SceneManager.LoadScene("GameOver");
		}
	}
}

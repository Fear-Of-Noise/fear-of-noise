using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    private const float MOVE_SPEED = 6f;
    private const float MOVE_MARGIN = 1;
    private float moveX = 0f;
    private float moveZ = 0f;
    private Rigidbody rb;

	private bool isWait = false;
	private float waitTime = 0f;

    private bool toDestination = false;
    private Vector3 destination = new Vector3();

    private bool isDirLeft = true;

    private NavMeshAgent agent;
    private Ray ray;

    void Start(){
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){

        // 
        if (CameraControll.GetIsEventTime()) {
            agent.SetDestination(gameObject.transform.position);
            return;
        }

        move();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                // マウスの位置からRayを発射して、
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 物体にあたったら、

                int layerMask = 1 << 8;
                if (Physics.Raycast(ray, out hit, 100f,layerMask))
                {
                    if (hit.collider.tag == "Ground") { 
                    // その場所に、Nav Mesh Agentをアタッチしたオブジェクトを移動させる
                    agent.SetDestination(hit.point);
                }

                }
            }
            //if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            //{
            //    Debug.Log(hit);
            //    Debug.Log(hit.point);
            //    gameObject.transform.position = new Vector3(hit.point.x, -5.5f, hit.point.z);
            //}
        }
        /*
		if(waitTime<=0){
			waitTime = 0f;
			isWait = false;
		}
		if (isWait) {
			waitTime -= 0.01666f;
			return;
		}

        moveX = Input.GetAxis("Horizontal") * MOVE_SPEED;
        moveZ = Input.GetAxis("Vertical") * MOVE_SPEED;
        */
    }


    private void move() {
        if (toDestination){
            setMoveVec();
        }

        Vector3 rotateVec = new Vector3();
        if (isDirLeft){
            rotateVec = new Vector3(20f, 0f, 0f); ;
        }else{
            rotateVec = new Vector3(-20f, 180f, 0f);
        }

        rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);
        this.gameObject.transform.rotation = Quaternion.Euler(rotateVec);
    }

    private void setMoveVec(){
        Vector3 plPos = this.gameObject.transform.position;
        if ((plPos.x - MOVE_MARGIN) > destination.x){
            moveX = -MOVE_SPEED;
            isDirLeft = true;
        }else if ((plPos.x + MOVE_MARGIN) < destination.x){
            moveX = MOVE_SPEED;
            isDirLeft = false;
        }else{
            moveX = 0f;
        }

        if ((plPos.z - MOVE_MARGIN) > destination.z){
            moveZ = -MOVE_SPEED;
        }else if ((plPos.z + MOVE_MARGIN) < destination.z){
            moveZ = MOVE_SPEED;
        }
        else{
            moveZ = 0f;
        }
    }

    public void setWaitTime(float time){
		waitTime = time;
		isWait = true;
	}

    public void setDestination(Vector3 pos){
        toDestination = true;
        destination = pos;
    }
}

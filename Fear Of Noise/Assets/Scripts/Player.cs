using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    private const float MOVE_SPEED = 6f;
    private const float MOVE_MARGIN = 1;
    private const float RAY_MAX_DISTANCE = 300f;

    private float moveX = 0f;
    private float moveZ = 0f;
    private Rigidbody rb;
    public Camera _mainCamera;

	private bool isWait = false;
	private float waitTime = 0f;
    private bool toDestination = false;
    private Vector3 destination = new Vector3();
    private bool isDirLeft = true;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void sendTapedGroundPos(Vector3 tapPos)
    {

        tapPos.z = 10.0f;
        Vector3 tapPosWP = Camera.main.ScreenToWorldPoint(tapPos);

        Vector3 angle = (tapPosWP - transform.position).normalized;

        Ray ray = _mainCamera.ScreenPointToRay(tapPos);
        RaycastHit hit;
        int layerMask = (1 << LayerMask.NameToLayer("Ground"));
        if (Physics.Raycast(ray, out hit, RAY_MAX_DISTANCE, layerMask))
        {
            setDestination(hit.point);
        }

    }



    void Update()
    {

        if(CameraControll.GetIsEventTime()){
            rb.velocity = new Vector3();
            return;
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                sendTapedGroundPos(mousePos);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch[] touches = Input.touches;
                Vector3 touchPos = touches[0].position;
                sendTapedGroundPos(touchPos);
            }
        }

        move();


    }


    private void move() {
        if (toDestination){
            setMoveVec();
        }

        Vector3 rotateVec = new Vector3();
        if (isDirLeft){
            rotateVec = new Vector3(-20f, 180f, 0f);
        }
        else{
            rotateVec = new Vector3(20f, 0f, 0f);
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

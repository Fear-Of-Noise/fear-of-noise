using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 300f;
    float moveX = 0f;
    float moveZ = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;
//		Vector3 direction = new Vector3(moveX, rb.velocity.y, moveZ);
    }

    void FixedUpdate()
    {
		rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);
    }
}

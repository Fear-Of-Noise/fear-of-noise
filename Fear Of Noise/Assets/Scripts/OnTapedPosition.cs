using UnityEngine;
using System.Collections;

public class OnTapedPosition : MonoBehaviour
{
    private Player _player;

	// Use this for initialization
	void Start()
	{
        _player = GameObject.Find("Player").GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            _player.setDestination(mousePosition);
            Debug.Log("LeftClick:" + mousePosition);
        }
	}
}

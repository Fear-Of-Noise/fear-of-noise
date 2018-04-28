using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    private ItemSlot itemSlot;
    private CanvasMessage canvasMessage;
    private Message messageWhenGot = new Message(new string[] { "鍵を入手しました。" , "メッセージを閉じます▼" });

    void Start () {

       



        canvasMessage = GameObject.Find("Canvas_Message").GetComponent<CanvasMessage>();
        itemSlot = GameObject.FindGameObjectWithTag("Item_Slot").GetComponent<ItemSlot>();
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            itemSlot.SetItemSlot(gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
    */

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(canvasMessage);
            itemSlot.SetItemSlot(gameObject.GetComponent<SpriteRenderer>().sprite);
            canvasMessage.setMessage(messageWhenGot);
            Destroy(gameObject);
        }
    }
}

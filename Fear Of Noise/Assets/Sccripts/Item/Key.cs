using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    private ItemSlot itemSlot;

    void Start () {
        itemSlot = GameObject.FindGameObjectWithTag("Item_Slot").GetComponent<ItemSlot>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            itemSlot.SetItemSlot(gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}

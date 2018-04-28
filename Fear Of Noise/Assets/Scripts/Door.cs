using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject Door_1;
    public GameObject Door_2;

    private ItemSlot itemSlot;
    private bool openFlag = false;

    // Use this for initialization
    void Start () {
        itemSlot = GameObject.FindGameObjectWithTag("Item_Slot").GetComponent<ItemSlot>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !openFlag)
        {
            if (itemSlot.KeySloItemFlag())
            {
                openFlag = true;
                itemSlot.UseItemSlot();
                Door_1.GetComponent<Animator>().SetTrigger("Open");
                Door_2.GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }
}

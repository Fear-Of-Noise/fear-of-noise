using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

    public GameObject itemSlot1;

    public bool KeySloItemFlag()
    {
        Debug.Log("key:"+itemSlot1.GetComponent<Image>().enabled);
        if (itemSlot1.GetComponent<Image>().enabled)
        {
            return true;
        }
        return false;
    }

    public void SetItemSlot(Sprite sprite)
    {
        if (!itemSlot1.GetComponent<Image>().enabled)
        {
            itemSlot1.GetComponent<Image>().sprite = sprite;
            itemSlot1.GetComponent<Image>().enabled = true;
        }
    }

    public void UseItemSlot()
    {
        if (itemSlot1.GetComponent<Image>().enabled)
        {
            Sprite sprite = new Sprite();
            itemSlot1.GetComponent<Image>().sprite = sprite;
            itemSlot1.GetComponent<Image>().enabled = false;
        }
    }
}

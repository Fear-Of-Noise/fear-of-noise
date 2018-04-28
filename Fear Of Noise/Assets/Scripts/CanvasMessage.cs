using UnityEngine;
using UnityEngine.UI;

public class CanvasMessage : MonoBehaviour {

	public Button button;
	public Text text;


    private int displayedTimeCnt = 0;
    private bool isDisplaying = false;
    private Message message = new Message("");

    private Canvas canvas;

	// Use this for initialization
	void Start () {
		button.GetComponent<Button>().onClick.AddListener(ButtOnClick);

        canvas = gameObject.GetComponent<Canvas>();
	}

    private void Update()
    {
    }



    void ButtOnClick() {
        if (! displayMessage())
        {
            canvas.enabled = false;
            displayedTimeCnt = 0;
        }
    }

    public void setMessage(Message receive)
    {
        message = receive;
        displayMessage();
    }

    private bool displayMessage()
    {
        if (!message.hasNext())
        {
            return false;
        }
        text.text = message.next();
        canvas.enabled = true;
        displayedTimeCnt = 0;
        isDisplaying = true;
        return true;
    }
}

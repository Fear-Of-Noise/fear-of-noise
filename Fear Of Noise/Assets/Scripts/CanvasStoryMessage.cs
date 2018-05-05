using UnityEngine;
using UnityEngine.UI;

public class CanvasStoryMessage : MonoBehaviour
{

    public Button button;
    public Text text;
    public GameObject face;
    public GameObject story;

    private StoryMessageManager storyMessageManager;
    private int displayedTimeCnt;
    private bool isDisplaying;
    private Message message = new Message("");
    private Canvas canvas;
    private int messageChange;

    // Use this for initialization
    void Start()
    {
        displayedTimeCnt = 0;
        messageChange = 0;
        isDisplaying = false;
        button.GetComponent<Button>().onClick.AddListener(ButtOnClick);
        canvas = gameObject.GetComponent<Canvas>();
        storyMessageManager = story.GetComponent<StoryMessageManager>();
        // ストーリーメッセージを取得
        message = storyMessageManager.GetMessageWhenGot();
        // 取得したメッセージを設定
        setMessage(message);
    }

    void ButtOnClick()
    {
        if (!displayMessage())
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
        // メッセージの変更した回数をカウント
        messageChange++;
        // メッセージの変更回数で画面に表示するキャラクター画像を変更する。
        if (storyMessageManager.ChangeFaceFlag(messageChange)) {
            // キャラクターの画像を変更する。
            SetFace(storyMessageManager.GetFace());
        }
        text.text = message.next();
        canvas.enabled = true;
        displayedTimeCnt = 0;
        isDisplaying = true;
        return true;
    }

    public void SetFace(Sprite sprite)
    {
        face.GetComponent<Image>().sprite = sprite;
        face.GetComponent<Image>().enabled = true;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class StoryMessage : MonoBehaviour, StoryMessageManager
{
    public GameObject face1;
    public GameObject face2;

    private Sprite sprite;

    private Message messageWhenGot = new Message(new string[] {
        "そこのあなた！！"
        ,"あやしげな格好をした変態が目の前に現れた!!" // プレイヤー
        ,"あなたが、女子高生探偵「ビッチ」？" 
        ,"あなたに仕事の依頼をしたいのだけど" 
        ,"私の友人が、自宅マンションで何者かに殺されてしまって"
        ,"私は、その犯人に心当たりがあるのだけど…"
        ,"証拠になる物が欲しいので彼女の部屋に忍び込んで証拠になる物を探して出して来て欲しい。"
        ,"ただ…最近、彼女の死んだ部屋で妙な噂を耳にするのだけど…"
        ,"やっぱり！なんでもない気にしないで！　それよりも依頼のほうお願いね。"
        ,"彼女の部屋は、マンションの一番奥の部屋だから、じゃ！"
        ,"何だかんだか、最後の言葉にすごくあやしげな気配を感じる…" // プレイヤー
    });

    public Message GetMessageWhenGot() {
        return messageWhenGot;
    }

    /// <summary>
    /// Changes the face flag.[会話シーンでのキャラクターの顔を変えるイベントをカウントしてフラグで判定する。]
    /// </summary>
    /// <returns><c>true</c>, if face flag was changed, <c>false</c> otherwise.</returns>
    /// <param name="changeCount">Change count.</param>
    public bool ChangeFaceFlag(int changeCount) {
        if (changeCount == 2) 
        {
            sprite = face1.GetComponent<SpriteRenderer>().sprite;
            return true;
        }
        else if (changeCount == 3) 
        {
            sprite = face2.GetComponent<SpriteRenderer>().sprite;
            return true;
        }
        else if (changeCount == 11)
        {
            sprite = face1.GetComponent<SpriteRenderer>().sprite;
            return true;
        }
        return false;
    }

    public Sprite GetFace() {
        return sprite;
    }
}

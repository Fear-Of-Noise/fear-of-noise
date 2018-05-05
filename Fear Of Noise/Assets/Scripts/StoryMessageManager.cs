using UnityEngine;

public interface StoryMessageManager
{
    Message GetMessageWhenGot();

    bool ChangeFaceFlag(int changeCount);

    Sprite GetFace();
}

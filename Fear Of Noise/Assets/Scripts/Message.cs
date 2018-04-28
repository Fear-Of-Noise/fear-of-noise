using System.Collections;
using System.Collections.Generic;

public sealed class Message{

    List<string> message = new List<string>();
    private int counter = 0;

    public Message(string text)
    {
        message.Add(text);
    }
    public Message(List<string> textList)
    {
        foreach (string text in message)
        {
            message.Add(text);
        }
    }
    public Message(string[] texts)
    {
        foreach (string text in texts)
        {
            message.Add(text);
        }
    }

    public bool hasNext()
    {
        if (counter >= message.Count)
        {
            return false;
        }
        return true;
    }
    public string next()
    {
        if (!hasNext())
        {
            return "";
        }
        int listNum = counter;
        counter++;
        return message[listNum];
    }
}

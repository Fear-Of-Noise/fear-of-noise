using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
        Invoke("LoadScene", 2.9f);
	}

    void LoadScene() 
    {
        SceneManager.LoadScene("2.5d");
    }
}

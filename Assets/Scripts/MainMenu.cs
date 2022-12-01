using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private UniversalAudio universalAudio;

    void Start()
    {
        universalAudio = GameObject.Find("Data").GetComponent<UniversalAudio>();
    }

    void Update()
    {
        
    }

    public void LoadGame()
    {
        universalAudio.PlayButtonSFX();
        SceneManager.LoadScene(6);
        //SceneManager.LoadScene(1);
    }
}

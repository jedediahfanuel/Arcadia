using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("pauseMenu").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // The number argument is
    // the index of scene loaded
    // in the build setting

    public void LoadStageD()
    {
        SceneManager.LoadScene(2);
        pauseMenu.Resume();
    }
    
    public void LoadStageE()
    {
        SceneManager.LoadScene(3);
        pauseMenu.Resume();
    }

    public void LoadStageJ()
    {
        SceneManager.LoadScene(4);
        pauseMenu.Resume();
    }

    public void LoadStageT()
    {
        SceneManager.LoadScene(5);
        pauseMenu.Resume();
    }

    public void LoadShop()
    {
        // SceneManager.LoadScene(5);
    }
}

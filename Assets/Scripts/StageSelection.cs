using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    
    public void LoadStageE()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadStageJ()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadStageT()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadShop()
    {
        // SceneManager.LoadScene(5);
    }
}

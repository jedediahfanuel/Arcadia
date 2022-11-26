using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClosePanel : MonoBehaviour
{
    public GameObject closingPanel;
    public TextMeshProUGUI finalScore;

    // Start is called before the first frame update
    void Start()
    {
        if (finalScore == null) Debug.LogError("The Closing Panel in -Canvas > closePanel (Script)- is NULL");
        if (finalScore == null) Debug.LogError("The Final Score in -Canvas > closePanel (Script)- is NULL");
        
        closingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelOn(int fScore)
    {
        closingPanel.SetActive(true);
        Time.timeScale = 0f;
        finalScore.text = "Score : " + fScore;
    }

    public void PanelOff()
    {
        closingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToSelection()
    {
        SceneManager.LoadScene(1);
    }
}

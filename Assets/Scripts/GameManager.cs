using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private ClosePanel closingPanel;
    private int score;

    [SerializeField]
    private AudioClip fuelSound;
    private AudioSource audioSource;

    void Start()
    {
        closingPanel = GameObject.Find("Canvas").GetComponent<ClosePanel>();

        // Make sure the stage is running on start
        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();
        CheckAudioSource();

        if (scoreText == null) Debug.LogError("The score text in -game manager- is NULL");
        
        score = 0;
        UpdateScore(0);
    }

    void Update()
    {
        
    }

    private void CheckAudioSource()
    {
        if (audioSource == null)
        {
            Debug.LogError("The audio source in the -game manager- is NULL || the audio source commponent have not been added before");
        }
        else
        {
            audioSource.clip = fuelSound;
        }
    }

    public void PlayFuelSound()
    {
        audioSource.PlayOneShot(fuelSound);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void EndOfStage()
    {
        // Do Something after the stage is finish
        // Save score, etc.
        Debug.LogError("The Final Score = " + score);

        closingPanel.PanelOn(score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    private int score;

    [SerializeField]
    private AudioClip fuelSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CheckAudioSource();

        if (scoreText == null) Debug.LogError("The score text in -game manager- is NULL");
        
        score = 0;
        UpdateScore(0);
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

    // Update is called once per frame
    void Update()
    {
        
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

        // After OK, 
        // Redirect to stage selection menu
        SceneManager.LoadScene(1);
    }
}

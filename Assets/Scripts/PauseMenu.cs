using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused;
    // AudioSource audioSource;

    void Start()
    {
        if (pauseMenuUI == null) Debug.LogError("The Pause Menu UI in -Canvas > pauseMenu (Script)- is NULL");

        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);

        PlayAudio();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
        
        PauseAudio();
    }

    public void PlayAudio()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void PauseAudio()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}

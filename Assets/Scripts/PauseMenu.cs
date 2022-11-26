using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

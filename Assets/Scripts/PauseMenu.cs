using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused;
    private UniversalAudio universalAudio;

    void Start()
    {
        if (pauseMenuUI == null) Debug.LogError("The Pause Menu UI in -Canvas > pauseMenu (Script)- is NULL");

        universalAudio = GameObject.Find("Data").GetComponent<UniversalAudio>();
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {

    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);
        universalAudio.PlayButtonSFX();

        PlayAudio();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
        PauseAudio();

        universalAudio.PlayButtonSFX();
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
        universalAudio.PlayButtonSFX();
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        universalAudio.PlayButtonSFX();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}

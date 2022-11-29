using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalAudio : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource audioSource;
    
    void Start()
    {
        CheckAudio();
    }

    void Update()
    {
        
    }

    private void CheckAudio()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("The audio source in the -Canvas- is NULL");
        if (buttonSound == null) Debug.LogError("The button sound in the -Canvas > UniversalAudio (Script)- is NULL");
    }

    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}

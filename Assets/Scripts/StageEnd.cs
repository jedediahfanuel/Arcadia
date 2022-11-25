using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("Audio source in -Music Object- is NULL");
    }

    // Update is called once per frame
    void Update()
    {
        // The stage is finish
        if (!audioSource.isPlaying)
        {
            // Do Something after the stage is finish
            // Save score, etc.
        }
    }
}

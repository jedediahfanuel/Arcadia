using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    AudioSource audioSource;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("Audio source in -Music Object- is NULL");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LoseCondition();
    }

    private void LoseCondition()
    {
        // The stage is finish
        if (!audioSource.isPlaying) gameManager.EndOfStage();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Perks : MonoBehaviour
{

    private bool isHealth;
    private float timeRemaining;
    private Jump player;
    private DataPersistance dataController;
    private int healthAmount;
    public TextMeshProUGUI healthText;

    [SerializeField]
    public AudioClip healthSound;
    public AudioClip debuffSound;
    private AudioSource audioSource;

    void Start()
    {
        if (healthText == null) Debug.LogError("The Health Text in -PowerUp > Perks (Script)- is NULL");

        isHealth = false;
        timeRemaining = 0;

        player = GameObject.Find("player").GetComponent<Jump>();
        
        dataController = GameObject.Find("Data").GetComponent<DataPersistance>();
        healthAmount = dataController.GetHealthPowerUp();

        healthText.text = healthAmount + "x";

        audioSource = GetComponent<AudioSource>();
        CheckAudioSource();
    }

    void Update()
    {
        HealthTimer();
    }

    private void CheckAudioSource()
    {
        if (audioSource == null) Debug.LogError("The audio source in the -PowerUp Object- is NULL");
    }

    public void HealthOn()
    {
        if (!isHealth && healthAmount > 0)
        {
            isHealth = true;
            timeRemaining = 10;
            healthAmount--;

            player.FreezeX();
            audioSource.PlayOneShot(healthSound);
            healthText.text = healthAmount + "x";
        }
    }

    private void HealthTimer()
    {
        if (isHealth && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0) 
            {
                isHealth = false;
                player.UnFreezeX();
                audioSource.PlayOneShot(debuffSound);
            }
        }
    }

    public bool GetIsHealth()
    {
        return isHealth;
    }

    public int GetHealthAmount()
    {
        return healthAmount;
    }
}

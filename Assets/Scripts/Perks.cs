using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Perks : MonoBehaviour
{

    private bool isHealth;
    private float timeRemaining;
    private int healthAmount;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeRemainingTMP;
    private Jump player;
    private DataPersistance dataController;

    [SerializeField]
    public AudioClip healthSound;
    public AudioClip debuffSound;
    private AudioSource audioSource;

    void Start()
    {
        isHealth = false;
        timeRemaining = 0;

        player = GameObject.Find("player").GetComponent<Jump>();
        dataController = GameObject.Find("Data").GetComponent<DataPersistance>();
        healthAmount = dataController.GetHealthPowerUp();

        SetupTMP();
        CheckAudioSource();
    }

    void Update()
    {
        HealthTimer();
    }

    private void SetupTMP()
    {
        if (healthText == null) Debug.LogError("The Health Text in -PowerUp > Perks (Script)- is NULL");
        healthText.text = healthAmount + "x";

        if (timeRemainingTMP == null) Debug.LogError("Time Remaining TMP in the -Canvas > PowerUp > Perks (Script)- is NULL");
        timeRemainingTMP.enabled = false;
    }

    private void CheckAudioSource()
    {
        audioSource = GetComponent<AudioSource>();
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

            timeRemainingTMP.enabled = true;
        }
    }

    private void HealthTimer()
    {
        if (isHealth && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeRemainingTMP.text = "Immunity " + timeRemaining + "s";

            if (timeRemaining <= 0) 
            {
                isHealth = false;
                player.UnFreezeX();
                audioSource.PlayOneShot(debuffSound);

                timeRemainingTMP.enabled = false;
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

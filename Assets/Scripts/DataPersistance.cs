using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SaveData()
    {
        PlayerPrefs.Save();
    }

    public void SetHighscoreStage(string stage, int newScore)
    {
        switch (stage)
        {
            case "D" or "E" or "J" or "T":
                if (GetHighscore(stage) < newScore)
                {
                    PlayerPrefs.SetInt(stage, newScore);
                }
                break;
            default:
                Debug.LogError("The stage name is invalid | HIGHSCORE");
                break;
        }
    }

    public void SetMoney(int newMoney)
    {
        PlayerPrefs.SetInt("M", newMoney);
    }

    public void SetHealthPowerUp(int newPowerUp)
    {
        PlayerPrefs.SetInt("H", newPowerUp);
    }

    public void SetCutscene(int finishWatch)
    {
        PlayerPrefs.SetInt("C", finishWatch);
    }

    public int GetHighscore(string stage)
    {
        return PlayerPrefs.GetInt(stage, 0);
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt("M", 0);
    }

    public int GetHealthPowerUp()
    {
        return PlayerPrefs.GetInt("H", 0);
    }

    public int GetCutscene()
    {
        return PlayerPrefs.GetInt("C", 0);
    }
}

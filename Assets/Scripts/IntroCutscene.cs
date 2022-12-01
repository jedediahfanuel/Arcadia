using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroCutscene : MonoBehaviour
{
    VideoPlayer video;
    private DataPersistance dataController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        dataController = GameObject.Find("Data").GetComponent<DataPersistance>();
        if (dataController.GetCutscene()==0)
        {
            Debug.Log("cek");
            dataController.SetCutscene(1);
            video = GetComponent<VideoPlayer>();
            video.Play();
            video.loopPointReached += CheckOver;
        } else {
            SceneManager.LoadScene(1);
        }
    }

     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

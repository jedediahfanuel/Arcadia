using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidBack : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {       
                Application.Quit();
 
                return;
            }
        }
    }
}

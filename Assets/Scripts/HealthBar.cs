using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public ProgressBar pb;
    public int value = 100;
    float elapsed = 0f;

    void Start()
    {
        pb.BarValue = value;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f) {
            elapsed = elapsed % 1f;
            pb.BarValue = pb.BarValue - 3;
        }
        // Debug.Log(pb.BarValue);
        // pb.BarValue = pb.BarValue - (float)0.1;
    }

    public void AddProgressBar(int n)
    {
        pb.BarValue = pb.BarValue + n;
    }
}

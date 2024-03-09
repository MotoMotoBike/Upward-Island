using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject[] indicators;
    public void UpdateHealth(int value)
    {
        foreach (var indicator in indicators)
        {
            indicator.SetActive(false);
        }

        for (int i = 0; i < value;i++)
        {
            indicators[i].SetActive(true);
        }
    }
}

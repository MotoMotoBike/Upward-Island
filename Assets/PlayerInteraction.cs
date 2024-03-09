using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent<int> OnGetDamage;
    public UnityEvent OnDeath;
    public UnityEvent OnFinish;
    public UnityEvent<string> OnGetCoinn;
    [SerializeField] private int oneCoinValue;
    
    int coins = 0;
    int health = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            OnDeath?.Invoke();
        }
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins += oneCoinValue;
            OnGetCoinn?.Invoke(coins.ToString());
        }
        if (other.CompareTag("Damage"))
        {
            Destroy(other.gameObject);
            if (health == 0)
            {
                OnDeath?.Invoke();
            }
            OnGetDamage?.Invoke(--health);
        }
        if (other.CompareTag("Finish"))
        {
            SaveData.SetScoreByLevelID(SaveData.SelectedLevel,coins);
            OnFinish?.Invoke();
        }
    }
}

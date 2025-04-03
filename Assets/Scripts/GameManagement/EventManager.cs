using UnityEngine;
using System;

public  class  EventManager :MonoBehaviour
{
    //Health Events
    public event Action <int> HealthChangeEvent;
    public event Action<int> MaxHealthChangeEvent;
    public event Action<int,int> HealthChangeForUiEvent;
    //Boost Events
    public event Action<BoostEnum, float , float > buffwithPercentageEvent;

    //Ui Events
    public event Action<int> MaxHealthBarUpdateEvent;
    public event Action<int> HealthBarUpdateEvent;
    public event Action<int> ScoreUpdateEvent;
    //Dead Events
    public event Action CharacterDeadEvent;
    public event Action<GameObject> EnemyDeadEvent;
    public event Action<GameObject> DestroyObject;

    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne deðiþse bile yok olmasýn
        }
        else
        {
            Destroy(gameObject); // Zaten bir instance varsa, yenisini yok et
        }
    }

    // Update is called once per frame

     public void Heal_EventDetected(int healAmount)
    {
        HealthChangeEvent?.Invoke(healAmount);
    }
    public void MaxHeal_EventDetected(int healAmount)
    {
        MaxHealthChangeEvent?.Invoke(healAmount);
    }
    public void HealthUi_EventDetected(int health,int maxHealth)
    {
        HealthChangeForUiEvent?.Invoke(health, maxHealth);
    }
    public void HealthBar_EventDetected(int healAmount)
    {
        HealthBarUpdateEvent?.Invoke(healAmount);
    }
    public void MaxHealBar_EventDetected(int healAmount)
    {
        MaxHealthBarUpdateEvent?.Invoke(healAmount);
    }
    public void Score_EventDetected(int ScoreAmount)
    {
        ScoreUpdateEvent?.Invoke(ScoreAmount);
    }
    public void DestroyTheObject(GameObject destroyedCharacter)
    {
        DestroyObject?.Invoke(destroyedCharacter);
    }
    public void CharacterDead_EventDetected()
    {
        CharacterDeadEvent?.Invoke();
    }
    public void EnemyDead_EventDetected(GameObject DiedCharacter)
    {
        EnemyDeadEvent?.Invoke(DiedCharacter);
    }
    public void percentageBuff_EventDetected(BoostEnum boosType, float percentage, float time)
    {
        buffwithPercentageEvent(boosType, percentage, time);
    }

   
}

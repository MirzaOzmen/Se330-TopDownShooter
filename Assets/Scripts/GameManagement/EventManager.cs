using UnityEngine;
using System;

public  class  EventManager :MonoBehaviour
{
    public event Action <int> HealthChangeEvent;
    public event Action<int> MaxHealthChangeEvent;
    public event Action<float, float> AttackSpeedChangeEvent;
    public event Action<int> MaxHealthBarUpdateEvent;
    public event Action<int> HealthBarUpdateEvent;
    public event Action<int> ScoreUpdateEvent;
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

     public void Heal_EventDetected(GameObject Character ,int healAmount)
    {
        HealthChangeEvent?.Invoke(healAmount);
    }
    public void MaxHeal_EventDetected(int healAmount)
    {
        MaxHealthChangeEvent?.Invoke(healAmount);
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
    public void DestroyTheObject(GameObject diedObject)
    {
        DestroyObject?.Invoke(diedObject);
    }
    public void AttackSpeed_EventDetected(float percentage,float Time)
    {
        AttackSpeedChangeEvent?.Invoke(percentage, Time);
    }
    public void CharacterDead_EventDetected()
    {
        CharacterDeadEvent?.Invoke();
    }
    public void EnemyDead_EventDetected(GameObject gameobject)
    {
        EnemyDeadEvent?.Invoke(gameobject);
    }
   
}

using UnityEngine;

public class CharacterHealth : MonoBehaviour , Damageble
{
    [SerializeField] public int CharacterMaxHealth;
    [SerializeField] public int CharacterCurrentHealth;
    [SerializeField] private bool isPlayer;
    [SerializeField] private TeamEnum team;
    public TeamEnum Team => team;
    
  

    private void Start()
    {
       
        EventManager.Instance.MaxHealBar_EventDetected(CharacterMaxHealth);

        EventManager.Instance.HealthBar_EventDetected(CharacterCurrentHealth);

    }
    private void OnEnable()
    {
    
        EventManager.Instance.MaxHealthChangeEvent += IncreaseMaxHealth;
        EventManager.Instance.HealthChangeEvent += ChangeHealthOfTheCharacter;
        //  Debug.Log("Healeventidinliyor");
    }
    private void OnDisable()
    {
        
        EventManager.Instance.MaxHealthChangeEvent -= IncreaseMaxHealth;
        EventManager.Instance.HealthChangeEvent -= ChangeHealthOfTheCharacter;
    }
    
    private void Update()
    {
     //   Debug.Log("current Health = " + CharacterCurrentHealth + " Max Health = " + CharacterMaxHealth);
    }
    public void ChangeHealthOfTheCharacter(int amount)
    {
       // Debug.Log("HealTetiklendi");
      
            CharacterCurrentHealth += amount;
            if (CharacterCurrentHealth > CharacterMaxHealth) CharacterCurrentHealth = CharacterMaxHealth;
            if (isPlayer) EventManager.Instance.HealthBar_EventDetected(CharacterCurrentHealth);
        if (CharacterCurrentHealth <= 0)
        {
            EventManager.Instance.CharacterDead_EventDetected();
            Destroy(gameObject);
        }

    }
    public void IncreaseMaxHealth(int amount)
    {
        CharacterMaxHealth += amount;
        if (isPlayer) EventManager.Instance.MaxHealBar_EventDetected(CharacterMaxHealth);

    }
}

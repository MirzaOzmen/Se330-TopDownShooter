using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] public int CharacterMaxHealth;
    [SerializeField] public int CharacterCurrentHealth;
  

    private void Start()
    {

        EventManager.Instance.MaxHealBar_EventDetected(CharacterMaxHealth);

        EventManager.Instance.HealBar_EventDetected(CharacterCurrentHealth);

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

        EventManager.Instance.HealBar_EventDetected(CharacterCurrentHealth);

    }
    public void IncreaseMaxHealth(int amount)
    {
        CharacterMaxHealth += amount;
        EventManager.Instance.MaxHealBar_EventDetected(CharacterMaxHealth);

    }
}

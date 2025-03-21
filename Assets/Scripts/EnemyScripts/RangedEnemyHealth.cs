using UnityEngine;

public class RangedEnemyHealth : MonoBehaviour,Damageble
{
    [SerializeField] public int CharacterMaxHealth;
    [SerializeField] public int CharacterCurrentHealth;

    [SerializeField] private TeamEnum team;
    public TeamEnum Team => team;



    private void Update()
    {
        //   Debug.Log("current Health = " + CharacterCurrentHealth + " Max Health = " + CharacterMaxHealth);
    }
    public void ChangeHealthOfTheCharacter(int amount)
    {
        // Debug.Log("HealTetiklendi");

        CharacterCurrentHealth += amount;
        if (CharacterCurrentHealth > CharacterMaxHealth) CharacterCurrentHealth = CharacterMaxHealth;

        if (CharacterCurrentHealth <= 0)
        {
            EventManager.Instance.EnemyDead_EventDetected(gameObject);
            Destroy(gameObject);
        }



    }
}

using UnityEngine;

public class ExplosiveBarrelHealth : MonoBehaviour , Damageble
{
    [SerializeField] private int CharacterMaxHealth;
    [SerializeField] private int CharacterCurrentHealth;
   
    [SerializeField] private ExplosiveBarrelAnim ExplosiveBarrelAnimObject;

    [SerializeField] private TeamEnum team;
    public TeamEnum Team => team;


    private void Start()
    {
        if(ExplosiveBarrelAnimObject == null)
        {
            ExplosiveBarrelAnimObject = GetComponent<ExplosiveBarrelAnim>();
        }
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

        ExplosiveBarrelAnimObject.updateDamgeAmount(CharacterCurrentHealth, CharacterMaxHealth);

        if (CharacterCurrentHealth <= 0)
        {
            Debug.Log("düsman öldü");

          StartCoroutine(ExplosiveBarrelAnimObject.BlowUp(1));
           // Destroy(gameObject,2);
        }






    }
}

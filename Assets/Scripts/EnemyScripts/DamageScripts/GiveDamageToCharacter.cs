using UnityEngine;

public class GiveDamageToCharacter : MonoBehaviour
{
    [SerializeField] private int DamageAmount;
    // [SerializeField] private bool GonnaDestroy; //characters after gonna destroy collide with player;
    [SerializeField] private TeamEnum myTeam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*  if (collision.TryGetComponent<CharacterHealth>(out CharacterHealth HealTheCharacter))//its more safe and if there is not a componnent dont cause null error https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.TryGetComponent.html
          {
              HealTheCharacter.HealTheCharacter(HealAmount);
          } */
        
        if (collision.TryGetComponent<Damageble>(out Damageble damageble))
        {
            if(myTeam != damageble.Team)
            {
                damageble.ChangeHealthOfTheCharacter(-1*DamageAmount);
                GameObject.Destroy(gameObject);
               
            }
          
        }
        else // wall etc.
        {
            GameObject.Destroy(gameObject);
        }
     } 
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Damageble>(out Damageble damageble))
        {
            if (myTeam != damageble.Team)
            {
                damageble.ChangeHealthOfTheCharacter(DamageAmount);
                GameObject.Destroy(gameObject);

            }

        }
    }*/
}

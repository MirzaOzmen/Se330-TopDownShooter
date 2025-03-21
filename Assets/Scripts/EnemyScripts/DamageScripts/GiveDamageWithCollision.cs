using UnityEngine;

public class GiveDamageWithCollision : MonoBehaviour
{
    [SerializeField] private int DamageAmount;
    // [SerializeField] private bool GonnaDestroy; //characters after gonna destroy collide with player;
    [SerializeField] private TeamEnum myTeam;
   
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.TryGetComponent<Damageble>(out Damageble damageble))
         {
             if (myTeam != damageble.Team)
             {

                Debug.Log("colidlandi");
                damageble.ChangeHealthOfTheCharacter(-1*DamageAmount);
                


             }

         }
     }
}


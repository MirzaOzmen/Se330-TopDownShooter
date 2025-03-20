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
        Damageble damageble = collision.gameObject.GetComponent<Damageble>();
        if (damageble != null)
        {
            if(myTeam != damageble.Team)
            {
                EventManager.Instance.Heal_EventDetected(collision.gameObject, DamageAmount);
                Destroy(gameObject);
            }
          
        }
    }
}

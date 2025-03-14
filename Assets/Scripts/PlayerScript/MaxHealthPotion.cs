using UnityEngine;

public class MaxHealthPotion : MonoBehaviour
{
    
    [SerializeField] private int HealAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*  if (collision.TryGetComponent<CharacterHealth>(out CharacterHealth HealTheCharacter))//its more safe and if there is not a componnent dont cause null error https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.TryGetComponent.html
          {
              HealTheCharacter.IncreaseMaxHealth(HealAmount);
          }*/
        if (collision.gameObject.tag == "Player")
        {
            EventManager.Instance.MaxHeal_EventDetected(HealAmount);
        }
    }
}

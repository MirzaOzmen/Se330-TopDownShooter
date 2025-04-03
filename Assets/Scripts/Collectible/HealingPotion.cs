using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int HealAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      /*  if (collision.TryGetComponent<CharacterHealth>(out CharacterHealth HealTheCharacter))//its more safe and if there is not a componnent dont cause null error https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.TryGetComponent.html
        {
            HealTheCharacter.HealTheCharacter(HealAmount);
        } */
      if(collision.gameObject.tag =="Player")
        {
            EventManager.Instance.Heal_EventDetected(HealAmount);
        }
    }
}

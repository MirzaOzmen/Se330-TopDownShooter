using UnityEngine;

public class AttackSpeedPotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float AttackSpeedBoostPersentage;
    [SerializeField] private float BoostTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*  if (collision.TryGetComponent<CharacterHealth>(out CharacterHealth HealTheCharacter))//its more safe and if there is not a componnent dont cause null error https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.TryGetComponent.html
          {
              HealTheCharacter.IncreaseMaxHealth(HealAmount);
          }*/
        if (collision.gameObject.tag == "Player")
        {
            EventManager.Instance.AttackSpeed_EventDetected(AttackSpeedBoostPersentage, BoostTime);
        }
    }
}

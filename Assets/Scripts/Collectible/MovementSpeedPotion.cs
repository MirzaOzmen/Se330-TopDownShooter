using UnityEngine;

public class MovementSpeedPotion : MonoBehaviour
{
    
    [SerializeField] private float MovementSpeedBoostPersentage;
    [SerializeField] private float BoostTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {     

            EventManager.Instance.percentageBuff_EventDetected(BoostEnum.movementSpeed, MovementSpeedBoostPersentage, BoostTime);
        }
    }
}

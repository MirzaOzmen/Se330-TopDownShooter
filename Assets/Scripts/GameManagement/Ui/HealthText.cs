using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText; 
    private void OnEnable()
    {
        EventManager.Instance.HealthChangeForUiEvent += updateHealthText;
       
    }
    private void OnDisable()
    {
        EventManager.Instance.HealthChangeForUiEvent -= updateHealthText;
    }

   
    private void updateHealthText(int health,int maxHealth)
    {
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }
  
}

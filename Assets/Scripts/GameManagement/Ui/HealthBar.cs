using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider HealthBarSlider;
    [SerializeField] private RectTransform background;
    

    void Start()
    {
    
    }
    private void OnEnable()
    {
        EventManager.Instance.MaxHealthBarUpdateEvent += UpdateMaxHealthBar;
        EventManager.Instance.HealthBarUpdateEvent += updateHealthBar;
    }
    private void OnDisable()
    {
        EventManager.Instance.MaxHealthBarUpdateEvent -= UpdateMaxHealthBar;
        EventManager.Instance.HealthBarUpdateEvent -= updateHealthBar;
    }

    public void updateHealthBar(int Health)
    {

        Debug.Log("bar updated"+" can = " + Health);
        HealthBarSlider.value = Health;
        
    }
    public void UpdateMaxHealthBar(int maxHealth)
    {
        Debug.Log("Max bar updated" + " can = " + maxHealth);
        HealthBarSlider.maxValue = maxHealth;
        if(maxHealth>100)
        {
            background.localScale = new Vector3(background.localScale.x + 0.10f, background.localScale.y, background.localScale.z);
        }
      
       
    }
}

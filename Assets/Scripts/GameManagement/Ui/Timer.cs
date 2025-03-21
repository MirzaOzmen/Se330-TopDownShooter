using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{

    
    [SerializeField] private TMP_Text TimerText;
    /////
   
    public float TimerCount = 0;
    void Update()
    {
        TimerCount += Time.deltaTime;


        TimerText.text = "Timer = " + ((int)TimerCount).ToString();

      
    }
 
}

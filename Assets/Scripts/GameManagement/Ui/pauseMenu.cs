using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuGo;
    private bool isMenuActive = false;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            menuActivate();

        }
        
    }
    public void menuActivate()
    {
       
            isMenuActive = !isMenuActive;
        if (isMenuActive) Time.timeScale = 0; // if u stoped the time and gonna change the scene dont forget the timecale = 1 because if u dont do that timescale stil 0 in the other scewne
        else Time.timeScale = 1;  
            PauseMenuGo.SetActive(isMenuActive);

        
    }
}

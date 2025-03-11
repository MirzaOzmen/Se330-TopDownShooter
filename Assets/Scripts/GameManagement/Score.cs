using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private TMP_Text TimerText;
    /////
    private int totalScore = 0 ;
    private float Timer = 0;
    void Update()
    {
        Timer += Time.deltaTime;

        
        TimerText.text = "Timer = " + ((int)Timer).ToString();

        if (Input.GetButtonDown("Fire1")) // for test 
        {
            ChangeScore(1);
        }
    }
    public void ChangeScore(int Score)
    {
        totalScore += Score;
        totalScoreText.text = "Score = " + totalScore.ToString();
    }
}

using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    [SerializeField] private TMP_Text totalScoreText;

    /////
    public int totalScore = 0 ;

    private void OnEnable()
    {
        //trigered with enemy Death
    }
    private void OnDisable()
    {
        
    }
    void Update()
    {

        /* if (Input.GetButtonDown("Fire1")) // for test 
         {
             ChangeScore(1);
         }*/
       
    }
    public void ChangeScore(int Score)
    {
        totalScore += Score;
        totalScoreText.text = "Score = " + totalScore.ToString();
    }
}

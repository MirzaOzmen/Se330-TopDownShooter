using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    [SerializeField] private TMP_Text totalScoreText;

    /////
    public int totalScore = 0 ;

    private void OnEnable()
    {
        EventManager.Instance.ScoreUpdateEvent += ChangeScore;
    }
    private void OnDisable()
    {

        EventManager.Instance.ScoreUpdateEvent -= ChangeScore;
    }
   
    public void ChangeScore(int Score)
    {
        Debug.Log("puannn");
        totalScore += Score;
        totalScoreText.text = "Score = " + totalScore.ToString();
    }
}

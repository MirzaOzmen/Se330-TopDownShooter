using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI EndingScore;
    void Start()
    {
        score = GameObject.FindAnyObjectByType<Score>();
    }

   
    public void SetGameOverScore()
    {
        EndingScore.text = "Score = " + score.totalScore.ToString();

    }
}

using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject GameOverMenuCanvas;
    [SerializeField] private TextMeshProUGUI EndingScore;
    [SerializeField] private TextMeshProUGUI EndingTime;
    void Start()
    {
        score = GameObject.FindAnyObjectByType<Score>();
    }
    private void OnEnable()
    {
        EventManager.Instance.CharacterDeadEvent += CharacterIsDead;
    }
    private void OnDisable()
    {

        EventManager.Instance.CharacterDeadEvent -= CharacterIsDead;
    }

    private void CharacterIsDead()
    {
        SetGameOverScore();
        setGameOverTime();
        GameOverMenuCanvas.SetActive(true);
        Time.timeScale = 0;

    }

    private void SetGameOverScore()
    {
        EndingScore.text = "Score = " + score.totalScore.ToString();

    }
    private void setGameOverTime()
    {
        EndingTime.text = "Time = " + timer.TimerCount;
    }
}

using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] private int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        EventManager.Instance.EnemyDeadEvent += ScoreUpdate;
    }
    private void OnDisable()
    {

        EventManager.Instance.EnemyDeadEvent -= ScoreUpdate;
    }
    private void ScoreUpdate(GameObject enemy)
    {
        if(enemy == gameObject)
        {
            EventManager.Instance.Score_EventDetected(score);
        }
        
    }
}

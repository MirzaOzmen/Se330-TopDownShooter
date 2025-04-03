using UnityEngine;
using System.Collections;

public class MovementSpeedBoost : MonoBehaviour
{
    [SerializeField] private Player player;
    private Coroutine MovementSpeedBoostCoroutine; // to stop specific coroutine 

    private void Start()
    {
        if (player == null)
        {
            player = GetComponent<Player>();
        }

    }
    private void OnEnable()
    {
        
        EventManager.Instance.buffwithPercentageEvent += callMovementSpeedCalculations;

    }
    private void OnDisable()
    {
        
        EventManager.Instance.buffwithPercentageEvent -= callMovementSpeedCalculations;
    }


    public void callMovementSpeedCalculations(BoostEnum boosType, float buffpercentage, float timer)
    {
        if (boosType != BoostEnum.movementSpeed) return;


        if (MovementSpeedBoostCoroutine != null)
        {
            StopCoroutine(MovementSpeedBoostCoroutine);
            Debug.Log("durduruldu");

        }
        MovementSpeedBoostCoroutine = StartCoroutine(temporaryMovementSpeedBoost(buffpercentage, timer));

    }

    IEnumerator temporaryMovementSpeedBoost(float buffpercentage, float timer)
    {
        Debug.Log("bbase = " + player.returnBaseMovementSpeed() + "  boost = " + buffpercentage);
        player.movementSpeedBoostRate = player.returnBaseMovementSpeed() * (buffpercentage / 100);

        Debug.Log("girdi = " + player.AttackSpeedboostRate);

        yield return new WaitForSeconds(timer);


        player.movementSpeedBoostRate = 0;
    }

}

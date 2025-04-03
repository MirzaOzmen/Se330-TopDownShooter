using UnityEngine;
using System.Collections;

public class AttackSpeedBoost : MonoBehaviour
{
    [SerializeField] private Player player ;
    private Coroutine AttackBoost ; // to stop specific coroutine 

  

    private void Start()
    {
        if(player==null)
        {
            player = GetComponent<Player>();
        }
        
    }
    private void OnEnable()
    {
        //EventManager.Instance.AttackSpeedChangeEvent += callAttackSpeedCalculation;
        EventManager.Instance.buffwithPercentageEvent += callAttackSpeedCalculations;
        
    }
    private void OnDisable()
    {
        // EventManager.Instance.AttackSpeedChangeEvent -= callAttackSpeedCalculation;
        EventManager.Instance.buffwithPercentageEvent -= callAttackSpeedCalculations;
    }


    public void callAttackSpeedCalculations( BoostEnum boosType,float buffpercentage, float timer)
    {
        if (boosType != BoostEnum.attackSpeed) return;
        

            if (AttackBoost != null)
            {
                StopCoroutine(AttackBoost);
                Debug.Log("durduruldu");

            }

            AttackBoost = StartCoroutine(temporaryAttackSpeedBoost(buffpercentage, timer));
        

    }
  /*  public void callAttackSpeedCalculation(float buffpercentage,float timer)
    {
        
        if (AttackBoost != null)
        {
            StopCoroutine(AttackBoost);
            Debug.Log("durduruldu");

        }

        AttackBoost = StartCoroutine(temporaryAttackSpeedBoost(buffpercentage,timer));
    }*/
    IEnumerator temporaryAttackSpeedBoost(float buffpercentage,float timer)
    {
        Debug.Log("bbase = " + player.returnBaseFireRate() + "  boost = " + buffpercentage);
        player.AttackSpeedboostRate = player.returnBaseFireRate()*(buffpercentage/100);

        Debug.Log("girdi = " + player.AttackSpeedboostRate);
       
        yield return new WaitForSeconds(timer);
       

        player.AttackSpeedboostRate = 0;
    }


}

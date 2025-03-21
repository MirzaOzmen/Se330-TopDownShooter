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
        player = GetComponent<Player>();
    }
    private void OnEnable()
    {
        EventManager.Instance.AttackSpeedChangeEvent += callAttackSpeedCalculation;
        
    }
    private void OnDisable()
    {
        EventManager.Instance.AttackSpeedChangeEvent -= callAttackSpeedCalculation;
    }


    public void callAttackSpeedCalculation(float buffpercentage,float timer)
    {
        if (AttackBoost != null)
        {
            StopCoroutine(AttackBoost);
            Debug.Log("durduruldu");

        }

        AttackBoost = StartCoroutine(temporaryAttackSpeedBoost(buffpercentage,timer));
    }
    IEnumerator temporaryAttackSpeedBoost(float buffpercentage,float timer)
    {
        Debug.Log("bbase = " + player.BaseFireRate + "  boost = " + buffpercentage);
        player.boostRate = player.BaseFireRate*(buffpercentage/100);

        Debug.Log("girdi = " + player.boostRate);
       
        yield return new WaitForSeconds(timer);
        //characterAttackSpeed.attackSpedd = BaseAttackSpeed;
        player.boostRate = 0;
    }


}

using UnityEngine;
using System.Collections;

public class AttackSpeedBoost : MonoBehaviour
{
    [SerializeField] private float AttackSpeedBoostPersentage;
    [SerializeField] private int BoostTime;
    private float BaseAttackSpeed; 
    private Coroutine AttackBoost ; // to stop specific coroutine 



    //CharacterAttack characterAttackSpeed;
  
    void Start()
    {
     //characterAttackSpeed = GetComponent<CharacterAttack>();
     // BaseAttackSpeed = characterAttackSpeed.attackSpedd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // for test 
        {
            if(AttackBoost!= null)
            {
                StopCoroutine(AttackBoost);
              
            }
          
           AttackBoost = StartCoroutine(temporaryAttackSpeedBoost());
        }
    }
    IEnumerator temporaryAttackSpeedBoost()
    {


        // characterAttackSpeed.attackSpedd = BaseAttackSpeed - (BaseAttackSpeed * AttackSpeedBoostPersentage)/100;
       
        yield return new WaitForSeconds(BoostTime);
        //characterAttackSpeed.attackSpedd = BaseAttackSpeed;
 
    }


}

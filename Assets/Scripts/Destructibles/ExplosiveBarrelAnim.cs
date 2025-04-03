using UnityEngine;
using System.Collections;
public class ExplosiveBarrelAnim : MonoBehaviour
{
    
    [SerializeField] private GameObject DamageAmountBar;
    [SerializeField] private Collider2D Collider;
    private float percentage;

    void Start()
    {
       if(Collider==null)
        {
            Collider = GetComponent<Collider2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateDamgeAmount(float currentHealth, float maxHealth)
    {
        DamageAmountBar.SetActive(true);
        percentage = 100 - (currentHealth / maxHealth) * 100;
        float x, y, z;
        x = DamageAmountBar.transform.localScale.x * (percentage / 100);
        y = DamageAmountBar.transform.localScale.y * (percentage / 100);
        z = DamageAmountBar.transform.localScale.z * (percentage / 100);
        x = Mathf.Clamp(x, 0, DamageAmountBar.transform.localScale.x);
        y = Mathf.Clamp(y, 0, DamageAmountBar.transform.localScale.y);
        z = Mathf.Clamp(z, 0, DamageAmountBar.transform.localScale.z);
        Vector3 amount = new Vector3(x, y, z);
        gameObject.transform.localScale = amount;
        
    }
   public IEnumerator BlowUp( int blowupTime)
    {
        float timer = 0f;
       
        gameObject.transform.localScale = Vector3.zero;
        Debug.Log("courutine girdi");
        while (timer< blowupTime)
        {
            timer += Time.deltaTime;
            float lerpAmount = timer / 5; 
            lerpAmount = Mathf.Clamp01(lerpAmount); 

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * DamageAmountBar.transform.localScale.x, lerpAmount);  //will change animation probably work much better

            yield return null; // Bir frame bekle
        }
        Collider.enabled = true;
        Destroy(transform.parent.gameObject,0.1f);
        yield return null;
    }
}

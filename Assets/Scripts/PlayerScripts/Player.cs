using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)] [SerializeField] private float fireRate = 0.5f;
    public float AttackSpeedboostRate;
    public float movementSpeedBoostRate;
    private Rigidbody2D rb;
    private float mx;
    private float my;

    private float fireTimer;
    
    private Vector2 mousePos;
    
    void Start()
    {
        
        AttackSpeedboostRate = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        mx= Input.GetAxisRaw("Horizontal");
        my= Input.GetAxisRaw("Vertical");
        mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("benim attack speed = " + AttackSpeedboostRate);
        if (Time.timeScale == 0) return;
        float angle =
            Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetMouseButton (0) && fireTimer <= 0)
        {
            fireTimer = GetCurrentFireRate();
            Shoot();
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }
    
     private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(mx,my).normalized * (speed+movementSpeedBoostRate);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
    private float GetCurrentFireRate()
    {
        return fireRate - AttackSpeedboostRate;
    }
    public float returnBaseFireRate()
    {
        return fireRate;
    }
    public float returnBaseMovementSpeed()
    {
        return speed;
    }

    /*  private void OnCollisionEnter2D(Collision2D other)
      {
          if (other.gameObject.CompareTag("EnemyBullet"))
          {
              Destroy(gameObject);
          }
      }*/
}

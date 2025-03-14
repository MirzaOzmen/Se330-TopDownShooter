using System;
using UnityEngine;

namespace EnemyScripts
{
    public class RangedEnemy : MonoBehaviour
    {
        public Transform target;
        public float speed = 3f;
        public float rotateSpeed = 0.0025f;
        private Rigidbody2D rb;
        public GameObject bulletPrefab;

        public float distanceToShoot = 5f;
        public float distanceToStop = 3f;
        
        public Transform firingPoint;
        public float fireRate;
        private float timeToFire;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            timeToFire= 0f;
        }

        private void Update()
        {
            if (!target)
            {
                GetTarget();
            }
            else
            { 
                RotateTowardsTarget();
            }

            if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if(timeToFire <= 0)
            {
                Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
                timeToFire = fireRate;
            }
            else
            {
                timeToFire -= Time.deltaTime;
            }
        }
        private void FixedUpdate()
        {
            if (target != null)
            {
                if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
                {
                    rb.linearVelocity = transform.up * speed;
                }
                else
                {
                    rb.linearVelocity = Vector2.zero;
                }
            }
           
        }

        private void RotateTowardsTarget()
        {
            Vector2 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        }
        private void GetTarget()
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
         
            if(other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                target = null;
            } else if(other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
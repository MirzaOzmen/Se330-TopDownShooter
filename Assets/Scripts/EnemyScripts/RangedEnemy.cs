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
        public float obstacleAvoidanceDistance = 1.5f;
        public LayerMask obstacleLayer;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            timeToFire = 0f;
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

        private void FixedUpdate()
        {
            if (target != null)
            {
                Vector2 moveDirection = transform.up;

                if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
                {
                    if (ObstacleAhead())
                    {
                        moveDirection = AvoidObstacle();
                    }
                    rb.linearVelocity = moveDirection * speed;
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

        private bool ObstacleAhead()
        {
            return Physics2D.Raycast(transform.position, transform.up, obstacleAvoidanceDistance, obstacleLayer);
        }

        private Vector2 AvoidObstacle()
        {
            Vector2 leftDirection = Quaternion.Euler(0, 0, 30) * transform.up;
            Vector2 rightDirection = Quaternion.Euler(0, 0, -30) * transform.up;

            bool leftClear = !Physics2D.Raycast(transform.position, leftDirection, obstacleAvoidanceDistance, obstacleLayer);
            bool rightClear = !Physics2D.Raycast(transform.position, rightDirection, obstacleAvoidanceDistance, obstacleLayer);

            if (leftClear && rightClear)
            {
                return UnityEngine.Random.value > 0.5f ? leftDirection : rightDirection;
            }
            else if (leftClear)
            {
                return leftDirection;
            }
            else if (rightClear)
            {
                return rightDirection;
            }
            else
            {
                return -transform.up; // Reverse direction if no clear path
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
    }
}

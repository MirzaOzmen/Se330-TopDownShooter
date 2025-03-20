using System;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyController : MonoBehaviour
    {
        public Transform target;
        public float speed = 3f;
        public float rotateSpeed = 0.0025f;
        private Rigidbody2D rb;
        public float obstacleAvoidanceDistance = 1.5f;
        public LayerMask obstacleLayer;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
        }
    
        private void FixedUpdate()
        {
            Vector2 moveDirection = transform.up;
            
            if (ObstacleAhead())
            {
                moveDirection = AvoidObstacle();
            }
            
            rb.linearVelocity = moveDirection * speed;
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                target = null;
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
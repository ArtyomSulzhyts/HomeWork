using UnityEngine;

namespace Pirates 
{
    public class Ship : MonoBehaviour, IShip
    {
        public float speed = 5f;
        public float rotationSpeed = 5f;
        private Vector3 _targetPosition;
        private bool _isMoving;
        private Rigidbody2D _rb;
        private static Vector3 _savedPosition;

        private void OnValidate()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            if (_savedPosition != Vector3.zero)
            {
                transform.position = _savedPosition;
            }
        }

        public void MoveToPosition(Vector2 positionToMove)
        {
            _targetPosition = positionToMove;
            _isMoving = true;
        }
        
        void Update()
        {
            if (_isMoving)
            {
                Vector3 direction = _targetPosition - transform.position;
                float distanceToTarget = direction.magnitude;
                
                if (distanceToTarget <= 0.1f)
                {
                    _isMoving = false;
                    _rb.velocity = Vector3.zero;
                    return;
                }
                float currentSpeed = Mathf.Lerp(0f, speed, distanceToTarget / speed);
                
                _rb.velocity = direction.normalized * currentSpeed;
                
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

        }
        private void OnDisable()
        {
            _savedPosition = transform.position;
        }
    }
}

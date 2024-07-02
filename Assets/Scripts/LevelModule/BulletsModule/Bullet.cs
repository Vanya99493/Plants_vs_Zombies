using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class Bullet : MonoBehaviour
    {
        private LayerMask _collidedLayer; 
        private Vector3 _direction;
        private float _speed;
        private int _damage;

        public void Initialize(LayerMask collidedLayerMask, Vector3 direction, float speed, int damage)
        {
            _collidedLayer = collidedLayerMask;
            _direction = direction;
            _speed = speed;
            _damage = damage;
        }

        private void FixedUpdate()
        {
            transform.position += _direction * (_speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((_collidedLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                if (other.TryGetComponent<IDamagable>(out var collidedObject))
                {
                    collidedObject.CauseDamage(_damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
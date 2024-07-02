using System.Collections;
using UnityEngine;

namespace LevelModule
{
    public class SphereCaster : MonoBehaviour
    {
        [SerializeField] private float _updatesPerSecond = 10;
        [Header("Sphere cast settings")]
        [SerializeField] private float _sphereRadius = 0.1f;
        [SerializeField] private LayerMask _layerMask;

        private float _maxDistance;
        private GameObject _trackedObject;

        public void Initialize(float maxDistance)
        {
            _maxDistance = maxDistance;
        }
        
        private void Start()
        {
            StartCoroutine(SphereCastCoroutine());
        }

        private IEnumerator SphereCastCoroutine()
        {
            float delay = 1f / _updatesPerSecond;
            
            while (true)
            {
                CastSphere();
                yield return new WaitForSeconds(delay);
            }
        }

        private void CastSphere()
        {
            _trackedObject = Physics.SphereCast(transform.position, _sphereRadius, transform.forward,
                out RaycastHit hit, _maxDistance, _layerMask)
                ? hit.transform.gameObject
                : null;
        }
    }
}
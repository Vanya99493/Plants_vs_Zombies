using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class LevelBorderTrigger : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IDestroyable>(out var destroyableObject))
            {
                destroyableObject.Destroy();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
using UnityEngine;

namespace LevelModule
{
    public class LevelBorderTrigger : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
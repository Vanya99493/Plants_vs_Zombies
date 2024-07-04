using UnityEngine;

namespace LevelModule.GrassCutterModule.Data
{
    [CreateAssetMenu(fileName = "GrassCutterSO", menuName = "GrassCutter/GrassCutterSO", order = 0)]
    public class GrassCutterSO : ScriptableObject
    {
        public float Speed;
        public LayerMask TriggerLayer;
    }
}
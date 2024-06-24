using UnityEngine;

namespace PlantsModule
{
    [CreateAssetMenu(fileName = "PlantSO", menuName = "Plants/PlantSO", order = 1)]
    public class PlantSO : ScriptableObject
    {
        public Plant Prefab;
    }
}
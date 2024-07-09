using UnityEngine;

namespace CameraModule
{
    [RequireComponent(typeof(Camera))]
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _increaseStep = 0.1f;

        private void Awake()
        {
            _mainCamera ??= GetComponent<Camera>();
        }

        void Start()
        {
            if (_points.Length != 4)
            {
                Debug.LogError("It is necessary to specify exactly 4 points!");
                return;
            }

            AdjustCameraSize();
        }

        private void AdjustCameraSize()
        {
            bool allPointsVisible = false;

            while (!allPointsVisible)
            {
                allPointsVisible = true;

                foreach (var point in _points)
                {
                    Vector3 viewportPos = _mainCamera.WorldToViewportPoint(point.position);
                    if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
                    {
                        allPointsVisible = false;
                        break;
                    }
                }

                if (!allPointsVisible)
                {
                    _mainCamera.orthographicSize += _increaseStep;
                }
            }
        }
    }
}
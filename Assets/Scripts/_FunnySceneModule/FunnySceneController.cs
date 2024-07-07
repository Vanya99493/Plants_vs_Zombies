using System.Collections;
using UnityEngine;

namespace _FunnySceneModule
{
    public class FunnySceneController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _steps;
        [SerializeField] private float _leftPosition;
        [SerializeField] private float _rightPosition;
        [SerializeField] private float _speed;

        private GameObject _currentStep;
        private int _sign;
        
        private void Start()
        {
            for (int i = 0; i < _steps.Length; i++)
            {
                _steps[i].SetActive(false);
            }
            
            StartCoroutine(FunnySceneCoroutine());
        }

        private void FixedUpdate()
        {
            if (_currentStep != null)
            {
                _currentStep.transform.position += new Vector3(_sign, 0f, 0f) * (_speed * Time.fixedDeltaTime);
            }
        }

        private IEnumerator FunnySceneCoroutine()
        {
            while (true)
            {
                for (int i = 0; i < _steps.Length; i++)
                {
                    yield return StartCoroutine(StartMove(_steps[i], i % 2 == 0));
                }
            }
        }

        private IEnumerator StartMove(GameObject currentStep, bool toLeft)
        {
            _currentStep = currentStep;
            _currentStep.SetActive(true);
            _sign = toLeft ? -1 : 1;
            _currentStep.transform.position = new Vector3(toLeft ? _rightPosition : _leftPosition, 0f, 0f);
            if (toLeft)
            {
                while (currentStep.transform.position.x > _leftPosition)
                {
                    yield return null;
                }
            }
            else
            {
                while (currentStep.transform.position.x < _rightPosition)
                {
                    yield return null;
                }
            }
            _currentStep.SetActive(false);
            _currentStep = null;
        }
    }
}
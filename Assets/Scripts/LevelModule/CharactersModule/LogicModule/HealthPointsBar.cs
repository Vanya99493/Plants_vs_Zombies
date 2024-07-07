using UnityEngine;
using UnityEngine.UI;

namespace LevelModule.CharactersModule
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HealthPointsBar : MonoBehaviour
    {
        [SerializeField] private HealthPointsHandler _healthPointsHandler;
        [SerializeField] private Slider _hpBarSlider;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup ??= GetComponent<CanvasGroup>();
            _canvasGroup.blocksRaycasts = false;
        }

        private void Start()
        {
            _healthPointsHandler.CauseDamageEvent += UpdateHPBarSlider;
            CheckActiveCondition(_healthPointsHandler.CurrentHealthPoints, _healthPointsHandler.MaxHealthPoints);
        }

        private void UpdateHPBarSlider(int currentHealth, int maxHealth)
        {
            CheckActiveCondition(currentHealth, maxHealth);
            _hpBarSlider.value = _hpBarSlider.maxValue * currentHealth / maxHealth;
        }

        private void CheckActiveCondition(int currentHealth, int maxHealth)
        {
            if (currentHealth == maxHealth)
            {
                Deactivate();
            }
            else
            {
                Activate();
            }
        }

        private void Activate()
        {
            _canvasGroup.alpha = 1f;
        }

        private void Deactivate()
        {
            _canvasGroup.alpha = 0f;
        }
    }
}
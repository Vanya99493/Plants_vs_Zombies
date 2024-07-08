using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    [RequireComponent(typeof(Button))]
    public class CharacterButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected void Awake()
        {
            _button ??= GetComponent<Button>();
        }
    }
}
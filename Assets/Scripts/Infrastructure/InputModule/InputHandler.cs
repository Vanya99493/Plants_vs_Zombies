using Interfaces;
using UnityEngine;

namespace Infrastructure
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                ThrowRay();
            }
        }
        
        private void ThrowRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.TryGetComponent<IClickable>(out var clickableObject))
                {
                    clickableObject.Click();
                    return;
                }
            }
        }
    }
}
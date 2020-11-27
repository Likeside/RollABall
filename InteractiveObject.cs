using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{


    public abstract class InteractiveObject: MonoBehaviour, IInteractable
    {
        protected Color _color;
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        public void Action()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
        private void OnTriggerEnter(Collider other)
        { 
            
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log("Collision");
            Interaction();
            Destroy(gameObject);
        }

    }

}

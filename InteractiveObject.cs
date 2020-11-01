using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{


    public abstract class InteractiveObject: MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
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

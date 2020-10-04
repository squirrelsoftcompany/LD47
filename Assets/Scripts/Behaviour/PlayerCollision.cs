using Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        // Start is called before the first frame update
        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public GameEvent successfulSlideEvent;
        public GameEvent hitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Obstacle/Limbo") && !other.CompareTag("Obstacle/Wall"))
                // Nothing
                return;

            if (other.CompareTag("Obstacle/Limbo") && playerMovement.sliding)
            {
                successfulSlideEvent.Raise();
                return;
            }

            // Hitted
            // TODO -> launch hit animation
            hitEvent.Raise();
            SoundEffectsManager.Instance.MakeHurtSound();
        }
    }
}
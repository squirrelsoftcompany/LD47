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

        private Collider currentHitCollider = null;
        private bool colliderHitted = false;
        private float collideTimer = 0;

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

            currentHitCollider = other;
            collideTimer = Dora.Inst.behaviourSettings.invulnerability * 1 / Dora.Inst.gameState.currentWheelSpeed;
            collideTimer += Time.deltaTime; // don't count the current frame
        }

        private void OnTriggerStay(Collider other)
        {
            if (currentHitCollider != other || colliderHitted)
            {
                return;
            }

            collideTimer -= Time.deltaTime;

            if (collideTimer <= 0)
            {
                // Hitted
                // TODO -> launch hit animation
                hitEvent.Raise();
                SoundEffectsManager.Instance.MakeHurtSound();
                colliderHitted = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (currentHitCollider != other)
            {
                return;
            }

            currentHitCollider = null;
            colliderHitted = false;
        }

    }
}
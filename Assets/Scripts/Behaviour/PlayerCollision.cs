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

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Obstacle/Barre") && !other.CompareTag("Obstacle/Mur"))
                // Nothing
                return;

            if (other.CompareTag("Obstacle/Barre") && playerMovement.sliding)
            {
                // huge fame
                Dora.Inst.AddFame(Dora.Inst.behaviourSettings.fameSlidePercentIncrement);
                return;
            }

            // Hitted
            // TODO -> launch hit animation
            Dora.Inst.AddFame(Dora.Inst.behaviourSettings.famePercentDecrement);
            Dora.Inst.AddWheelSpeed(Dora.Inst.behaviourSettings.wheelSpeedPercentDecrement);
            SoundEffectsManager.Instance.MakeHurtSound();
        }
    }
}
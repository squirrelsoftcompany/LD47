using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Behaviour
{
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        public enum LINE
        {
            eRIGHT,
            eMIDDLE,
            eLEFT
        }

        private LINE ligne = LINE.eMIDDLE;
        private bool sliding = false;

        private Animator animator;

        public bool Sliding { get => sliding; }

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ToLeft()
        {
            if (ligne == LINE.eLEFT || sliding)
                return;

            animator.SetTrigger("ToLeft");
            ligne -= 1;
        }

        void ToRight()
        {
            if (ligne == LINE.eRIGHT || sliding)
                return;

            animator.SetTrigger("ToRight");
            ligne += 1;
        }

        void Slide()
        {
            sliding = true;
        }
    }
}
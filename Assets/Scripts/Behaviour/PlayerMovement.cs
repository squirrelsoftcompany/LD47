﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Behaviour
{
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        public enum LINE
        {
            eLEFT,
            eMIDDLE,
            eRIGHT
        }

        private LINE ligne = LINE.eMIDDLE;
        public bool sliding = false;

        private Animator animator;

        public bool Sliding { get => sliding; }
        public float dashDistance = 3.0f;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("wheelSpeed", Dora.Inst.gameState.currentWheelSpeed);

            if (!Dora.Inst.gameState.running)
                return;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ToLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ToRight();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Slide();
            }
        }

        void ToLeft()
        {
            if (ligne == LINE.eLEFT || sliding || !animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                return;

            animator.SetTrigger("ToLeft");
            SoundEffectsManager.Instance.MakeDashSound();
            Vector3 position = this.transform.position;
            position.x -= dashDistance;
            this.transform.position = position;
            ligne -= 1;
        }

        void ToRight()
        {
            if (ligne == LINE.eRIGHT || sliding || !animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                return;

            animator.SetTrigger("ToRight");
            SoundEffectsManager.Instance.MakeDashSound();
            Vector3 position = this.transform.position;
            position.x += dashDistance;
            this.transform.position = position;
            ligne += 1;
        }

        void Slide()
        {
            if (sliding || !animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                return;

            SoundEffectsManager.Instance.MakeSlideSound();
            animator.SetTrigger("Slide");
        }
    }
}
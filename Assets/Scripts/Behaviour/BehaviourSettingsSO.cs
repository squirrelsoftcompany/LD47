using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    [CreateAssetMenu(fileName = "BehaviourSettingsSO", menuName = "SO/Behaviour/Settings")]
    public class BehaviourSettingsSO : ScriptableObject
    {
        [Tooltip("Initial speed (tick/sec.)")]
        public float initialWheelSpeed = 0.5f;
        [Tooltip("Initial fame of the run")]
        public float initialFame = 0.1f;
        [Tooltip("How much wheel part are needed")]
        public int wheelPartCount = 60;
        [Tooltip("how much tick maxster must stay in a collider to take a hit (percent of a tick)")]
        public float invulnerability = 0.5f;

        [Header("Limits")]
        public float wheelSpeedMin = 0;
        public float wheelSpeedMax = 6;
        public float fameMin = 0;
        public float fameMax = 1;

        [Header("WheelSpeed Increments")]
        [Tooltip("incr / tick")]
        public float wheelSpeedPercentIncrement = 0.001f; // incr / tick
        [Tooltip("decr / tick")]
        public float wheelSpeedPercentDecrement = -0.05f; // decr / hit
        [Tooltip("incr / successful slide")]
        public float wheelSpeedSlidePercentIncrement = 0f; // incr / successful slide

        [Header("Fame Increments")]
        [Tooltip("incr / tick")]
        public float famePercentIncrement = 0.001f; // incr / tick
        [Tooltip("decr / tick")]
        public float famePercentDecrement = -0.1f; // decr / hit
        [Tooltip("incr / successful slide")]
        public float fameSlidePercentIncrement = 0.01f; // incr / successful slide
    }
}
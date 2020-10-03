using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Behaviour
{
    [CreateAssetMenu(fileName = "BehaviourSettingsSO", menuName = "SO/Behaviour/Settings")]
    public class BehaviourSettingsSO : ScriptableObject
    {
        [Tooltip("Base time in seconds at which the wheel move")]
        public float wheelTick = 0.5f;
        [Tooltip("Initial divisor to apply to the base time")]
        public float initialWheelSpeed = 0.5f;
        [Tooltip("Initial fame of the run")]
        public float initialFame = 0.1f;
        [Tooltip("How much wheel part is needed")]
        public int wheelPartCount = 60;
    }
}
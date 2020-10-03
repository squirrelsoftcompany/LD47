using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    [CreateAssetMenu(fileName = "GameStateSO", menuName = "SO/Behaviour/GameState")]
    public class GameStateSO : ScriptableObject
    {
        public float currentWheelSpeed = 0.5f;
        public float currentFame = 0.5f;
        public double score = 0.0f;
    }
}
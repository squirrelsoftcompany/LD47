using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    [CreateAssetMenu(fileName = "GameStateSO", menuName = "SO/Behaviour/GameState")]
    public class GameStateSO : ScriptableObject
    {
        [Tooltip("Current wheel speed (tick/sec.)")]
        public float currentWheelSpeed = 0.5f;
        [Tooltip("Current fame")]
        public float currentFame = 0.5f;
        [Tooltip("Current score point")]
        public double score = 0.0f;
        [Tooltip("Is game outside menu ?")]
        public bool running = false;
        [Tooltip("Does the game must show MainScreen next time ?")]
        public bool showMainScreen = true;

        private void Awake()
        {
            // On first game we should always show MainScreen
            showMainScreen = true;
        }
    }
}
using Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    [RequireComponent(typeof(Generation.WheelGeneration))]
    public class WheelMovement : MonoBehaviour
    {
        private WheelGeneration wheelGeneration;
        private float timer = 0;

        [SerializeField] private BehaviourSettingsSO settings;
        [SerializeField] private GameStateSO state;

        // Start is called before the first frame update
        void Start()
        {
            wheelGeneration = GetComponent<WheelGeneration>();
            timer = settings.wheelTick / settings.initialWheelSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (state.currentWheelSpeed == 0)
                return;

            timer -= Time.deltaTime;
            
            if (timer <= 0)
            {
                transform.Rotate(Vector3.right * (360 / wheelGeneration.prefabsParts.howMuchPartNeeded));
                timer = settings.wheelTick / state.currentWheelSpeed;
            }
        }
    }
}
using Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dora : MonoBehaviour
{
    public GameStateSO gameState;
    public BehaviourSettingsSO behaviourSettings;

    public GameEvent WheelTickEvent;

    private static Dora instance = null;

    public static Dora Inst { get => instance; set => instance = value; }

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        gameState.currentFame = behaviourSettings.initialFame;
        gameState.currentWheelSpeed = behaviourSettings.initialWheelSpeed;
        gameState.score = 0;

        // initialize timer
        timer = behaviourSettings.wheelTick / behaviourSettings.initialWheelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.currentWheelSpeed == 0 || gameState.currentFame == 0)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            WheelTickEvent.Raise();
            timer = behaviourSettings.wheelTick / gameState.currentWheelSpeed;
        }
    }
}

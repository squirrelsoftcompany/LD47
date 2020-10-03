using Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dora : MonoBehaviour
{
    public GameStateSO gameState;
    public BehaviourSettingsSO behaviourSettings;

    public GameEvent WheelTick;

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
            Loose();
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            WheelTick.Raise();
            AddFame(behaviourSettings.famePercentIncrement);
            AddWheelSpeed(behaviourSettings.wheelSpeedPercentIncrement);
            timer = behaviourSettings.wheelTick / gameState.currentWheelSpeed;
        }

        gameState.score += Time.deltaTime * 1000 * gameState.currentFame;
    }

    public void AddFame(float percentIncr)
    {
        float range = behaviourSettings.fameMax - behaviourSettings.fameMin;
        gameState.currentFame = Mathf.Clamp(gameState.currentFame + percentIncr * range, behaviourSettings.fameMin, behaviourSettings.fameMax);
    }

    public void AddWheelSpeed(float percentIncr)
    {
        float range = behaviourSettings.wheelSpeedMax - behaviourSettings.wheelSpeedMin;
        gameState.currentWheelSpeed = Mathf.Clamp(gameState.currentWheelSpeed + percentIncr * range, behaviourSettings.wheelSpeedMin, behaviourSettings.wheelSpeedMax);
    }

    private void Loose()
    {
        // TODO -> loose
        Debug.Log("You loose !!!");
        gameState.currentWheelSpeed = 0;
        gameState.currentFame = 0;
    }
}

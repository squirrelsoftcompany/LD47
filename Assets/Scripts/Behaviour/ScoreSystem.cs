using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ScoreSystem : MonoBehaviour
{
    public GameEvent GameOverEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dora.Inst.gameState.running)
            return;

        Dora.Inst.gameState.score += Time.deltaTime * 1000 * Dora.Inst.gameState.currentFame;
    }

    public void Tick()
    {
        if (!Dora.Inst.gameState.running)
            return;

        AddFame(Dora.Inst.behaviourSettings.famePercentIncrement);
        AddWheelSpeed(Dora.Inst.behaviourSettings.wheelSpeedPercentIncrement);
    }

    public void SuccessfulSlide()
    {
        AddFame(Dora.Inst.behaviourSettings.fameSlidePercentIncrement);
    }

    public void Hit()
    {
        AddFame(Dora.Inst.behaviourSettings.famePercentDecrement);
        AddWheelSpeed(Dora.Inst.behaviourSettings.wheelSpeedPercentDecrement);
    }

    private void GameOver()
    {
        Debug.Log("You loose !!!");
        Dora.Inst.gameState.currentWheelSpeed = 0;
        Dora.Inst.gameState.currentFame = 0;
        Dora.Inst.gameState.running = false;

        GameOverEvent.Raise();
    }

    private void AddFame(float incrPercent)
    {
        Dora.Inst.gameState.currentFame = AddGeneric(incrPercent, Dora.Inst.gameState.currentFame, Dora.Inst.behaviourSettings.fameMin, Dora.Inst.behaviourSettings.fameMax);
        if (Dora.Inst.gameState.currentFame <= 0)
            GameOver();
    }

    private void AddWheelSpeed(float incrPercent)
    {
        Dora.Inst.gameState.currentWheelSpeed = AddGeneric(incrPercent, Dora.Inst.gameState.currentWheelSpeed, Dora.Inst.behaviourSettings.wheelSpeedMin, Dora.Inst.behaviourSettings.wheelSpeedMax);
    }

    private float AddGeneric(float incrPercent, float current, float min, float max)
    {
        float range = max - min;
        return Mathf.Clamp(current + incrPercent * range, min, max);
    }
}

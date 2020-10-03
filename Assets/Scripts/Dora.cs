using Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dora : MonoBehaviour
{
    public GameStateSO gameState;
    public BehaviourSettingsSO behaviourSettings;

    private Dora instance = null;

    public Dora Inst { get => instance; set => instance = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        gameState.currentFame = behaviourSettings.initialFame;
        gameState.currentWheelSpeed = behaviourSettings.initialWheelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

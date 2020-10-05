using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElevation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = Vector3.up * Mathf.Clamp(Dora.Inst.gameState.currentWheelSpeed / 4, 0.5f, 4);
    }
}

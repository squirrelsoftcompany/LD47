using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElevation : MonoBehaviour
{
    public float sheafImpact = 5;
    private float sheaf = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gravity = Vector3.up * Mathf.Clamp(Dora.Inst.gameState.currentWheelSpeed / 4, 0.5f, 4);
        if (sheaf > 0)
        {
            gravity += Vector3.up * sheaf;
            sheaf -= sheafImpact * Time.deltaTime;
        }
        Physics.gravity = gravity;
    }

    public void InitiateSheaf()
    {
        sheaf = sheafImpact;
    }
}

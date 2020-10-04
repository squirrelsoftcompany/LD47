using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManagement : MonoBehaviour
{
    public List<GameObject> Crowd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tick()
    {
        float step = (Dora.Inst.behaviourSettings.fameMax - Dora.Inst.behaviourSettings.fameMin) / (Crowd.Count-1);
        for (int i = 0; i < Crowd.Count; i++)
        {
            if (Dora.Inst.gameState.currentFame >= Dora.Inst.behaviourSettings.fameMin + i * step)
            {
                Crowd[i].SetActive(true);
            }
            else
            {
                Crowd[i].SetActive(false);
            }
        }
    }

    public void GameOverSlot()
    {
        foreach (var elem in Crowd)
        {
            elem.SetActive(false);
        }
    }
}

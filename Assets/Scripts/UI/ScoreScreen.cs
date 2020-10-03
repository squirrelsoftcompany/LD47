using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class ScoreScreen : MonoBehaviour
{
    private UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0:00000000}", Mathf.FloorToInt(Dora.Inst.gameState.score));
    }
}

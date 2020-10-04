using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class MainScreen : MonoBehaviour
    {
        public GameEvent runEvent;

        // Start is called before the first frame update
        void Start()
        {
            if (!Dora.Inst.gameState.showMainScreen)
                runEvent.Raise();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                runEvent.Raise();
        }

        public void Run()
        {
            gameObject.SetActive(false);
        }
    }
}
using Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviour
{
    public class WheelMovement : MonoBehaviour
    {
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
            transform.Rotate(Vector3.right * (360f / Dora.Inst.behaviourSettings.wheelPartCount));
        }
    }
}
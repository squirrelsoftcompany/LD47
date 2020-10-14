using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    [System.Serializable]
    public class WheelObstacleRow
    {
        public GameObject left = null;
        public GameObject middle = null;
        public GameObject right = null;

        public GameObject this[Behaviour.PlayerMovement.LINE l]
        {
            get
            {
                GameObject go = null;
                switch (l)
                {
                    case Behaviour.PlayerMovement.LINE.eLEFT:
                        go = left;
                        break;
                    case Behaviour.PlayerMovement.LINE.eMIDDLE:
                        go = middle;
                        break;
                    case Behaviour.PlayerMovement.LINE.eRIGHT:
                        go = right;
                        break;
                }

                return go;
            }
        }
    }

    public class WheelObstacleGeneration : MonoBehaviour
    {
        public WheelObstaclesSO wheelObstacles;

        private int tickCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            tickCount = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void Tick()
        {
            tickCount -= 1;
            if (tickCount > 0)
                return;

            tickCount = wheelObstacles.tickRate;

            if (!Dora.Inst.gameState.running)
                return;

            float fraction = 360f / Dora.Inst.behaviourSettings.wheelPartCount;
            GenerateRow(wheelObstacles.rows[Random.Range(0, wheelObstacles.rows.Count)], fraction * -(Dora.Inst.behaviourSettings.wheelPartCount / 3)); // Player can see a little more than 1/4 of the wheel -> so appear at 1/3
        }

        public void GenerateRow(WheelObstacleRow row, float pitch)
        {
            for (int i = 0; i < 3; i++)
            {
                var l = (Behaviour.PlayerMovement.LINE)i;
                if (row[l])
                    GenerateOne(row[l], l, pitch);
            }
        }

        public GameObject GenerateOne(GameObject obstacle, Behaviour.PlayerMovement.LINE line, float pitch)
        {
            GameObject prefab = Instantiate(obstacle, transform);
            prefab.transform.Translate(new Vector3(((int)line - 1) * 3, 0, 0));
            prefab.transform.localRotation = Quaternion.Inverse(transform.rotation) * Quaternion.Euler(Vector3.right * pitch);
            
            return prefab;
        }
    }
}
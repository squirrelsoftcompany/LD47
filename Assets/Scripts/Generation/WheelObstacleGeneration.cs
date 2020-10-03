using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class WheelObstacleGeneration : MonoBehaviour
    {
        public WheelObstaclesSO wheelObstacles;

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
            float fraction = 360f / Dora.Inst.behaviourSettings.wheelPartCount;
            GenerateOne((Behaviour.PlayerMovement.LINE)Random.Range(0, 3), fraction * -(Dora.Inst.behaviourSettings.wheelPartCount / 3)); // Player can see a little more than 1/4 of the wheel -> so appear at 1/3
        }

        public GameObject GenerateOne(Behaviour.PlayerMovement.LINE line, float pitch)
        {
            GameObject prefab = Instantiate(wheelObstacles.wheelObstacles[Random.Range(0, wheelObstacles.wheelObstacles.Count)], transform);
            prefab.transform.Translate(new Vector3(((int)line - 1) * 3, 0, 0));
            prefab.transform.localRotation = Quaternion.Inverse(transform.rotation) * Quaternion.Euler(Vector3.right * pitch);
            
            return prefab;
        }
    }
}
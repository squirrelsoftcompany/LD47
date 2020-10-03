using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class WheelGeneration : MonoBehaviour
    {
        private List<GameObject> parts;
        public WheelPartsSO prefabsParts;

        // Start is called before the first frame update
        void Start()
        {
            parts = new List<GameObject>();
            Generate();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Generate()
        {
            float fraction = 360f / Dora.Inst.behaviourSettings.wheelPartCount;
            for (int i = 0; i < Dora.Inst.behaviourSettings.wheelPartCount; i++)
            {
                parts.Add(GenerateOne(i * fraction));
            }
        }

        GameObject GenerateOne(float pitch = 0)
        {
            GameObject prefab = Instantiate(prefabsParts.wheelParts[Random.Range(0, prefabsParts.wheelParts.Count)], transform);
            prefab.transform.Rotate(Vector3.right * pitch);
            return prefab;
        }
    }
}
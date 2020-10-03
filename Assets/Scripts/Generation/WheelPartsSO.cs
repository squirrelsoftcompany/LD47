using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    [CreateAssetMenu(fileName = "WheelPartsSO", menuName = "SO/Generation/WheelParts")]
    public class WheelPartsSO : ScriptableObject
    {
        public List<GameObject> wheelParts;
    }
}
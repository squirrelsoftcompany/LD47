using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    [CreateAssetMenu(fileName = "WheelObstaclesSO", menuName = "SO/Generation/WheelObstacles")]
    public class WheelObstaclesSO : ScriptableObject
    {
        public List<GameObject> wheelObstacles;
    }
}
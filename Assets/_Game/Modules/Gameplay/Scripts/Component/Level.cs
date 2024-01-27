using System;
using UnityEngine;

namespace Modules.Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private void OnValidate()
        {
        }
    }
}
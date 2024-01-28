using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Gameplay
{
    public class Level : MonoBehaviour
    {
        public Vector3 StartLocalPosition => _startPoint.localPosition;
        public Vector3 EndLocalPosition => _endPoint.localPosition;
        public Transform KeyContainer => _keyContainer;
        public float KeySpeed => _keySpeed;
        public List<BaseMusicKey> Keys => _keys;
        
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Transform _keyContainer;
        [SerializeField] private float _keySpeed;
        [SerializeField] private List<BaseMusicKey> _keys;

        private void OnValidate()
        {
            _keys = KeyContainer.GetComponentsInChildren<BaseMusicKey>().ToList();
        }
    }
}
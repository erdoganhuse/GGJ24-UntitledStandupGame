using System;
using Library.Utility;
using TMPro;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BaseMusicKey : MonoBehaviour
    {
        [SerializeField] private InputKeyType _key;
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private BoxCollider _boxCollider;

        private GameplayConfig GameplayConfig => GameplayConfig.instance;
        
        public virtual void OnValidate()
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = transform.GetComponentInChildrenWithName<MeshRenderer>("Visual");
            }

            _meshRenderer.sharedMaterial = GameplayConfig.GetMaterial(_key);
            
            var values = Enum.GetValues(typeof(InputKeyType));
            for (int i = 0; i < values.Length; i++)
            {
                InputKeyType keyType = (InputKeyType)values.GetValue(i);
                if (_key == keyType)
                {
                    transform.GetComponentInChildrenWithName<Transform>(keyType.ToString(), true).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetComponentInChildrenWithName<Transform>(keyType.ToString(), true).gameObject.SetActive(false);
                }
            }
        }

        public Bounds GetBounds()
        {
            return _boxCollider.bounds;
        }
        
        public Vector3 GetActivationStartPoint()
        {
            return default;
        }

        public Vector3 GetActivationEndPoint()
        {
            return default;
        }
    }
}
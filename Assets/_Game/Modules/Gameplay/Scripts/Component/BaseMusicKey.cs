using System;
using Library.Utility;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BaseMusicKey : MonoBehaviour
    {
        public InputKeyType Key => _key;
        
        [SerializeField] private InputKeyType _key;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private BoxCollider _boxCollider;

        private GameplayConfig GameplayConfig => GameplayConfig.Instance;
        
        public virtual void OnValidate()
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = transform.GetComponentInChildrenWithName<MeshRenderer>("Visual");
            }

            if (_boxCollider == null)
            {
                _boxCollider = transform.GetComponentInChildrenWithName<BoxCollider>("Collider");
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
    }
}
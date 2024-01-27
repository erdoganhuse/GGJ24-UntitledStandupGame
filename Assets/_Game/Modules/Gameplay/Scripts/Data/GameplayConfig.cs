using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Modules.Gameplay
{
    [CreateAssetMenu(fileName = "GameplayConfig", menuName = "Modules/Gameplay/GameplayConfig", order = 1)]
    public class GameplayConfig : ScriptableSingleton<GameplayConfig>
    {
        [SerializeField] private InputKeyByMaterialPair[] _inputKeyMaterialMap;

        public Material GetMaterial(InputKeyType keyType)
        {
            return _inputKeyMaterialMap.FirstOrDefault(item => item.Key == keyType).Value;
        }
    }
}
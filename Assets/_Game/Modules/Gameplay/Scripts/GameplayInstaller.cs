using Library.ServiceLocatorSystem;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplayInstaller : BaseInstaller
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private GameplayController _gameplayController;
        
        protected override void InstallBindings()
        {
            ServiceLocator.BindInstance(_inputController);
            ServiceLocator.BindInstance(_gameplayController);
        }
    }
}
using Library.ServiceLocatorSystem;
using Modules.UI.Scripts;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplayInstaller : BaseInstaller
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private GameplayController _gameplayController;
        [Header("UI")] 
        [SerializeField] private HomeScreen _homeScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;
        
        protected override void InstallBindings()
        {
            ServiceLocator.BindInstance(_inputController);
            ServiceLocator.BindInstance(_gameplayController);
        }
    }
}
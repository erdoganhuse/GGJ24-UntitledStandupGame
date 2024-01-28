using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Library.CoroutineSystem;
using Library.PersistentData.Scripts;
using Library.ServiceLocatorSystem;
using Library.SignalBusSystem;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        private InputController InputController => ServiceLocator.Get<InputController>();
        private HomeScreen HomeScreen => ServiceLocator.Get<HomeScreen>();
        private GameOverScreen GameOverScreen => ServiceLocator.Get<GameOverScreen>();
        
        [SerializeField] private Level _testLevelPrefab;
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private BoxCollider _keyActivationArea;
        
        private PersistentInt _currentLevelIndex;
        private Level _currentSpawnedLevel;
        private Coroutine _levelLoopCoroutine;

        private void Start()
        {
            OpenHomeScreen();
        }
        
        #region Level Management Methods

        public void StartLevel()
        {
            InputController.OnKeyPressed += OnInputControllerKeyPressed;
            _currentSpawnedLevel = Instantiate(_testLevelPrefab, _levelContainer);
            _levelLoopCoroutine = CoroutineManager.BeginCoroutine(LevelLoopCoroutine());
        }

        public void EndLevel()
        {
            InputController.OnKeyPressed -= OnInputControllerKeyPressed;
            Destroy(_currentSpawnedLevel.gameObject);
            CoroutineManager.EndCoroutine(_levelLoopCoroutine);
        }
        
        private IEnumerator LevelLoopCoroutine()
        {
            SignalBus.Fire(new LevelStartedSignal(_currentSpawnedLevel));
            
            yield return new WaitForSeconds(0.1f);

            Vector3 startPos = _currentSpawnedLevel.StartLocalPosition;
            Vector3 endPos = startPos - _currentSpawnedLevel.EndLocalPosition;
            float distance = Vector3.Distance(startPos, endPos);
            float duration = distance / _currentSpawnedLevel.KeySpeed;
            
            _currentSpawnedLevel.KeyContainer.localPosition = startPos;
            
            yield return _currentSpawnedLevel.KeyContainer.DOLocalMove(endPos, duration)
                .SetEase(Ease.Linear)
                .WaitForCompletion();
            
            EndLevel();
            
            OpenGameOverScreen();
        }

        #endregion
        
        #region Gameplay Methods

        private void ProcessKeyPress(InputKeyType inputKey)
        {
            for (int i = _currentSpawnedLevel.Keys.Count - 1; i >= 0; i--)
            {
                BaseMusicKey musicKey = _currentSpawnedLevel.Keys[i];
                if (musicKey.Key == inputKey &&
                    CanBlastMusicKey(musicKey))
                {
                    BlastMusicKey(musicKey);
                    
                    _currentSpawnedLevel.Keys.Remove(musicKey);
                }
            }
        }

        private bool CanBlastMusicKey(BaseMusicKey musicKey)
        {
            if (_keyActivationArea.bounds.Intersects(musicKey.GetBounds()))
            {
                return true;
            }
            
            return false;
        }

        private void BlastMusicKey(BaseMusicKey musicKey)
        {
            SignalBus.Fire(new MusicKeyBlastedSignal(musicKey));
            
            musicKey.transform.DOScale(0.3f, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(musicKey.gameObject);
            });
        }

        #endregion
        
        #region UI Methods

        private void OpenHomeScreen()
        {
            HomeScreen.Setup(() =>
            {
                HomeScreen.Close();
                StartLevel();
            });
            
            HomeScreen.Open();
        }

        private void OpenGameOverScreen()
        {
            GameOverScreen.Setup(0, 0, () =>
            {
                GameOverScreen.Close();
                OpenHomeScreen();
            });
            GameOverScreen.Open();
        }

        #endregion

        private void OnInputControllerKeyPressed(InputKeyType inputKeyType)
        {
            ProcessKeyPress(inputKeyType);
        }
    }
}
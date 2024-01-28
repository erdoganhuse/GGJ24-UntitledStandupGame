using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Modules.Gameplay;
using Library.SignalBusSystem;
using Modules.Gameplay;
using Library.ServiceLocatorSystem;
using DG.Tweening;

public class ComedianSelector : MonoBehaviour
{
    private HomeScreen HomeScreen => ServiceLocator.Get<HomeScreen>();

    public GameObject[] CharacterGameObjects;

    public GameObject SelectedGameObject;

    private int currentIndex = 0;

    private Vector3 _jumpPosition;
    private Vector3 _originalPosition;

    public float JumpHeight = 0.3f;

    private void Start()
    {
        _originalPosition = transform.localPosition;
        _jumpPosition = _originalPosition + Vector3.up * JumpHeight;

        HomeScreen.OnLeft += () => SelectCharacter( (currentIndex-1<0)?(CharacterGameObjects.Length-1) : (currentIndex - 1) % CharacterGameObjects.Length);
        HomeScreen.OnRight += () => SelectCharacter((currentIndex + 1) % CharacterGameObjects.Length);
    }
    
    public void SelectCharacter(int index)
    {
        for(int i = 0; i < CharacterGameObjects.Length; i++)
        {
            CharacterGameObjects[i].SetActive(false);
        }

        CharacterGameObjects[index].SetActive(true);
        currentIndex = index;
                    
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOLocalMove(_jumpPosition, 0.075f));
        seq.Append(transform.DOLocalMove(_originalPosition, 0.075f));

        SignalBus.Fire(new CharacterSelectedSignal(CharacterGameObjects[index].GetComponent<ComedianName>().Name));
    }
}

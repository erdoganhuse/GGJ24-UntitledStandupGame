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

    private void Start()
    {
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
                    
        SignalBus.Fire(new CharacterSelectedSignal(CharacterGameObjects[index].GetComponent<ComedianName>().Name));
    }
}

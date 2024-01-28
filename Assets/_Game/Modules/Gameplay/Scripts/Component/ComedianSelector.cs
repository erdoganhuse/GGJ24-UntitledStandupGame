using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComedianSelector : MonoBehaviour
{
    public GameObject[] CharacterGameObjects;

    public GameObject SelectedGameObject;

    public void SelectCharacter(int index)
    {
        for(int i = 0; i < CharacterGameObjects.Length; i++)
        {
            CharacterGameObjects[i].SetActive(false);
        }

        CharacterGameObjects[index].SetActive(true);
    }
}

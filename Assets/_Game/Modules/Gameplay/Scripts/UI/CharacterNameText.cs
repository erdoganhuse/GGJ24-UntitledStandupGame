using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.SignalBusSystem;
using Modules.Gameplay;
using TMPro;


public class CharacterNameText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SignalBus.Subscribe<CharacterSelectedSignal>(OnCharacterSelected);
    }

    void OnCharacterSelected(CharacterSelectedSignal signal)
    {
        GetComponent<TextMeshProUGUI>().text = signal.CharacterName;
    }
}

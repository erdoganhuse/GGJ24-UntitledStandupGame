using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.SignalBusSystem;
using Modules.Gameplay;
using Library.ServiceLocatorSystem;
using DG.Tweening;

public class Comedian : MonoBehaviour
{
    private InputController InputController => ServiceLocator.Get<InputController>();

    private Transform _child;

    private Vector3 _jumpPosition;


    void Start()
    {
        _child = transform.GetChild(0);

        SignalBus.Subscribe<MusicKeyBlastedSignal>(OnMusicKeyBlasted);
    }

    private void OnMusicKeyBlasted(MusicKeyBlastedSignal signal)
    {
        _child.DOLocalMove(_jumpPosition, 0.1f);
    }
}

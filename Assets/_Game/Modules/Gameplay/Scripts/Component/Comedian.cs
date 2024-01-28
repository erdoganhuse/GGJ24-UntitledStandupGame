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

    private Vector3 _jumpPosition;
    private Vector3 _originalPosition;

    public float JumpHeight = 0.2f;


    void Start()
    {
        _originalPosition = transform.localPosition;
        _jumpPosition = _originalPosition + Vector3.up * JumpHeight;

        SignalBus.Subscribe<MusicKeyBlastedSignal>(OnMusicKeyBlasted);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            OnMusicKeyBlasted(null);
        }
    }

    private void OnMusicKeyBlasted(MusicKeyBlastedSignal signal)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOLocalMove(_jumpPosition, 0.05f));
        seq.Append(transform.DOLocalMove(_originalPosition, 0.05f));
    }
}

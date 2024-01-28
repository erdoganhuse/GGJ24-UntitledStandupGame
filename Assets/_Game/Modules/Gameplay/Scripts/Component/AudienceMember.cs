using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.SignalBusSystem;
using Modules.Gameplay;
using Library.ServiceLocatorSystem;
using DG.Tweening;

public class AudienceMember : MonoBehaviour
{
    private InputController InputController => ServiceLocator.Get<InputController>();

    private Vector3 _jumpPosition;
    private Vector3 _originalPosition;

    public float JumpHeight = 0.3f;

    public float Time = 0.075f;
    public float Delay = 0.075f;

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
        float rand = Random.Range(-1.0f, 10.0f);

        if(rand > 0)
        { 
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(Delay);
            seq.Append(transform.DOLocalMove(_jumpPosition, Time));
            seq.Append(transform.DOLocalMove(_originalPosition, Time));
            seq.Append(transform.DOLocalMove(_jumpPosition, Time));
            seq.Append(transform.DOLocalMove(_originalPosition, Time));
            seq.Append(transform.DOLocalMove(_jumpPosition, Time));
            seq.Append(transform.DOLocalMove(_originalPosition, Time));

            if(rand > 2)
            {
                seq.Append(transform.DOLocalMove(_jumpPosition, Time));
                seq.Append(transform.DOLocalMove(_originalPosition, Time));
            }
            if(rand > 4)
            {
                seq.Append(transform.DOLocalMove(_jumpPosition, Time));
                seq.Append(transform.DOLocalMove(_originalPosition, Time));
            }

            if(rand > 6)
            {
                seq.Append(transform.DOLocalMove(_jumpPosition, Time));
                seq.Append(transform.DOLocalMove(_originalPosition, Time));
            }

            if(rand > 8)
            {
                seq.Append(transform.DOLocalMove(_jumpPosition, Time));
                seq.Append(transform.DOLocalMove(_originalPosition, Time));
            }
        }
    }
}

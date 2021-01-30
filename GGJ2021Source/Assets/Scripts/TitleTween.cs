using System;
using UnityEngine;

public class TitleTween : MonoBehaviour
{
    public float tweenTime;

    private void Start()
    {
        Tween();
    }

    private void Tween()
    {
        LeanTween.cancel(gameObject);

        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambient/FadeIn", gameObject.transform.position);
        LeanTween.scale(gameObject, new Vector3(2, 2, 2), tweenTime).setEasePunch().setOnComplete(ScaleMe);
    }

    private void ScaleMe()
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 3).setLoopPingPong();
    }
}
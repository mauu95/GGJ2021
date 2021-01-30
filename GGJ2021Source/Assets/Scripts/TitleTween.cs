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

        LeanTween.scale(gameObject, new Vector3(3,3,3), tweenTime).setEasePunch();
    }
}
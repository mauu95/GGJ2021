using UnityEngine;
using UnityEngine.EventSystems;

namespace Audio
{
    public class UiButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/ButtonHover", gameObject.transform.position);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/ButtonClicked", gameObject.transform.position);
        }
    }
}
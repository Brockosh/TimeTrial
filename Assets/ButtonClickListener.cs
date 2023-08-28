using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickListener : MonoBehaviour
{
    private EventTrigger.Entry entry;
    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { OnButtonClick((PointerEventData)eventData); });
        trigger.triggers.Add(entry);
    }

    public void OnButtonClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject != null && clickedObject.tag == "UIButton")
        {
            myAudioSource.PlayOneShot(myAudioSource.clip);
            Debug.Log("Button Clicked");
        }
    }

     public void PlayButtonClickSound()
    {
        myAudioSource.PlayOneShot(myAudioSource.clip);
    }
}

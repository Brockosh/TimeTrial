using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            sliderText.text = v.ToString();

            float normalisedVolume = v / 100f;
            AudioManager.instance.SetVolume(normalisedVolume);
        });
        slider.value = 50;
    }
}

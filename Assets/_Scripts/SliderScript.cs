using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

    // Start is called before the first frame update
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
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

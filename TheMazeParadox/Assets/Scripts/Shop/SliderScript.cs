using System.Collections;
using System.Collections.Generic;
using TMPro; // Text Mesh Pro
using UnityEngine;
using UnityEngine.UI; // Unity UI

public class SliderScript : MonoBehaviour
{
    // SerializeField attribute allows private fields to be visible in the Unity Editor
    [SerializeField] private Slider _slider;          // Reference to a Unity UI Slider component
    [SerializeField] private TextMeshProUGUI _sliderText; // Reference to a Text Mesh Pro Text component

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the slider's onValueChanged event
        _slider.onValueChanged.AddListener((v) =>
        {
            // Update the Text Mesh Pro text with the slider's current value, formatted to "0"
            _sliderText.text = v.ToString("0");
        });
    }

    // Update is called once per frame
    void Update()
    {
        // This method is empty in this script, so no additional code is executed during Update.
    }
}

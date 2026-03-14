using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioService audioService;

    private void Start()
    {
        if (bgmSlider == null || sfxSlider == null || audioService == null)
        {
            Debug.LogError("UISetting missing reference!");
            return;
        }

        bgmSlider.value = audioService.GetBGMVolume();
        sfxSlider.value = audioService.GetSFXVolume();

        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    private void OnBGMChanged(float value)
    {
        audioService.SetBGMVolume(value);
    }

    private void OnSFXChanged(float value)
    {
        audioService.SetSFXVolume(value);
    }
}
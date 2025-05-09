using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Audio Sliders")]
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;

    [Header("Audio Sources")]
    [SerializeField] private AudioMixer _audioMixerMaster;

    [field: SerializeField] public AudioMixerGroup audioMixerMusic { get; private set; }
    [field: SerializeField] public AudioMixerGroup audioMixerSfx { get; private set; }

    void Start()
    {
        _masterVolumeSlider.value = PlayerParamsPreferences.GetMasterVolume();
        _musicVolumeSlider.value = PlayerParamsPreferences.GetMusicVolume();
        _sfxVolumeSlider.value = PlayerParamsPreferences.GetSFXVolume();

        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChange);
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        _sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChange);

        UpdateMasterVolume();
        UpdateMusicVolume();
        UpdateSFXVolume();
    }

    private void OnMasterVolumeChange(float value)
    {
        PlayerParamsPreferences.SetMasterVolume(value);
        UpdateMasterVolume();
    }

    private void OnMusicVolumeChange(float value)
    {
        PlayerParamsPreferences.SetMusicVolume(value);
        UpdateMusicVolume();

    }

    private void OnSFXVolumeChange(float value)
    {
        PlayerParamsPreferences.SetSFXVolume(value);
        UpdateSFXVolume();
    }

    private void UpdateMasterVolume()
    {
        _audioMixerMaster.SetFloat(PlayerParamsPreferences.PlayerPrefsMasterVol, Mathf.Log10(_masterVolumeSlider.value) * 20);
    }

    private void UpdateMusicVolume()
    {
        _audioMixerMaster.SetFloat(PlayerParamsPreferences.PlayerPrefsMusicVol, Mathf.Log10(_musicVolumeSlider.value) * 20);
    }

    private void UpdateSFXVolume()
    {
        _audioMixerMaster.SetFloat(PlayerParamsPreferences.PlayerPrefsSFXVol, Mathf.Log10(_sfxVolumeSlider.value) * 20);
    }

    private void OnDestroy()
    {
        _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChange);
        _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChange);
        _sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChange);
    }
}

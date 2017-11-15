using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioSettings : MonoBehaviour
{
	public Slider sfxSlider;
	public Slider musicSlider;
	public Slider voiceSlider;
	public Slider ambientalSlider;
	public Button saveButton;

	public void Start()
	{
		ConfigureSlider(sfxSlider, AudioManager.AudioChannel.SFX);
		ConfigureSlider(musicSlider, AudioManager.AudioChannel.Music);
		ConfigureSlider(voiceSlider, AudioManager.AudioChannel.Voice);
		ConfigureSlider(ambientalSlider, AudioManager.AudioChannel.Ambiental);

		saveButton.onClick.AddListener(SaveAudioSettings);
	}

	private void ConfigureSlider(Slider slider, AudioManager.AudioChannel channel)
	{
		if (!slider)
			return;

		slider.value = AudioManager.GetVolume(channel);

		slider.onValueChanged.AddListener((float value) => {
			AudioManager.SetVolume(channel, value);
		});
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			SaveAudioSettings();
		}
	}

	public void SaveAudioSettings()
	{
		AudioManager.SaveSettings();
	}

}
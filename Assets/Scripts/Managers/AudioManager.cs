using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager
{
	public enum AudioChannel
	{
		SFX,
		Voice,
		Music,
		Ambiental
	}

	public static float volumeSFX { get; private set; }
	public static float volumeVoice { get; private set; }
	public static float volumeMusic { get; private set; }
	public static float volumeAmbient { get; private set; }

	public static AudioSource backgroundMusic;
	public static List<AudioSource> voiceList = new List<AudioSource>();
	public static List<AudioSource> ambientList = new List<AudioSource>();
	private static bool initialized;

	public static void Init()
	{
		initialized = true;
		volumeSFX = PlayerPrefs.GetFloat("volumeSFX", 1);
		volumeVoice = PlayerPrefs.GetFloat("volumeVoice", 1);
		volumeMusic = PlayerPrefs.GetFloat("volumeMusic", 1);
		volumeAmbient = PlayerPrefs.GetFloat("volumeAmbient", 1);
	}

	public static float GetVolume(AudioChannel channel)
	{
		if (!initialized)
			Init();

		switch (channel)
		{
			case AudioChannel.Ambiental:
				return volumeAmbient;

			case AudioChannel.Music:
				return volumeMusic;

			case AudioChannel.SFX:
				return volumeSFX;

			case AudioChannel.Voice:
				return volumeVoice;
		}

		return 0;
	}

	public static void SetVolume(AudioChannel channel, float volume)
	{
		switch (channel)
		{
			case AudioChannel.Ambiental:
				volumeAmbient = volume;
				foreach (var source in ambientList)
				{
					source.volume = volumeAmbient;
				}
				break;

			case AudioChannel.Music:
				volumeMusic = volume;
				if (backgroundMusic)
					backgroundMusic.volume = volumeMusic;
				break;

			case AudioChannel.SFX:
				volumeSFX = volume;
				break;

			case AudioChannel.Voice:
				volumeVoice = volume;
				foreach (var source in voiceList)
				{
					source.volume = volumeVoice;
				}
				break;

			default:
				break;
		}
	}

	public static void SaveSettings()
	{
		PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
		PlayerPrefs.SetFloat("volumeVoice", volumeVoice);
		PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
		PlayerPrefs.SetFloat("volumeAmbient", volumeAmbient);
	}

	public static void PlaySFX(AudioSource source, float delay = 0)
	{
		source.volume = volumeSFX;
		source.PlayDelayed(delay);
	}

	public static void PlayVoice(AudioSource source, float delay = 0)
	{
		source.volume = volumeVoice;
		source.PlayDelayed(delay);

		// If source was not added, add it
		voiceList.Add(source);
	}

	public static void PlayBackgroundMusic(AudioSource source)
	{
		backgroundMusic = source;
	}

	public static void PlayAmbientalSound(AudioSource source, float delay = 0)
	{
		source.volume = volumeAmbient;
		source.PlayDelayed(delay);

		foreach (var S in ambientList)
		{
			if (S == source);
				return;
		}
		ambientList.Add(source);
	}

	public static void Play(AudioSource source, AudioChannel channel = AudioChannel.SFX, float delay = 0)
	{

	}
}
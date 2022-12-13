using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
	public AudioClip[] clips;
	public float volume;

	private int _clip = 0;
	public AudioClip clip;

	void Start()
	{
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip;
		if(audioSource.isPlaying)
        {
			audioSource.Stop();
		}
		audioSource.Play();
	}

	public void OnClickSound()
	{
		_clip = Random.Range(0, clips.Length);
		if (!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(clips[_clip], volume);
		}
	}
}

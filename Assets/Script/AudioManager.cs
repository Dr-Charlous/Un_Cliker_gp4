using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
	public AudioClip[] clips;
	public float volume;

	private int _clip = 0;

	public void OnClickSound()
	{
		_clip = Random.Range(0, clips.Length);
		audioSource.PlayOneShot(clips[_clip], volume);
	}
}

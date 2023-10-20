using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audios;
    public AudioSource source;

    public void PlayAudioAtPoint(int audioIndex){
        AudioSource.PlayClipAtPoint(audios[audioIndex], transform.position);
    }
    public void PlayAudioFromSource(int audioIndex){
        source.PlayOneShot(audios[audioIndex]);
    }

    public void PlayRandomAudioFromSource(int audioIndex){
        source.PlayOneShot(audios[Random.Range(audioIndex, audioIndex + 3)]);
    }
}

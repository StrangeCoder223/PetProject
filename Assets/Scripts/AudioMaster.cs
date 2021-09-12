using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour, ISounder
{
    [field:SerializeField]
    public SerializableDictionary<ClipType, AudioClip> AudioClips { get; set; }

    public void PlaySound(AudioSource source, ClipType type)
    {
        source.clip = AudioClips[type];
        source.Play();
    }
}

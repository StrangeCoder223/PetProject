using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClipType
{
    Shoot,
    Reload,
    Aim,

}
public interface ISounder
{
    public SerializableDictionary<ClipType, AudioClip> AudioClips { get; set; }

    public void PlaySound(AudioSource source, ClipType type);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffectKeyClipPair
{
    [SerializeField]
    private SoundEffectKey _key;
    public SoundEffectKey Key { get => _key; }
    [SerializeField]
    private AudioClip _soundEffect;
    public AudioClip SoundEffect { get => _soundEffect; }
}

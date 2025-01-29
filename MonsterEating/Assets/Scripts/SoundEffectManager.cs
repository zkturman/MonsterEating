using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _effectSource;
    [SerializeField]
    private SoundEffectKeyClipPair[] _soundEffects;
    private Dictionary<SoundEffectKey, AudioClip> _soundEffectMap;
    private static SoundEffectManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _soundEffectMap = _soundEffects.ToDictionary(x => x.Key, x => x.SoundEffect);
    }
    
    public static void PlayEffect(SoundEffectKey effectToPlay)
    {
        if (_instance._soundEffectMap.ContainsKey(effectToPlay))
        {
            _instance._effectSource.PlayOneShot(_instance._soundEffectMap[effectToPlay]);
        }
    }
}

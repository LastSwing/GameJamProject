using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonMonoBehaviour<MusicManager> {

    public AudioSource Bgm, SoundEffect;
    public void SetBgm(string path)
    {
        AudioClip o = Resources.Load<AudioClip>(path);
        Bgm.clip = o;
        Bgm.Play();
    }
    public void SetSoundEffect(string path)
    {
        AudioClip o = Resources.Load<AudioClip>(path);
        SoundEffect.clip = o;
        SoundEffect.Play();
    }
}

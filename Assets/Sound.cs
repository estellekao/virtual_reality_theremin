﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 3f)]
    public float volume;
    [Range(.1f, 10f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;


}
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AudioEntry {
    public string id;
    public AudioClip clip;
}

public class SoundDatabase : ScriptableObject {
    [Header("Music Clips")]
    public List<AudioEntry> music;

    [Header("SFX Clips")]
    public List<AudioEntry> sfx;
}

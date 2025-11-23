using System.Collections.Generic;
using UnityEngine;

public sealed class AudioAssetProvider : IAudioAssetProvider {
    private readonly Dictionary<string, AudioClip> music;
    private readonly Dictionary<string, AudioClip> sfx;

    public AudioAssetProvider(Dictionary<string, AudioClip> music, Dictionary<string, AudioClip> sfx) {
        this.music = music;
        this.sfx = sfx;
    }

    public AudioClip GetMusic(string id) {
        if(!music.ContainsKey(id)) {
            Debug.LogWarning($"Music track '{id}' not found.");
            return null;
        }
        return music.GetValueOrDefault(id);
    }

    public AudioClip GetSfx(string id) {
        return sfx.GetValueOrDefault(id);
    }
}

using System.Collections.Generic;
using UnityEngine;

public sealed class AudioFacade : IAudioFacade {
    private MusicSystem musicSystem;
    private SfxSystem sfxSystem;

    public AudioFacade(SoundDatabase soundDatabase, AudioSource musicSource, AudioSource sfxSource) {
        CreateAudioSystems(soundDatabase, musicSource, sfxSource);
    }

    public void PlayMusic(string trackId) {
        musicSystem.Play(trackId);
    }

    public void StopMusic() {
        musicSystem.Stop();
    }

    public void PlaySfx(string sfxId) {
        sfxSystem.PlayOneShot(sfxId);
    }

    public void MuteAll(bool mute) {
        musicSystem.Muted = mute;
        sfxSystem.Muted = mute;
    }

    private void CreateAudioSystems(SoundDatabase soundDatabase, AudioSource musicSource, AudioSource sfxSource) {
        Dictionary<string, AudioClip> musicDict = new() ;
        Dictionary<string, AudioClip> sfxDict = new();
        AudioAssetProvider assetProvider = new(musicDict, sfxDict);

        foreach(AudioEntry audioEntry in soundDatabase.music) {
            musicDict.TryAdd(audioEntry.id, audioEntry.clip);
        }

        foreach(AudioEntry audioEntry in soundDatabase.sfx) {
            sfxDict.TryAdd(audioEntry.id, audioEntry.clip);
        }

        // build subsystems
        musicSystem = new(musicSource, assetProvider);
        sfxSystem = new(sfxSource, assetProvider);
    }

}

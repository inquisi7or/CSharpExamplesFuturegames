using UnityEngine;

public sealed class MusicSystem {
    private readonly AudioSource musicSource;
    private readonly IAudioAssetProvider assetProvider;

    public bool Muted { get; set; }

    public MusicSystem(AudioSource musicSource, IAudioAssetProvider assetProvider) {
        this.musicSource = musicSource;
        this.assetProvider = assetProvider;
    }

    public void Play(string trackId) {
        AudioClip clip = assetProvider.GetMusic(trackId);
        if(clip == null) {
            Debug.LogWarning($"Music track '{trackId}' not found.");
            return;
        }

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.mute = Muted;
        musicSource.Play();
    }

    public void Stop() {
        musicSource.Stop();
    }
}

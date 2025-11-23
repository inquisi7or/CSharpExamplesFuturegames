using UnityEngine;

public sealed class SfxSystem {
    private readonly AudioSource _sfxSource;
    private readonly IAudioAssetProvider assetProvider;

    public bool Muted { get; set; }

    public SfxSystem(AudioSource sfxSource, IAudioAssetProvider assetProvider) {
        _sfxSource = sfxSource;
        this.assetProvider = assetProvider;
    }

    public void PlayOneShot(string sfxId) {
        AudioClip clip = assetProvider.GetSfx(sfxId);
        if(clip == null) {
            Debug.LogWarning($"SFX '{sfxId}' not found.");
            return;
        }

        _sfxSource.mute = Muted;
        _sfxSource.PlayOneShot(clip);
    }
}

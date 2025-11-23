using UnityEngine;

public interface IAudioAssetProvider {
    AudioClip GetMusic(string id);
    AudioClip GetSfx(string id);
}

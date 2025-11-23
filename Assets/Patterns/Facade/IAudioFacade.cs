using UnityEngine;

public interface IAudioFacade {
    void PlayMusic(string trackId);
    void StopMusic();
    void PlaySfx(string sfxId);
    void MuteAll(bool mute);
}

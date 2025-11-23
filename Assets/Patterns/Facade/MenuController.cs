using UnityEngine;

public class MenuController : MonoBehaviour {
    [SerializeField] private SoundDatabase soundDatabase;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private AudioFacade audioFacade;

    private void Awake() {
        audioFacade = new AudioFacade(soundDatabase, musicSource, sfxSource);
    }

    private void Start() {
        audioFacade.PlayMusic("menu");
    }

    public void OnActionPerformed() {
        audioFacade.PlaySfx("click");
        audioFacade.PlayMusic("game");
    }

    public void MuteAll(bool shouldMute) {
        audioFacade.MuteAll(shouldMute);
    }
}

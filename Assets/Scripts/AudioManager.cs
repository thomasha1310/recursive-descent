// random sound shit

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource sfxSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip cardPlaySound;
    [SerializeField] private AudioClip crashOutScream;     // "Play screaming noise"
    [SerializeField] private AudioClip timmyQuack;
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip defeatSound;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        // sfxSource.PlayOneShot(clip)
        // TODO
    }

    // Convenience methods
    public void PlayAttack() => PlaySFX(attackSound);
    public void PlayHeal() => PlaySFX(healSound);
    public void PlayCardPlay() => PlaySFX(cardPlaySound);
    public void PlayCrashOut() => PlaySFX(crashOutScream);
    public void PlayQuack() => PlaySFX(timmyQuack);
}

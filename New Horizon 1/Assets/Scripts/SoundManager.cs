using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // audio source declaration
    public AudioSource sfxSource;
    public AudioSource musicSource;
    
    // T-Cell sound declaration
    public AudioClip[] tCellShoot = new AudioClip[6];
    public AudioClip[] tCellSteps = new AudioClip[1];
    public AudioClip[] cytotoxinSplash = new AudioClip[1];

    // Cancer pig sound declaration
    public AudioClip[] cancerPigHit = new AudioClip[1];
    public AudioClip[] cancerPigAmbient = new AudioClip[1];

    // Menu sound declaration
    public AudioClip[] menuSounds = new AudioClip[1];

    // Background track declaration
    public AudioClip[] backgroundTrack = new AudioClip[1];

    // Get some pitch change in repetitive sound effects
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    // Singleton
    public static SoundManager SM = null;

    void Awake()
    {
        // Audio source initialization
        //audioS = GetComponent<AudioSource>();

        // Singleton check
        if (SM == null)
            SM = this;
        else if (SM != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Methods for calling the sounds
    #region Sound Methods

    public void PlaySingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void RandomizeSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        sfxSource.pitch = randomPitch;
        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();
    }

    // T-Cell firing noises
    //public void TCellShoot()
    //{
    //    audioS.PlayOneShot(tCellShoot[Random.Range(0, tCellShoot.Length)]);
    //}

    //// OPTIONAL T-Cell walking sounds
    //public void TCellSteps()
    //{

    //}

    //// Bullet despawn (hit) noises
    //public void CytotoxinSplash()
    //{
    //    audioS.PlayOneShot(cytotoxinSplash[Random.Range(0, cytotoxinSplash.Length)]);
    //}

    //// Cancer Pigs hitting the aveola
    //public void CancerPigHit()
    //{

    //}

    //// Ambient sounds for Cancer Pig movement
    //public void CancerPigAmbient()
    //{

    //}

    //// Menu beep sounds for navigation feedback
    //public void MenuSounds(int soundNumber)
    //{

    //}

    //// Background music method
    //public void BackgroundTrack()
    //{
    //    audioS.PlayOneShot(backgroundTrack[0]);
    //}
    #endregion
}

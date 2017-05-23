using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SetupAudio : MonoBehaviour
{
    private AudioSource source;

    public enum CustomClips
    {
        Explosion_Player,
        Explosion_Asteroid,
        Explosion_Enemy,
        Weapon_PlayerShot,
        Weapon_EnemyShot,
        Music_Background
    }

    public CustomClips currentSound;

    public float volume = 0.5f;

    public bool bPlayOnAwake = true;

    void Start()
    {
        source = GetComponent<AudioSource>();
        AllocateClip();
        AdjustVolume();
        if(bPlayOnAwake)
            source.Play();
    }

    void AllocateClip()
    {
        switch (currentSound)
        {
            case CustomClips.Explosion_Player:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.explosionPlayer);
                break;
            case CustomClips.Explosion_Asteroid:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.explosionAsteroid);
                break;
            case CustomClips.Explosion_Enemy:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.explosionEnemy);
                break;
            case CustomClips.Weapon_PlayerShot:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.playerWeapon);
                break;
            case CustomClips.Weapon_EnemyShot:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.enemyWeapon);
                break;
            case CustomClips.Music_Background:
                source.clip = (AudioClip)Resources.Load(AudioLibrary.backgroundMusic);
                break;
        }
    }

    void AdjustVolume()
    {
        source.volume = volume;
    }
}

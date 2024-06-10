using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip achievementClip;
    public AudioClip swordAttackClip;
    public AudioClip collectClip;
    public AudioClip levelUpClip;
    public AudioClip enemyDeath;
    public AudioClip bowAttackClip;
    public AudioClip arrowHit;
    public AudioClip playerDeath;
    public AudioClip enemyAttack;
    public AudioClip playerWalking;

    public void PlayAchievementSound()
    {
        PlaySFX(achievementClip);
    }

    public void PlayAttackSound()
    {
        PlaySFX(swordAttackClip);
    }

    public void PlayCollectSound()
    {
        PlaySFX(collectClip);
    }

    public void PlayLevelUpSound()
    {
        PlaySFX(levelUpClip);
    }
    
    public void PlayEnemyDeathSound()
    {
        PlaySFX(enemyDeath);
    }

    public void PlayBowAttackSound()
    {
        PlaySFX(bowAttackClip);
    }

    public void PlayArrowHitSound()
    {
        PlaySFX(arrowHit);
    }

    public void PlayPlayerDeathSound()
    {
        PlaySFX(playerDeath);
    }

    public void PlayEnemyAttackSound()
    {
        PlaySFX(enemyAttack);
    }

    public void PlayPlayerWalkingSound()
    {
        PlaySFX(playerWalking);
    }

    private void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}

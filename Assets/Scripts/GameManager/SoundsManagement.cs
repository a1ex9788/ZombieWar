using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManagement : MonoBehaviour
{
    private static AudioSource audioSource;
    public AudioClip enemyDeath1;
    public AudioClip enemyDeath2;
    public AudioClip gameOverClip;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayEnemyDeathSound(int number)
    {
        switch (number) {

            case 1: audioSource.clip = enemyDeath1; break;

            case 2: audioSource.clip = enemyDeath2; break;

        }
        audioSource.Play();
    }

    public void PlayGameOverSound() {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}

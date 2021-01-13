using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shotPoint;

    public PlayerMovement playerMovement;

    public AudioSource audioSource;

    public void Shoot() {
        Instantiate(bullet, shotPoint.transform.position, Quaternion.Euler(0f, 0f, playerMovement.weaponRotation));
        audioSource.Play();
    }
}

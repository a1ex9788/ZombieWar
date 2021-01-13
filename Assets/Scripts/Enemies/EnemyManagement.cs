using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public float health = 3;
    public float timeToMove;
    public float distance;

    private GameObject player;
    private SoundsManagement soundsManagement;

    private float count;

    private void Start()
    {
        player = GameObject.Find("Player");
        soundsManagement = GameObject.Find("GAMEMANAGER").GetComponent<SoundsManagement>();
    }

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= timeToMove) {
            Move();
            count = 0;
        }

        SpriteManagement();
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            string name = gameObject.name.Substring(0, 11);
            switch (name)
            {
                case "SmallZombie": soundsManagement.PlayEnemyDeathSound(1); FindObjectOfType<EnemiesSpawner>().numEnemies--; break;

                case "BigZombie": soundsManagement.PlayEnemyDeathSound(2); break;
            }

            EnemiesCounter.SumOne();

            Destroy(gameObject);
        }
    }

    private void Move() {
        string name = gameObject.name.Substring(0, 11);
        switch (name) {

            case "SmallZombie":
                System.Random r = new System.Random();
                float x = (float)r.NextDouble(); if (r.Next(0, 2) == 0) { x = -x; }
                float y = (float)r.NextDouble(); if (r.Next(0, 2) == 0) { y = -y; }
                Vector3 randomDirection = new Vector3(x, y);

                gameObject.transform.position += randomDirection * distance;

                break;

            case "BigZombie(C":
                Vector3 direction = new Vector3(player.transform.position.x - gameObject.transform.position.x,
                    player.transform.position.y - gameObject.transform.position.y);
                gameObject.transform.position += direction * distance;

                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player") {
            collision.collider.GetComponent<PlayerHealth>().TakeDamage(1, gameObject.transform.position);
        }
    }

    private void SpriteManagement() {
        if (player != null) {
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }        
    }
}

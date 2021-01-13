using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource audioSource;
    public SoundsManagement soundsManagement;

    public GameObject endPanel;
    public Text endMessage;
    public Text countText;
    public Sprite diedSprite;
    public GameObject weapon;

    public int maxHealth;
    public int health;
    public float force;

    public Text healthText;
    public Text maxHealthText;

    private void Start()
    {
        string aux1 = "", aux2 = "";
        for (int i = 0; i < maxHealth; i++) {
            if (i < health) aux1 += " I";
            aux2 += " I";
        }
        for (int i = 0; i < (maxHealth - health) * 2; i++) {
            aux1 = " " + aux1;
        }
        aux1 = aux1.Substring(1);
        aux2 = aux2.Substring(1);

        healthText.text = aux1;
        maxHealthText.text = aux2;
    }

    public void TakeDamage(int damage, Vector3 enemyPosition)
    {
        health -= damage;

        if (health <= 0) //Die
        {
            healthText.text = "";
            soundsManagement.PlayGameOverSound();
            FindObjectOfType<EnemiesSpawner>().enabled = false;

            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            gameObject.GetComponent<SpriteRenderer>().sprite = diedSprite;
            Destroy(weapon);
            gameObject.GetComponent<PlayerMovement>().enabled = false;

            Invoke("ShowEndPanel", 1);
        }
        else { //Health--
            audioSource.Play();
            gameObject.transform.position += new Vector3(-enemyPosition.x, -enemyPosition.y) * force;

            string aux = healthText.text.Substring((maxHealth - health) * 2);
            healthText.text = "";
            for (int i = health; i < maxHealth; i++)
            {
                healthText.text += "  ";
            }
            healthText.text += aux;
        }
    }

    private void ShowEndPanel() {
        endPanel.SetActive(true);

        endMessage.text = "You killed " + countText.text + " zombies";
    }
}

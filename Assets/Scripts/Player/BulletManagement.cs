using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagement : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;

    public GameObject explodingEffect;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectOfType<PlayerMovement>().toRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distance);
        if (hitInfo.collider != null)
        {
            string tag = hitInfo.collider.tag;
            if (tag == "Enemy")
            {
                hitInfo.collider.GetComponent<EnemyManagement>().TakeDamage(1);
            }
            Instantiate(explodingEffect, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}

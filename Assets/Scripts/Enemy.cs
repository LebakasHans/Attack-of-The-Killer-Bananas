using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Tombstone;
    public int Speed = 1;
    public int Health = 3;
    public List<Color> colors = new();

    Transform Target;
    Animator Anim;
    SpriteRenderer SpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Target = GameObject.Find("Player").transform;

        if (colors.Count > 0)
        {
            Color color = colors[Random.Range(0, colors.Count)];
            color.a = 1;
            SpriteRenderer.color = color;
        }
        else
            SpriteRenderer.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        //flip x if enemy is moving right
        if (transform.position.x < Target.position.x)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (transform.position.x > Target.position.x)
            GetComponent<SpriteRenderer>().flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Health--;
            if (Health <= 0)
            {
                Anim.SetBool("IsDead", true);
                Instantiate(Tombstone, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
            Destroy(collision.gameObject);
        }
    }
}

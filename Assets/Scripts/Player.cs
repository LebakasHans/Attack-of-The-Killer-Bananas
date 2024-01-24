using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float Speed = 5;
    public float Health = 5;
    public GameObject projectile;

    Animator animator;
    SpriteRenderer spriteRenderer;
    float actualSpeed;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualSpeed = Speed / 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return; 

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var isWalking = h != 0 || v != 0;
        animator.SetBool("isWalking", isWalking);

        if (h < 0)
            spriteRenderer.flipX = true;
        if (h > 0)
            spriteRenderer.flipX = false;

        gameObject.transform.position = new Vector2(transform.position.x + (h * actualSpeed),
         transform.position.y + (v * actualSpeed));


        //on left click instantiate the projectile in the direction of the mouse
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - transform.position).normalized;
            projectileInstance.transform.up = direction;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Trip")
        {
            float randomRotation = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(0, 0, randomRotation);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead)
            return;

        if (collision.gameObject.tag == "Enemy")
        {
            Health--;

            if (Health <= 0)
            {
                isDead = true;
                spriteRenderer.enabled = false;
            }

            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Rigidbody2D>().simulated = false;
            Invoke("UndoInvincibility", 1);
        }
    }

    private void UndoInvincibility()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Rigidbody2D>().simulated = true;
    }
}

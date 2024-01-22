using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = speed / 700;
    }

    // Update is called once per frame
    void Update()
    {
        //Readability 100 Unlocked
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var isWalking = h != 0 || v != 0;
        animator.SetBool("isWalking", isWalking);

        if (h < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        if (h > 0)
            GetComponent<SpriteRenderer>().flipX = false;

        gameObject.transform.position = new Vector2(transform.position.x + (h * speed),
         transform.position.y + (v * speed));
    }
}

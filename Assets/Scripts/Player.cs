using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    public float speed = 5;
    public GameObject projectile;

    Animator animator;
    float actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        actualSpeed = speed / 150;
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


}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //generate a number between 0 and 2
        var colorId = Random.Range(0, 3);

        GetComponent<Animator>().SetInteger("colorId", colorId);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

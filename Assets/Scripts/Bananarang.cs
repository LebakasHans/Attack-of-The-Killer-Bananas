using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananarang : MonoBehaviour
{

    public float throwForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * throwForce; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

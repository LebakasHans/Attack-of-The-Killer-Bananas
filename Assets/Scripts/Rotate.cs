using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true) {
            transform.Rotate(0, 0, 25);
            yield return new WaitForSeconds(0.02f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

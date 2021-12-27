using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    private float timer = 0;
    private float flip = 3;
    private bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= flip)
        {
            right = !right;
            timer = 0;
        }

        if (right == true)
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime;
        }
    }
}


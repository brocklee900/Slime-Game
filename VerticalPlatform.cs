using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private float timer = 0;
    private float flip = 3;
    private bool up = true;

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
            up = !up;
            timer = 0;
        }

        if (up == true)
        {
            transform.position += new Vector3(0, .75f, 0) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(0, .75f, 0) * Time.deltaTime;
        }
    }
}

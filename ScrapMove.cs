using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {   
            if (rend.flipX == true)
            {
                rend.flipX = false;
            }
            transform.position += new Vector3(0.3f, 0, 0) * Time.deltaTime;
            anim.SetBool("IsMoving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rend.flipX == false)
            {
                rend.flipX = true;
            }
            transform.position -= new Vector3(0.3f, 0, 0) * Time.deltaTime;
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}

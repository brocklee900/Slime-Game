using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShotLeft : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(3f, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("ShotSplat");
        }
        anim.SetTrigger("Splat");
        Destroy(gameObject, .15f);
    }
}

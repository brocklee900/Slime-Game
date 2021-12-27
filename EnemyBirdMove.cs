using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdMove : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1.5f, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "SlimeShot")
        {
            anim.SetTrigger("DamageTaken");
            Destroy(gameObject, .15f);
        }
    }
}

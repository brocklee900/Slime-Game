using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockMove : MonoBehaviour
{
    private float hitPoints = 3;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.5f, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "SlimeShot")
        {
            hitPoints -= 1;
            anim.SetTrigger("DamageTaken");

            if (hitPoints < 1)
            {
                Destroy(gameObject, .15f);
            }
        }
        
    }
}

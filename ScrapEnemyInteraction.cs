using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private int healthPoints = 3;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Vector3 direction = (transform.position - other.transform.position).normalized;
            anim.SetTrigger("DamageTaken");
            body.AddForce(transform.up * 150f);
            healthPoints -= 1;


        }
    }
}

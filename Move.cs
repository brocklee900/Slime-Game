using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Animator screenAnim;
    public Animator victAnim;
    public GameObject slimeShotLeft;
    public GameObject slimeShotRight;
    public Transform shooterLeft;
    public Transform shooterRight;
    private Animator playerAnim;
    private SpriteRenderer rend;
    private Rigidbody2D body;
    private Vector2 velocity = new Vector2(0, 0);
    public float hitPoints = 3;


    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moving Left and Right
        if (screenAnim.GetBool("IsGameOver") == false && victAnim.GetBool("Victory") == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rend.flipX == true)
                {
                    rend.flipX = false;
                }
                transform.position += new Vector3(3f, 0, 0) * Time.deltaTime;
                playerAnim.SetBool("IsMoving", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rend.flipX == false)
                {
                    rend.flipX = true;
                }
                transform.position -= new Vector3(3f, 0, 0) * Time.deltaTime;
                playerAnim.SetBool("IsMoving", true);
            }
            else
            {
                playerAnim.SetBool("IsMoving", false);
            }


            // Jumping and Falling
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (body.velocity == velocity)
                {
                    FindObjectOfType<AudioManager>().Play("Jump");
                    body.AddForce(transform.up * 175);

                }
            }


            // Animation for Jumping/Falling
            if (body.velocity.y > 0)
            {
                playerAnim.SetBool("IsJumping", true);
            }
            else
            {
                playerAnim.SetBool("IsJumping", false);
            }

            if (body.velocity.y < 0)
            {
                playerAnim.SetBool("IsFalling", true);
            }
            else
            {
                playerAnim.SetBool("IsFalling", false);
            }

            //Shooting Command and Animation
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<AudioManager>().Play("Shoot");
                playerAnim.SetTrigger("Shooting");
                if (rend.flipX == false)
                {
                    Instantiate(slimeShotRight, shooterRight.position, new Quaternion(0, 0, 0, 0));
                }
                else
                {
                    Instantiate(slimeShotLeft, shooterLeft.position, new Quaternion(0, 0, 0, 0));
                }
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("WorldStart");
            }
        }




        
        

        //Code For Damage Knockback
        //if (body.velocity.x == 0 && body.velocity.y == 0)
        //{
        //    enableInput = true;
        //}
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (screenAnim.GetBool("IsGameOver") == false && victAnim.GetBool("Victory") == false)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Fire")
            {
                //Code For Damage Knockback
                //Vector3 direction = (transform.position - other.transform.position).normalized;
                //anim.SetTrigger("DamageTaken");
                //body.AddForce(direction * 100f);
                body.AddForce(transform.up * 150f);
                playerAnim.SetTrigger("DamageTaken");
                if (other.gameObject.tag == "Fire")
                {
                    FindObjectOfType<AudioManager>().Play("FlameDamage");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("NormalDamage");
                }

                hitPoints -= 1;
                if (hitPoints < 1)
                {
                    FindObjectOfType<AudioManager>().Play("GameOver");
                    FindObjectOfType<AudioManager>().StopPlaying("Theme");
                    screenAnim.SetBool("IsGameOver", true);
                    playerAnim.SetBool("IsGameOver", true);
                }
                //enableInput = false;

            }

            if (other.gameObject.tag == "MovingPlatform")
            {
                this.transform.parent = other.transform;
            }

            if (other.gameObject.tag == "Heal")
            {
                FindObjectOfType<AudioManager>().Play("Heal");
                Destroy(other.gameObject);
                if (hitPoints < 3)
                {
                    hitPoints += 1;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }
}
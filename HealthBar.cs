using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Texture zero;
    public Texture one;
    public Texture two;
    public Texture three;
    public GameObject player;
    private Move playerScript;
    private RawImage ri;

    void Awake()
    {
        ri = GetComponent<RawImage>();
        playerScript = player.GetComponent<Move>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.screenAnim.GetBool("IsGameOver") == true)
        {
            ri.texture = zero;
        }
        else if (playerScript.hitPoints == 1)
        {
            ri.texture = one;
        }
        else if (playerScript.hitPoints == 2)
        {
            ri.texture = two;
        }
        else
        {
            ri.texture = three;
        }
    }
}

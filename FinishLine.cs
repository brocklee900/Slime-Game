using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Transform player;
    public Animator victoryAnim;
    private bool queue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position;
        Vector3 flagBase = transform.position;
        if (playerPosition[0] > flagBase[0])
        {
            victoryAnim.SetBool("Victory", true);
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            if (queue == false)
            {
                FindObjectOfType<AudioManager>().Play("Victory");
                queue = true;
            }
        }
    }
}

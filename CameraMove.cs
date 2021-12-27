using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Animator screenAnimator;
    public Move move;
    private Vector3 offset = new Vector3(0, 0, -10);
    private bool queue = false;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Camera movement
        Vector3 playerPosition = target.position + offset;
        Vector3 cameraPosition = transform.position;
        if (playerPosition[0] > cameraPosition[0] + 1)
        {
            cameraPosition[0] = playerPosition[0];
            cameraPosition[0] -= 1;
            transform.position = cameraPosition;
        }
        else if (playerPosition[0] < cameraPosition[0] - 1)
        {
            cameraPosition[0] = playerPosition[0];
            cameraPosition[0] += 1;
            transform.position = cameraPosition;
        }

        //Falling off the map
        playerPosition = target.position;
        if (playerPosition[1] < -2.5)
        {
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            if (queue == false && screenAnimator.GetBool("IsGameOver") == false)
            {
                FindObjectOfType<AudioManager>().Play("GameOver");
                queue = true;
            }
            
            screenAnimator.SetBool("IsGameOver", true);
        }
    }
}

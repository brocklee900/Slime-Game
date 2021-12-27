using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallSpawn : MonoBehaviour
{
    public GameObject spikeBall;
    private float spawn = 2;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            timer += Time.deltaTime;
            if (timer >= spawn)
            {
                Instantiate(spikeBall, transform);
                timer = 0;
            }
        }
    }
}

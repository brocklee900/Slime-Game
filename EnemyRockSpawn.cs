using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockSpawn : MonoBehaviour
{
    public GameObject rock;
    private float spawn = 3.5f;
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
                Instantiate(rock, transform);
                timer = 0;
            }
        }
    }
}

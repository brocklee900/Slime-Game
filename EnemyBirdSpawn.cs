using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdSpawn : MonoBehaviour
{
    public GameObject bird;
    private float spawn = 5;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawn)
        {
            Instantiate(bird, transform);
            timer = 0;
        }
    }

}

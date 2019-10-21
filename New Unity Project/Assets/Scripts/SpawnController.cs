using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static Vector3 spawnPos;
    public static bool needToSpawn;
    public static Quaternion rot;

    public GameObject track1;
    public GameObject track2;

    public static int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = Vector3.zero;
        needToSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(needToSpawn)
        {
            if(index == 0)
            {
                Instantiate(track2, spawnPos, rot);
                index++;
            }
            else
            {
                Instantiate(track1, spawnPos, rot);
                index = 0;
            }
            
            needToSpawn = false;
        }
    }
}

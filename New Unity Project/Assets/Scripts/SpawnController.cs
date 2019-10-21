using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static Vector3 spawnPos;
    public static bool needToSpawn;
    public static Quaternion rot;

    public GameObject track1;

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
            Instantiate(track1, spawnPos, rot);
            needToSpawn = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    private float timer;
    private float speedMultiplier;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
        speedMultiplier = TrainMovement.speedOfTrain;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 25f/speedMultiplier)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}

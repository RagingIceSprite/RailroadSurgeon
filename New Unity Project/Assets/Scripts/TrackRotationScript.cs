using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRotationScript : MonoBehaviour
{

    public int trackDirection;
    public int lastTrackDirection;
    public GameObject leftTrack;
    public GameObject rightTrack;
    public GameObject straightTrack;

    // Start is called before the first frame update
    void Start()
    {
        lastTrackDirection = trackDirection;
    }

    void Awake()
    {
        lastTrackDirection = trackDirection;
        //Debug.Log(lastTrackDirection);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        

        if (lastTrackDirection != -1 && trackDirection == -1)
        {
            //Debug.Log("lastTrack: " + lastTrackDirection);
            //Debug.Log("track: " + trackDirection);
            Instantiate(leftTrack, transform.position, transform.rotation, transform.parent);
            //Debug.Log("heyyyyyyyyyyy");
            Destroy(transform.gameObject);

        }
        else if (lastTrackDirection != 0 && trackDirection == 0)
        {
            Instantiate(straightTrack, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
        else if(lastTrackDirection != 1 && trackDirection == 1)
        {
            Instantiate(rightTrack, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }

        lastTrackDirection = trackDirection;
    }
}

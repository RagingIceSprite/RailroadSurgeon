using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrackScript : MonoBehaviour
{
    public int trackDirection; // -1: left, 0: straight, 1: right
    public Transform nextTrack;

    private Vector3 trackOne;
    private Vector3 trackTwo;
    private Vector3 trackThree;

    // Start is called before the first frame update
    void Awake()
    {
        trackOne = new Vector3(11, 0, 0);
        trackTwo = Vector3.zero;
        trackThree = new Vector3(-11, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log(trackDirection);
            if (this.gameObject.layer == LayerMask.NameToLayer("Track 1"))
            {
                if(trackDirection == -1)
                {
                    // left
                    UIupdate.gameOver = true;
                }
                else if(trackDirection == 0)
                {
                    // straight (do nothing I think)
                    //TrainMovement.nextTrack = trackOne;
                }
                else
                {
                    // right
                    TrainMovement.leftTurnStarted = true;
                    TrainMovement.nextTrack = trackTwo;
                }
            }
            else if(this.gameObject.layer == LayerMask.NameToLayer("Track 2"))
            {
                if (trackDirection == -1)
                {
                    // left
                    TrainMovement.leftTurnStarted = true;
                    TrainMovement.nextTrack = trackOne;
                }
                else if (trackDirection == 0)
                {
                    // straight (do nothing I think)
                    //TrainMovement.nextTrack = trackTwo;
                }
                else
                {
                    // right
                    TrainMovement.leftTurnStarted = true;
                    TrainMovement.nextTrack = trackThree;
                }
            }
            else if (this.gameObject.layer == LayerMask.NameToLayer("Track 3"))
            {
                if (trackDirection == -1)
                {
                    // left
                    TrainMovement.leftTurnStarted = true;
                    TrainMovement.nextTrack = trackTwo;
                }
                else if (trackDirection == 0)
                {
                    // straight (do nothing I think)
                    //TrainMovement.nextTrack = trackTwo;
                }
                else
                {
                    Debug.Log("heyy");
                    // right
                    UIupdate.gameOver = true;
                }
            }
        }
    }
}

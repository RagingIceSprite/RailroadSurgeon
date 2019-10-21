using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public bool triggerHit;
    public GameObject myPrefab;

    public static float speedOfTrain = 1f;
    public float trainSpeed = 1f;
    private Rigidbody rb;

    private int turnIndex;

    private bool isTurning;

    public static bool leftTurnStarted;

    public Transform pivotPlaceHolder;
    public Transform pivot;

    public static Vector3 nextTrack;

    private float oldX;

    private float timer = 0f;

    private float speedIncrease;


    // Start is called before the first frame update
    void Start()
    {
        triggerHit = false;
        rb = GetComponent<Rigidbody>();
        isTurning = false;
        leftTurnStarted = false;
        turnIndex = 0;
        oldX = 0f;
        timer = 0f;
        speedIncrease = trainSpeed * (1f / 3f);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if(timer >= 10f)
        {
            trainSpeed += speedIncrease;
            timer = 0f;
        }
        /*if(triggerHit)
        {
            Instantiate(myPrefab, GetComponentInChildren);
            triggerHit = false;
        }*/
        if(leftTurnStarted)
        {
            isTurning = true;
            leftTurnStarted = false;
            turnIndex = 0;
            oldX = rb.transform.position.x;
            Debug.Log("Old X: " + oldX);
            Debug.Log("Next Track X:" + nextTrack.x);
        }

        if(isTurning)
        {
            //Vector3 newPos = new Vector3(positions[turnIndex].position.x, rb.position.y, positions[turnIndex].position.z);
            //Vector3 newPos = Vector3.Lerp(rb.position, new Vector3(nextTrack.position.x, rb.position.y, rb.position.z), 0.1f);

            float newX;

            if(oldX > nextTrack.x && nextTrack.x == 0f)
            {
                newX = rb.transform.position.x - Mathf.Lerp(0f, 11f, 0.015f * trainSpeed);
            }
            else if (oldX > nextTrack.x && nextTrack.x == -11f)
            {
                newX = rb.transform.position.x - Mathf.Lerp(0f, 11f, 0.015f * trainSpeed);
            }
            else if (oldX < nextTrack.x && nextTrack.x == 0f)
            {
                newX = rb.transform.position.x + Mathf.Lerp(0f, 11f, 0.015f * trainSpeed);
            }
            else if (oldX < nextTrack.x && nextTrack.x == 11f)
            {
                newX = rb.transform.position.x + Mathf.Lerp(0f, 11f, 0.015f * trainSpeed);
            }
            else
            {
                newX = 0;
            }
            Vector3 newPos = new Vector3(newX, rb.transform.position.y, rb.transform.position.z);
            if (Mathf.Abs(newX - nextTrack.x) < 0.2f)
            {
                newPos.x = nextTrack.x;
                isTurning = false;
            }
                
            newPos += new Vector3(0, 0, -1)*0.25f * trainSpeed;
            rb.rotation = (Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(-(newPos - rb.position), Vector3.up), 0.1f*trainSpeed));
            rb.position = (newPos);
            
            turnIndex++;

            //Debug.Log("turning");
            
            //if (turnIndex == 17)
              //  isTurning = false;
        }
        else
        {
            //Debug.Log("not Turning");
            Vector3 newPos = rb.position + new Vector3(0, 0, -1)*0.25f * trainSpeed;
            rb.rotation = (Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(-(newPos - rb.position), Vector3.up), 0.1f * trainSpeed));
            rb.position = (newPos);
        }

        //rb.MovePosition(rb.position + new Vector3(0, 0, -1));

        pivot.position = new Vector3(0, pivotPlaceHolder.position.y, pivotPlaceHolder.position.z);
    }

    private void Update()
    {
        speedOfTrain = trainSpeed;
    }
}

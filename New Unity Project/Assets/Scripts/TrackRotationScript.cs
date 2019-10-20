using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRotationScript : MonoBehaviour
{

    public int trackDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (trackDirection == -1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -50, transform.rotation.eulerAngles.z);
        }
        else if (trackDirection == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 50, transform.rotation.eulerAngles.z);
        }
    }
}

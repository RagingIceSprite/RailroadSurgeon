using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackColliderTrigger : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject right;
    public Transform newPos;

    public static int index = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("Yoooo");

            if(index == 0)
            {
                GameObject temp = Instantiate(myPrefab, newPos.position, Quaternion.Euler(newPos.rotation.eulerAngles.x, -newPos.rotation.eulerAngles.y, newPos.rotation.eulerAngles.z));
                index++;
            }
            else
            {
                GameObject temp = Instantiate(right, newPos.position, Quaternion.Euler(newPos.rotation.eulerAngles.x, -newPos.rotation.eulerAngles.y, newPos.rotation.eulerAngles.z));
                index = 0;
            }
            



            //temp.transform.position = GetComponentInChildren<Transform>().position;

            //Debug.Log(GetComponentInChildren<Transform>().gameObject);
        }
    }
}

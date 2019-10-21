using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSwapScript : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button straightButton;
    private Vector3 mousePos;
    private bool mouseDown;

    private int currentTrackSelected;

    // Start is called before the first frame update
    void Start()
    {
        StraightButtonClicked();
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        if (!mouseDown)
        {
            mouseDown = Input.GetMouseButtonDown(0);
        }

        //leftButton.

        //Debug.Log(mouseDown);

    }

    private void FixedUpdate()
    {
        if (mouseDown)
        {
            //Debug.Log(mouseDown);
            RaycastHit hit;

            Vector3 point = new Vector3();
            //Event currentEvent = Event.current;
            //Vector2 mousePos = new Vector2();

            // Get the mouse position from Event.
            // Note that the y position from Event is inverted.
            //mousePos.x = currentEvent.mousePosition.x;
            //mousePos.y = Camera.main.pixelHeight - currentEvent.mousePosition.y;
            //point = new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z);

            point = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction*100, Color.red, 5f);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, LayerMask.GetMask("Track 1") | LayerMask.GetMask("Track 2") | LayerMask.GetMask("Track 3"), QueryTriggerInteraction.Ignore))
            {
                LeftTrackScript script = hit.transform.parent.GetComponent<LeftTrackScript>();
                script.trackDirection = currentTrackSelected;
                GameObject trackModel = FindChildObjectWithTag(hit.transform.parent, "Track");
                trackModel.GetComponent<TrackRotationScript>().trackDirection = currentTrackSelected;
                //track rotation
                
            }
            //Debug.Log(hit.transform.gameObject);
            mouseDown = false;
        }
    }

    public void LeftButtonClicked()
    {
        currentTrackSelected = -1;
        leftButton.Select();
    }

    public void RightButtonClicked()
    {
        currentTrackSelected = 1;
        rightButton.Select();
    }

    public void StraightButtonClicked()
    {
        currentTrackSelected = 0;
        straightButton.Select();
    }

    // method to find child game object with given tag
    public GameObject FindChildObjectWithTag(Transform p, string tag)
    {
        return GetChildObject(p, tag);
    }

    // helper method to find child game object with given tag
    private GameObject GetChildObject(Transform p, string tag)
    {
        if (p.childCount > 0)
        {
            for (int i = 0; i < p.childCount; i++)
            {
                
                Transform child = p.GetChild(i);
                //Debug.Log(child.name);
                if (child.tag.Equals(tag))
                {
                    return child.gameObject;
                }
                if (child.childCount > 0)
                {
                    GameObject temp = GetChildObject(child, tag);
                    if (temp != null)
                        return temp;
                }
            }
        }
        return null;
    }
}

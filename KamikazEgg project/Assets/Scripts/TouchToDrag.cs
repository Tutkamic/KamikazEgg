using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchToDrag : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneManagerScript;

    private float dist;

    public bool dragging = false;

    private Vector3 offset;
    private Vector3 startPosition;

    ISelectable selectable;

    private Transform toDrag;

    [SerializeField] LayerMask layerMask;

    GameObject grabbedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DragTouch();
    }

    void DragTouch()
    {
        if (Input.touchCount < 1 || sceneManagerScript.isIgnite == true)
            return;
        else if (Input.touchCount > 1 && dragging)
        {
            HandleTouchEnded();
        }

        Vector3 v3;
        Touch touch = Input.GetTouch(0);
        Vector3 pos = touch.position;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);



        if (touch.phase == TouchPhase.Began)
        {
            HandleTouchBegin();
        }
        else if (touch.phase == TouchPhase.Moved && dragging)
        {
            HandleTouchMoved();
        }
        else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && dragging)
        {
            HandleTouchEnded();
        }


        void HandleTouchBegin()
        {
            if (hit.collider == null)
                return;
            
            if (hit.collider.tag == "Explosive")
            {
                if (selectable != null)
                    selectable.UnSelect();
                selectable = hit.collider.gameObject.GetComponent<ISelectable>();
                selectable.Select();

                startPosition = hit.transform.position;
                grabbedObject = hit.collider.gameObject;
                toDrag = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;
                dragging = true;
                var rb = grabbedObject.GetComponent<Rigidbody2D>();

                rb.isKinematic = true;
                rb.useFullKinematicContacts = true;
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
                grabbedObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            
        }
        void HandleTouchMoved()
        {
            v3 = new Vector3(pos.x, pos.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }
        void HandleTouchEnded()
        {
            dragging = false;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;

            if (grabbedObject.GetComponent<Collider2D>().IsTouchingLayers(layerMask))
            {
                grabbedObject.transform.position = startPosition;
            }
        }
    }

}

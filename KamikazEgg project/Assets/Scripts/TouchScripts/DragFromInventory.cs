using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragFromInventory : MonoBehaviour
{
    GameObject draggedItem;

    [SerializeField] LayerMask layerMask;

    ISelectable selectedObject;

    bool isIgnite = false;
    bool dragging = false;
    bool startDrag = false;
    bool tap = false;

    int slotIndex;

    public static event Action<int> ShowInventoryItem;
    public static event Action<int, GameObject> HideInventoryItem;
    public static event Action<bool> InventoryItemDrag;
    public static event Action PutItemDown;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
        InventoryButtonPress.InventorySlotSelect += InventorySelect;
        InstantiateExplosives.DraggedInventoryItem += ItemToDrag;
    }

    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        InventoryButtonPress.InventorySlotSelect -= InventorySelect;
        InstantiateExplosives.DraggedInventoryItem -= ItemToDrag;
    }

    private void Update()
    {
        DragFromInv();
    }

    void DragFromInv()
    {
        if (Input.touchCount < 1 || isIgnite) return;
        else if (Input.touchCount > 1) 
        {
            if (dragging) EndDragHandler();
            else 
            {
                dragging = false;
                startDrag = false;
                tap = false;
            }

        }


        Touch touch = Input.GetTouch(0);
        Vector3 pos = touch.position;

        if(touch.phase == TouchPhase.Began)
        {
            tap = true;
        }
        if (touch.phase == TouchPhase.Moved && startDrag && tap)
        {
            StartDragHandler();
            DragHandler();
        }
        else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && draggedItem && startDrag)
        {
            EndDragHandler();
        }

        void StartDragHandler()
        {
            if (!dragging)
            {
                dragging = true;
                ShowInventoryItem?.Invoke(slotIndex);
                InventoryItemDrag?.Invoke(true);
            }
        }

        void DragHandler()
        {
            var touchOnScreen = Camera.main.ScreenToWorldPoint(pos);
            draggedItem.transform.position = new Vector3(touchOnScreen.x, touchOnScreen.y, 0);
            var rb = draggedItem.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.useFullKinematicContacts = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            draggedItem.transform.rotation = Quaternion.Euler(0f, 0f, 0f);


            selectedObject.Select();
        }
        void EndDragHandler()
        {
            tap = false;
            dragging = false;
            startDrag = false;
            InventoryItemDrag?.Invoke(false);
            draggedItem.GetComponent<Rigidbody2D>().isKinematic = false;


            if (draggedItem.GetComponent<CapsuleCollider2D>().IsTouchingLayers(layerMask))
            {
                DraggedFailed();
            }
            else 
            {
                draggedItem.GetComponent<ILastPositionHandler>().LastPositionSave();
                PutItemDown?.Invoke();
            }


        }
    }
    private void DraggedFailed()
    {
        HideInventoryItem?.Invoke(slotIndex, draggedItem);
        draggedItem.SetActive(false);
        selectedObject.UnSelect();
    }
    private void IgniteState(bool isOnFire) => isIgnite = isOnFire;
    private void ItemToDrag(GameObject item) 
    {
        if (selectedObject != null)  selectedObject.UnSelect();
        draggedItem = item;
        selectedObject = draggedItem.GetComponent<ISelectable>();
    }
    private void InventorySelect(int x)
    {
        slotIndex = x;
        startDrag = true;
    }


}

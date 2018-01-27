using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedItem;
    private Vector2 touchOffset;
    private Vector3 draggedObjectScale;
    private Vector3 draggedObjectStartPos;

    void Update()
    {
        if (HasInput)
        {
            DragOrPickUp();
        }
        else
        {
            if (draggingItem)
            {
                DropItem();
            }
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        if (draggingItem)
        {
            draggedItem.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];

                if (hit.transform != null && hit.transform.gameObject.CompareTag("InventoryItem") && hit.transform.GetComponent<IItemInterface>().OnCooldown == false)
                {
                    draggingItem = true;
                    draggedItem = hit.transform.gameObject;
                    draggedObjectScale = draggedItem.transform.localScale;
                    draggedObjectStartPos = draggedItem.transform.position;

                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    draggedItem.transform.localScale = new Vector3(draggedObjectScale.x * 1.2f, draggedObjectScale.y * 1.2f);
                }
            }
        }
    }

    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }

    void DropItem()
    {
        var inputPosition = CurrentTouchPosition;

        RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
        if (touches.Length > 0)
        {
            RaycastHit2D targetHit = new RaycastHit2D();
            RaycastHit2D presidentHit = new RaycastHit2D();
            for (int i = 0; i < touches.Length; i++)
            {
                if (touches[i].transform.CompareTag("DragAndDropTarget"))
                {
                    targetHit = touches[i];
                }
                if (touches[i].transform.CompareTag("president"))
                {
                    presidentHit = touches[i];
                }
            }
            
            if(targetHit.transform != null )
            {
                Debug.Log("drag and drop target hit");
                targetHit.transform.SendMessage("OnItemUse", draggedItem);
            }
            if (presidentHit.transform != null)
            {
                Debug.Log("president hit");
                presidentHit.transform.SendMessage("OnItemUse", draggedItem);
            }
        }
        
        draggingItem = false;
        draggedItem.transform.localScale = draggedObjectScale;
        draggedItem.transform.position = draggedObjectStartPos;
        draggedItem = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectFallDown : MonoBehaviour
{
    public static event Action<int, GameObject> ItemFallDown;

    [SerializeField] int itemIndex;
    ISelectable selectable;
    // Start is called before the first frame update
    void Start()
    {
        selectable = GetComponent<ISelectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y < -400 )
        {
            ItemFallDown?.Invoke(itemIndex, gameObject);
            selectable.UnSelect();
            gameObject.SetActive(false);
        }
    }
}

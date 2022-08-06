using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectFallDown : MonoBehaviour
{
    public static event Action<int, GameObject> ItemFallDown;

    [SerializeField] int itemIndex;
    ISelectable selectable;
    IExplosible explosible;
    // Start is called before the first frame update
    void Start()
    {
        selectable = GetComponent<ISelectable>();
        explosible = GetComponent<IExplosible>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y < -400 )
        {
            explosible.ResetPower();
            selectable.UnSelect();
            ItemFallDown?.Invoke(itemIndex, gameObject);
            gameObject.SetActive(false);
        }
    }
}

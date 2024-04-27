using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    GameObject droppedItem;
    Enemy e;
    bool itemDropped = false;
    void Start()
    {
        e = FindObjectOfType<Enemy>();  
    }
    void Update()
    {
        if (!itemDropped && e.health <= 0)
        {
            Instantiate(droppedItem, transform.position, Quaternion.identity);
            itemDropped = true;
        }
    }
}

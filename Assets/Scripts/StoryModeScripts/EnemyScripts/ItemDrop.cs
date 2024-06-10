using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    GameObject droppedItem;
    Enemy e;
    bool itemDropped = false;
    bool canDrop = false;
    void Start()
    {
        e = FindObjectOfType<Enemy>();
        CheckScene();
    }
    void Update()
    {
        if (canDrop && !itemDropped && e.health <= 0)
        {
            Instantiate(droppedItem, transform.position, Quaternion.identity);
            itemDropped = true;
        }
    }

    void CheckScene()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        if (currentscene.name == "Story Mode")
        {
            canDrop = true;
        }
    }
}

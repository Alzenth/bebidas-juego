using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public bool occupied;
    public bool occupiedA;
    public bool end;
    public GameObject client;

    private void Awake()
    {
        occupied = false;
    }

    private void Update()
    {
        /*if (client != null)
        {
            if (occupiedA)
            {
                if (end)
                {
                    client.GetComponent<Client>().end = end;
                }
            }
        }*/
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Person"))
        {
            occupied = true;
            client = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Person"))
        {
            occupied = false;
            client = null;
        }
    }
}

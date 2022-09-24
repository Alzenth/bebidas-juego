using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClient : MonoBehaviour
{
    public GameObject client;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(client, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

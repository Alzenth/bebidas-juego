using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Position position;

    // Update is called once per frame
    void Update()
    {
        if (position.client != null)
        {
            this.GetComponent<Slider>().value = 50f - position.client.GetComponent<Client>().time;
        }
        else { }
    }
}

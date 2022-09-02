using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    [HideInInspector]
    public bool fin = false;

    public float multi;
    public float valor;
    public bool detenerse;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            valor = this.GetComponent<Slider>().value;
            detenerse = true;
        }
        if (detenerse == true)
        {
            //this.GetComponent<Slider>().wholeNumbers = true;

            switch (valor)
            {
                case float n when ( n >= 0 && n <= 20):
                    Debug.Log("A");
                    break;
                case float n when (n >= 21 && n <= 40):
                    Debug.Log("B");
                    break;
                case float n when (n >= 41 && n <= 60):
                    Debug.Log("C");
                    break;

            }
           /* if (this.GetComponent<Slider>().value >= 0f && this.GetComponent<Slider>().value <= 20f)
            {
                Debug.Log("A");
            }
            if (this.GetComponent<Slider>().value >= 21f && this.GetComponent<Slider>().value <= 40f)
            {
                Debug.Log("B");
            }
            if (this.GetComponent<Slider>().value >= 41f && this.GetComponent<Slider>().value <= 60f)
            {
                Debug.Log("C");
            }
           */
        }
        else if(detenerse == false)
        {
            if (fin == false)
            {
                this.GetComponent<Slider>().value = this.GetComponent<Slider>().value + multi * Time.deltaTime;
            }

            else if (fin == true)
            {
                this.GetComponent<Slider>().value = this.GetComponent<Slider>().value - multi * Time.deltaTime;
            }

            if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().minValue)
            {
                fin = false;
            }
            else if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().maxValue)
            {
                fin = true;

            }
        }
        
    }
}

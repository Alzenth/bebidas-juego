using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    //variable para identificar cuando llegue al min y max de la barra
    [HideInInspector]
    public bool fin = false;

    //variable para que vaya mas rapido la variable
    public float multi;

    //variable que guarda en que valor se quedo la barra
    public float valor;

    //variable para saber si se detiene el slider
    public bool detenerse;

    private void Update()
    {
        if (detenerse == true)
        {
            //this.GetComponent<Slider>().wholeNumbers = true;

            //switch para que debe dar un valor segun que parte de la barra esta 
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
            //todo eso es ppara que el slider se mueva
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

    public void Detener()
    {
        detenerse = true;
        valor = this.GetComponent<Slider>().value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    public bool fin = false;
    public float multi;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
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
        //}
    }
    public void OnSliderController(float value)
    {
        
    
    }
}

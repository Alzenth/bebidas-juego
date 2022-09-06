using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libro : MonoBehaviour
{
    public GameObject libro;
    public GameObject boton;

    public void Iluminate()
    {
            libro.SetActive(true);
        boton.SetActive(true);
        this.gameObject.SetActive(false);
        
    }
    public void Apagate()
    {
            libro.SetActive(false);
        boton.SetActive(true);
        this.gameObject.SetActive(false);

    }
}

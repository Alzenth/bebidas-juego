using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libro : MonoBehaviour
{
    public GameObject libro;
    public bool abierto;

    public void Book()
    {
        if (abierto)
        {
            libro.SetActive(false);
            abierto = !abierto;
        }
        else
        {
            libro.SetActive(true);
            abierto = !abierto;
        }
    }
}

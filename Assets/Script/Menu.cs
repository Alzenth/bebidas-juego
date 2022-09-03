using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject boton;
    public void OnMenuActivo()
    {
        boton.SetActive(true);
    }
    public void OnMenuDesactivo()
    {
        boton.SetActive(false);
    }
}

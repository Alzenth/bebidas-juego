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
        Time.timeScale = 0;
    }
    public void OnMenuDesactivo()
    {
        boton.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{
    [Header("Gameplay")]
    public GameObject ordenTexto;
    public GameObject siguiente;

    public int faseActual;

    [Header("Fase 1")]
    public GameObject[] ingredientes;
    public GameObject botonDeReintentarFase1;

    public int sumaDeIngredientes;

    [Header("Fase 2")]
    public GameObject botonDeMezclar;

    public int numeroDeClics;
    public float rotVelo;

    [Header("Fase 3")]
    public GameObject botonDeServir;
    public GameObject barraDeTamaño;




    private void Start()
    {
        faseActual = 1;

        SiguienteFase();
    }

    private void Update()
    {
        if (sumaDeIngredientes == 4)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].GetComponent<Button>().interactable = false;
            }
            faseActual = 2;
        }
        if (sumaDeIngredientes >= 3)
        {
            siguiente.SetActive(true);
        }
        else
        {
            siguiente.SetActive(false);
        }
    }

    //metodo que los botones ocupan para dar un valor cada que se presiona no sirve para nd mas 
    public void Pulsacion()
    {
        sumaDeIngredientes += 1;
    }

    //metodo para las fases
    public void SiguienteFase()
    {
        if (faseActual == 1)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(true);
            }
            botonDeMezclar.SetActive(false);
        }
        if (faseActual == 2)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(false);
            }
            botonDeMezclar.SetActive(true);
        }
    }

    public void Girar()
    {
        botonDeMezclar.transform.Rotate(0, 0, rotVelo);
    }
}

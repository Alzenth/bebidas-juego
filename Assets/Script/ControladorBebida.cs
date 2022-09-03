using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{   //arreglo para guardar los botones
    public GameObject[] ingredientes;

    //botones
    public GameObject mezclador;
    public GameObject vaso;
    public GameObject siguiente;

    //arreglo que guardael valor de los ingredientes
    public int[] valor;

    //Contador de las veces que ppreesionas un boton(ingrediente)
    public int contador;

    //contador de que parte del preparado esta(ingredientes = 1, mezcla = 2,etc)
    public int fases;

    private void Start()
    {
        fases = 1;

        SiguienteFase();

        //guarda los el valor que tienen los ingredientes
        for (int i = 0; i < ingredientes.Length; ++i)
        {
            valor[i] = ingredientes[i].GetComponent<Valor>().val;
        }
    }

    private void Update()
    {
        if (contador == 4)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].GetComponent<Button>().interactable = false;
            }
            fases = 2;
        }
        if (contador >= 3)
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
        contador += 1;
    }

    //metodo para las fases
    public void SiguienteFase()
    {
        if (fases == 1)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(true);
            }
            mezclador.SetActive(false);
            vaso.SetActive(false);
        }
        if (fases == 2)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(false);
            }
            mezclador.SetActive(true);
            vaso.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{
    public GameObject[] ingredientes;
    public GameObject mezclador;
    public GameObject vaso;
    public GameObject siguiente;

    public int[] valor;

    public int contador;
    public int fases;

    private void Start()
    {
        fases = 1;
        SiguienteFase();
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

    public void Pulsacion()
    {
        contador += 1;
    }

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

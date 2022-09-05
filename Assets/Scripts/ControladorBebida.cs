using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{
    [Header("Gameplay")]
    public GameObject ordenTexto;
    public GameObject botonDeSiguiente;

    public int intentos;

    public int faseActual;

    [Header("Fase 1")]
    public GameObject[] ingredientes;
    public GameObject botonDeReintentarFase1;

    public int sumaDeIngredientes;

    [Header("Fase 2")]
    public GameObject botonDeMezclar;

    public static int numeroDeClics;
    public float rotVelo;

    [Header("Fase 3")]
    public GameObject botonDeServir;
    public GameObject barraDeTamaño;




    private void Start()
    {
        intentos = 2;

        faseActual = 1;

        SiguienteFase();
    }

    private void Update()
    {
        //FASE 1
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
            botonDeSiguiente.SetActive(true);
            botonDeReintentarFase1.SetActive(true);

        }
        else
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].GetComponent<Button>().interactable = true;
            }

            botonDeSiguiente.SetActive(false);
            botonDeReintentarFase1.SetActive(false);
        }
        //FASE 2
        if (numeroDeClics >= 3 && numeroDeClics < 5)
        {
            //clasico
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Clásicos;
        }
        if (numeroDeClics >= 5 && numeroDeClics < 7)
        {
            //especial
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Especiales;
        }
        if (numeroDeClics == 7)
        {
            //bloquear boton
            //batido
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Batidos;
        }
        if (numeroDeClics < 3)
        {
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Ninguno;
        }
    }

    //metodo que los botones ocupan para dar un valor cada que se presiona no sirve para nd mas 
    public void Pulsacion()//Fase 1
    {
        sumaDeIngredientes += 1;
    }
    public void PulsacionMezcla()//Fase 2
    {
        numeroDeClics += 1;
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

            botonDeServir.SetActive(false);
        }
        if (faseActual == 2)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(false);
            }
            botonDeMezclar.SetActive(true);

            botonDeReintentarFase1.SetActive(false);

            botonDeServir.SetActive(false);

            sumaDeIngredientes = 0;
        }
        if (faseActual == 3)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(false);
            }
            botonDeReintentarFase1.SetActive(false);

            botonDeMezclar.SetActive(false);

            botonDeServir.SetActive(true);

            botonDeSiguiente.SetActive(false);

            sumaDeIngredientes = 0;
        }
    }

    public void ReintentarFase1()
    {
        sumaDeIngredientes = 0;
        faseActual = 1;

    }
    public void ReiniciarIntento()
    {
        faseActual = 1;
        SiguienteFase();
        ReintentarFase1();

        intentos--;
    }
    public void Girar()
    {
        botonDeMezclar.transform.Rotate(0, 0, rotVelo);
    }
}

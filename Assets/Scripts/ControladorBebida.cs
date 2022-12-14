using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{
    [Header("Gameplay")]
    public GameObject ordenTexto;
    public GameObject botonDeSiguiente;
    public GameObject[] corazones;
    public Pasar pasar;
    public GameObject reintentar;
    public bool fallido = false;
    public int fresaNecesaria, naranjaNecesaria, piņaNecesaria, papayaNecesaria, platanoNecesaria, mangoNecesaria, granadillaNecesaria, lecheNecesaria;

    public string tipoDeBebidaNecesaria;

    public string tamaņoDeBebidaNecesaria;

    //public Text textVidas;
    public int intentos;
    public int numeroArreglo = 0;

    public int faseActual;

    public int nivelActual;
    public int recetasContadas;
    public Pedidos pedidos;
    public bool globoDesaparece;

    public ControladorPersonajes controladorPersonajes;

    [Header("Fase 1")]
    public GameObject[] ingredientes;
    public GameObject botonDeReintentarFase1;

    public int sumaDeIngredientes;

    [Header("Fase 2")]
    public GameObject botonDeMezclar;

    public static int numeroDeClics;
    public int copia;
    public float rotVelo;

    [Header("Fase 3")]
    public GameObject botonDeServir;
    public GameObject barraDeTamaņo;

    public float tamaņoVaso;


    private void Start()
    {
        NivelActual();
        intentos = 2;
        faseActual = 1;
        recetasContadas = 1;
        controladorPersonajes.nivelSgt = 1;
    }
    private void Awake()
    {
        numeroArreglo = 0;
    }

    private void Update()
    {
        if (intentos == 2)
        {
            corazones[0].SetActive(true);
            corazones[1].SetActive(true);
        }
        if (intentos == 1)
        {
            corazones[0].SetActive(true);
            corazones[1].SetActive(false);
        }
        if (intentos == 0)
        {
            corazones[0].SetActive(false);
            corazones[1].SetActive(false);
        }

        //textVidas.text = intentos.ToString();

        fresaNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].fresa;
        naranjaNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].naranja;
        piņaNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].piņa;
        papayaNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].papaya;
        platanoNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].platano;
        mangoNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].mango;
        granadillaNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].granadilla;
        lecheNecesaria = ordenTexto.GetComponent<Pedidos>().recetas[numeroArreglo].leche;
        #region FASE 1
        if (sumaDeIngredientes == 4)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].GetComponent<Button>().interactable = false;
            }
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
        #endregion
        #region FASE 2
        if (numeroDeClics >= 3 && numeroDeClics<= 7)
        {
            botonDeSiguiente.SetActive(true);
        }
        if (numeroDeClics >= 3 && numeroDeClics < 5)
        {
            //clasico
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Clásicos;
            tipoDeBebidaNecesaria = "Clásicos";
        }
        if (numeroDeClics >= 5 && numeroDeClics < 7)
        {
            //especial
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Especiales;
            tipoDeBebidaNecesaria = "Especiales";
        }
        if (numeroDeClics == 7)
        {
            //bloquear boton
            //batido
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Batidos;
            tipoDeBebidaNecesaria = "Batidos";
            botonDeMezclar.GetComponent<Button>().interactable = false;
        }
        if (numeroDeClics < 3)
        {
            BebidaActual.tipoDeBebida = BebidaActual.TipoDeBebida.Clásicos;
        }
        #endregion
        #region FASE 3
        tamaņoVaso = barraDeTamaņo.GetComponent<sliderController>().valor;

        if (tamaņoVaso >= 1 && tamaņoVaso <= 60)
        {
            botonDeSiguiente.SetActive(true);
        }
        if (tamaņoVaso >= 1 && tamaņoVaso <= 20)
        {
            BebidaActual.tamaņoDeBebida = BebidaActual.TamaņoDeBebida.Pequeņo;
            tamaņoDeBebidaNecesaria = "Pequeņo";
        }
        if (tamaņoVaso >= 21 && tamaņoVaso <= 40)
        {
            BebidaActual.tamaņoDeBebida = BebidaActual.TamaņoDeBebida.Mediano;
            tamaņoDeBebidaNecesaria = "Mediano";
        }
        if (tamaņoVaso >= 41 && tamaņoVaso <= 60)
        {
            BebidaActual.tamaņoDeBebida = BebidaActual.TamaņoDeBebida.Grande;
            tamaņoDeBebidaNecesaria = "Grande";
        }
        if (tamaņoVaso == 0)
        {
            BebidaActual.tamaņoDeBebida = BebidaActual.TamaņoDeBebida.Ninguno;
        }

        #endregion

        if (intentos <= 0)
        {
            reintentar.SetActive(true);
            Pedidos.recetaOrden = 1;
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
        faseActual++;
        switch (faseActual)
        {
            case 1:
                for (int i = 0; i < ingredientes.Length; ++i)
                {
                    ingredientes[i].SetActive(true);
                }
                botonDeMezclar.SetActive(false);

                botonDeServir.SetActive(false);

                barraDeTamaņo.SetActive(false);
                botonDeSiguiente.GetComponentInChildren<Text>().text = "Siguiente";

                fallido = false;
                break;

            case 2:
                for (int i = 0; i < ingredientes.Length; ++i)
                {
                    ingredientes[i].SetActive(false);
                }

                botonDeMezclar.SetActive(true); 
                
                botonDeMezclar.GetComponent<Button>().interactable = true;

                botonDeMezclar.transform.eulerAngles = new Vector3(0, 0, 0);

                botonDeSiguiente.GetComponentInChildren<Text>().text = "Siguiente";

                botonDeReintentarFase1.SetActive(false);

                barraDeTamaņo.SetActive(false);

                botonDeServir.SetActive(false);

                sumaDeIngredientes = 0;
                break;

            case 3:
                botonDeSiguiente.SetActive(false);
                BebidaActual.ReiniciarMezcla();
                for (int i = 0; i < ingredientes.Length; ++i)
                {
                    ingredientes[i].SetActive(false);
                }
                botonDeReintentarFase1.SetActive(false);

                botonDeMezclar.SetActive(false);

                botonDeServir.SetActive(true);

                barraDeTamaņo.SetActive(true);

                botonDeSiguiente.SetActive(false);
                botonDeSiguiente.GetComponentInChildren<Text>().text = "Servir";

                barraDeTamaņo.GetComponent<sliderController>().valor = 0;
                barraDeTamaņo.GetComponent<sliderController>().detenerse = false;
                barraDeTamaņo.GetComponent<Slider>().value = 0;

                sumaDeIngredientes = 0;
                break;
            case 4:
                for (int i = 0; i < ingredientes.Length; ++i)
                {
                    ingredientes[i].SetActive(false);
                }
                botonDeMezclar.SetActive(false);

                botonDeSiguiente.SetActive(false);

                botonDeReintentarFase1.SetActive(false);

                barraDeTamaņo.SetActive(false);

                botonDeServir.SetActive(false);

                faseActual++;
                Recetas();
                break;
        }
    }

    public void NivelActual()
    {
        if (recetasContadas < 4)
        {
           controladorPersonajes.nivelSgt = 1;
        }
        
        if (recetasContadas >= 4 && recetasContadas < 8)
        {
            nivelActual = 2;
            controladorPersonajes.nivelSgt = 2;
        }
        if (recetasContadas >= 8 && recetasContadas < 13)
        {
            nivelActual = 3;
            controladorPersonajes.nivelSgt = 3;
        }
    }

    public void ReintentarFase1()
    {
        sumaDeIngredientes = 0;
        faseActual = 0;
        SiguienteFase();

    }
    public void ReiniciarIntento()
    {
        faseActual = 0;
        SiguienteFase();
        ReintentarFase1();

        intentos--;
    }
    public void SiguienteOrden()
    {
        faseActual = 0;
        recetasContadas++;
        pasar.Siguiente();
        numeroDeClics = 0;
        sumaDeIngredientes = 0;
        BebidaActual.ReiniciarIntento();
        SiguienteFase();
        ReiniciarTamaņo();
        tamaņoVaso = 0;
        Pedidos.recetaOrden++;
        numeroArreglo++;
        globoDesaparece = false;
        NivelActual();
    }
    public void Girar()
    {
        botonDeMezclar.transform.Rotate(0, 0, rotVelo);
    }
    public void ReiniciarTamaņo()
    {
        barraDeTamaņo.GetComponent<sliderController>().valor = 0;
        barraDeTamaņo.GetComponent<sliderController>().detenerse = false;
        barraDeTamaņo.GetComponent<Slider>().value = 0;
    }

    public void Recetas()
    {

        if (fresaNecesaria != Pedidos.fresa)
        {
            fallido = true;
            Debug.Log("fresa");
        }
        if (naranjaNecesaria != Pedidos.naranja)
        {
            fallido = true;
            Debug.Log("naranja");
        }
        if (piņaNecesaria != Pedidos.piņa)
        {
            fallido = true;
            Debug.Log("piņa");
        }
        if (papayaNecesaria != Pedidos.papaya)
        {
            fallido = true;
            Debug.Log("papaya");
        }
        if (platanoNecesaria != Pedidos.platano)
        {
            fallido = true;
            Debug.Log("platano");
        }
        if (mangoNecesaria != Pedidos.mango)
        {
            fallido = true;
            Debug.Log("mango");
        }
        if (granadillaNecesaria != Pedidos.granadilla)
        {
            fallido = true;
            Debug.Log("granadilla");
        }
        if (lecheNecesaria != Pedidos.leche)
        {
            fallido = true;
            Debug.Log("leche");
        }
        if (tipoDeBebidaNecesaria != Pedidos.mezcla)
        {
            fallido = true;
            Debug.Log("mezcla");
        }
        if (tamaņoDeBebidaNecesaria != Pedidos.tamaņo)
        {
            fallido = true; Debug.Log("tama");
        }
        if (fallido == true)
        {
            intentos--;
        }
        SiguienteOrden();
    }
}
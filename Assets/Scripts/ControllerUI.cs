using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public Text orderText;

    public GameObject globoAlfa;

    public GameObject textoAlfa;

    public Receta[] recipe;
    public int recipeOrder;
    
    [Header("Fase 1")]
    public GameObject[] ingredients;
    public GameObject botonDeReintentarFase1;

    public int sumaDeIngredientes;

    [Header("Fase 2")]
    public GameObject botonDeMezclar;

    public static int numeroDeClics;
    public int copia;
    public float rotVelo;

    [Header("Fase 3")]
    public GameObject botonDeServir;
    public GameObject barraDeTamaño;

    private void Update()
    {
        Fhase1();
    }

    public void Fhase1()
    {
        if (sumaDeIngredientes == 4)
        {
            for (int i = 0; i < ingredients.Length; ++i)
            {
                ingredients[i].GetComponent<Button>().interactable = false;
            }
        }
        if (sumaDeIngredientes >= 3)
        {
           // botonDeSiguiente.SetActive(true);
            botonDeReintentarFase1.SetActive(true);

        }
        else
        {
            for (int i = 0; i < ingredients.Length; ++i)
            {
                ingredients[i].GetComponent<Button>().interactable = true;
            }

            //botonDeSiguiente.SetActive(false);
            botonDeReintentarFase1.SetActive(false);
        }
    }
  /*  public void IndicateOrder()
    {
        switch (recipeOrder)
        {

        }
    }
  */
}

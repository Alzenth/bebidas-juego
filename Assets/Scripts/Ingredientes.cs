using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredientes : MonoBehaviour
{
    public enum LosIngredientes
    {
        fresa, 
        naranja, 
        piña, 
        papaya, 
        platano, 
        mango, 
        granadilla, 
        leche
    }
    public LosIngredientes ingredientes;
    public void AgregarIngrediente()
    {
        switch (ingredientes)
        {
            case LosIngredientes.fresa:
                BebidaActual.fresaCantidad++;
                break;

            case LosIngredientes.naranja:
                BebidaActual.naranjaCantidad++;
                break;

            case LosIngredientes.piña:
                BebidaActual.piñaCantidad++;
                break;

            case LosIngredientes.papaya:
                BebidaActual.papayaCantidad++;
                break;

            case LosIngredientes.platano:
                BebidaActual.platanoCantidad++;
                break;

            case LosIngredientes.mango:
                BebidaActual.mangocantidad++;
                break;

            case LosIngredientes.granadilla:
                BebidaActual.granadillaCantidad++;
                break;

            case LosIngredientes.leche:
                BebidaActual.lecheCantidad++;
                break;
        }
    }
}


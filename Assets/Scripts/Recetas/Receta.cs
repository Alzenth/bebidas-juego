using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva receta", menuName = "Recetas")]
public class Receta : ScriptableObject
{

    public new string name;
    public int fresa, naranja, piña, papaya, platano, mango, granadilla, leche;

    public enum TipoDeBebida
    {
        Clásicos,
        Especiales,
        Batidos
    }
    public TipoDeBebida tipoDeBebida;
    /*
     public enum TamañoDeBebida
    {
        Pequeño,
        Mediano,
        Grande
    }
    public TamañoDeBebida tamañoDeBebida;
    */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public new string name;

    [TextArea(3, 15)]
    public string textoPedido;
    public int strawBerry,
        orange,
        pineapple,
        papaya,
        banana,
        mango,
        granadilla,
        milk;
 
    public string typeDrink;

    public string sizeDrink;
}

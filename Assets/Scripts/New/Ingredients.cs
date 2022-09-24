using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public ControllerUI controllerUI;
    public enum TheIngredients
    {
        strawBerry,
        orange,
        pineapple,
        papaya,
        banana,
        mango,
        granadilla,
        milk
    }
    public TheIngredients theIngredients;
    public void AddIngredients()
    {
        switch (theIngredients)
        {
            case TheIngredients.strawBerry:
                controllerUI.strawBerryButton++;
                break;

            case TheIngredients.orange:
                controllerUI.orangeButton++;
                break;

            case TheIngredients.pineapple:
                controllerUI.pineappleButton++;
                break;

            case TheIngredients.papaya:
                controllerUI.papayaButton++;
                break;

            case TheIngredients.banana:
                controllerUI.bananaButton++;
                break;

            case TheIngredients.mango:
                controllerUI.mangoButton++;
                break;

            case TheIngredients.granadilla:
                controllerUI.granadillaButton++;
                break;

            case TheIngredients.milk:
                controllerUI.milkButton++;
                break;
        }
    }
}

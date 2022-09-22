using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public Text orderText;
    public GameObject ballonAlpha;
    public GameObject textAlpha;

    public List<Recipe> recipe = new List<Recipe>();

    public float softened;

    public bool fail;

    [HideInInspector]
    public int strawBerry,
        orange,
        pineapple,
        papaya,
        banana,
        mango,
        granadilla,
        milk;


    public int strawBerryButton,
        orangeButton,
        pineappleButton,
        papayaButton,
        bananaButton,
        mangoButton,
        granadillaButton,
        milkButton;

    public int level;
    public int life = 2;
    public int numberList;
    public GameObject retryGeneral;
    public GameObject gameOver;
    public GameObject buttonNext;

    public int phaseCurrent;
    public bool start;
    //public int recipeOrder;

    [Header("Phase 1")]
    public GameObject[] ingredientsButtons;
    public GameObject buttonResetPhase1;

    public int ingredientsEntered;

    [Header("Phase 2")]
    public GameObject buttonMix;

    public static int numeroDeClics;
    public int copia;
    public float rotVelo;

    [Header("Phase 3")]
    public GameObject botonDeServir;
    public GameObject buttonSize;

    private void Start()
    {
        level = 1;
        fail = false;
    }

    private void Update()
    {
        CheckOrder();
        CheckIngredients();
    }
    private void Awake()
    {
        Phases();
    }

    public void DisappearBalloonText()
    {
        var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        var alphaText = textAlpha.GetComponent<Text>().color;

        alphaBallon.a = Mathf.Lerp(alphaBallon.a, 0f, softened * Time.deltaTime);

        alphaText.a = Mathf.Lerp(alphaText.a, 0f, softened * Time.deltaTime);

        if (alphaBallon.a <= 0.1f)
        {
            alphaText.a = 0f;
            alphaBallon.a = 0f;
        }
        ballonAlpha.GetComponent<RawImage>().color = alphaBallon;
        textAlpha.GetComponent<Text>().color = alphaText;
    }

    public void PopUpBallonText()
    {
        var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        var alphaText = textAlpha.GetComponent<Text>().color;

        alphaBallon.a = Mathf.Lerp(alphaBallon.a, 1f, softened * Time.deltaTime);

        alphaText.a = Mathf.Lerp(alphaText.a, 1f, softened * Time.deltaTime);

        if (alphaBallon.a >= 0.9f)
        {
            alphaText.a = 1f;
            alphaBallon.a = 1f;
            Phase1();
        }
        Debug.Log(alphaBallon);
        ballonAlpha.GetComponent<RawImage>().color = alphaBallon;
        textAlpha.GetComponent<Text>().color = alphaText;
    }
    public void CheckOrder()
    {
        if (ManaguerPosition.occupiedA == false)
        {
            int i = 1;
            if (i == 1)
            {
                DisappearBalloonText();
            }
        }
        else 
        {
            PopUpBallonText(); 
            Phase1();
        }
    }

    public void CheckIngredients()
    {
        strawBerry = recipe[numberList].strawBerry;
        orange = recipe[numberList].orange;
        pineapple = recipe[numberList].pineapple;
        papaya = recipe[numberList].papaya;
        banana = recipe[numberList].banana;
        mango = recipe[numberList].mango;
        granadilla = recipe[numberList].granadilla;
        milk = recipe[numberList].milk;
    }

    public void Phases()
    {
        phaseCurrent++;
        switch (phaseCurrent)
        {
            case 0:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].GetComponentInChildren<Button>().interactable = false;
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(false);

                buttonNext.SetActive(false);

                buttonResetPhase1.SetActive(false);
                break;

            case 1:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(true);
                    ingredientsButtons[i].GetComponentInChildren<Button>().interactable = true;
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(false);

                break;

            case 2:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(false);
                }

                buttonMix.SetActive(true);

                buttonSize.SetActive(false);
                break;

            case 3:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(false);
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(true);
                break;
        }
    }
    public void Phase1()
    {
        if (start)
        {
            Phases();
            start = false;
        }

        if (ingredientsEntered == 4)
        {
            for (int i = 0; i < ingredientsButtons.Length; ++i)
            {
                ingredientsButtons[i].GetComponentInChildren<Button>().interactable = false;
            }
        }
        if (ingredientsEntered >= 3)
        {
            buttonNext.SetActive(true);
            buttonResetPhase1.SetActive(true);

        }
        else
        {
            for (int i = 0; i < ingredientsButtons.Length; ++i)
            {
                ingredientsButtons[i].GetComponentInChildren<Button>().interactable = true;
            }
            buttonNext.SetActive(false);
            buttonResetPhase1.SetActive(false);
        }
    }

    public void Pulsation()
    {
        switch (phaseCurrent)
        {
            case 1:
                ingredientsEntered++;
                break;
        }
    }

    public void ResetPhase1()
    {
        ingredientsEntered = 0;
        strawBerryButton = 0;
        orangeButton = 0;
        pineappleButton = 0;
        papayaButton = 0;
        bananaButton = 0;
        mangoButton = 0;
        granadillaButton = 0;
        milkButton = 0;
    }
}

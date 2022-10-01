using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public Text orderText;
    public GameObject ballonAlpha;
    public GameObject textAlpha;
    public GameObject life1,life2;

    public List<Recipe> recipe = new List<Recipe>();

    public float softened;

    public bool fail;

    public int strawBerry,
        orange,
        pineapple,
        papaya,
        banana,
        mango,
        granadilla,
        milk;
    public string type,
        size;


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
    public GameObject positionOrder;
    public GameObject retryGeneral;
    public GameObject gameOver;
    public GameObject buttonNext;
    public ManaguerPosition managuerPosition;

    public int phaseCurrent;
    public bool start;
    //public int recipeOrder;

    [Header("Phase 1")]
    public GameObject[] ingredientsButtons;
    public GameObject buttonResetPhase1;

    public int ingredientsEntered;

    [Header("Phase 2")]
    public GameObject buttonMix;

    public int mixClicks;
    public string typeDrink;
    public int copia;
    public float rotVelo;
    public GameObject textMix;

    [Header("Phase 3")]
    public string sizeDrink;
    private float value;
    public float multiply;
    public bool pause, loop;
    public GameObject glass;
    public GameObject slider;
    public GameObject botonDeServir;
    public GameObject buttonSize;

    private void Start()
    {
        level = 1;
        fail = false;
    }

    private void Update()
    {
        DrinkOrder();
        CheckIngredients();
        if (life == 2)
        {
            life1.SetActive(true);
            life2.SetActive(true);
        }
        if (life == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }
        if (life == 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
        }
        if (life <= 0)
        {
            gameOver.SetActive(true);
        }
    }
    private void Awake()
    {
        CheckPhases();
    }

    public void DisappearBalloonText()
    {
        var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        var alphaText = textAlpha.GetComponent<Text>().color;
        /*
        alphaBallon.a = Mathf.Lerp(alphaBallon.a, 0f, softened * Time.deltaTime);

        alphaText.a = Mathf.Lerp(alphaText.a, 0f, softened * Time.deltaTime);

        if (alphaBallon.a <= 0.3f)
        {
            alphaText.a = 0f;
            alphaBallon.a = 0f;
        }*/
        alphaText.a = 0f;
        alphaBallon.a = 0f;
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
            Phases();
        }
       // Debug.Log(alphaBallon);
        ballonAlpha.GetComponent<RawImage>().color = alphaBallon;
        textAlpha.GetComponent<Text>().color = alphaText;
    }
    public void DrinkOrder()
    {
        if (ManaguerPosition.occupiedA == false)
        {
            int i = 1;
            if (i == 1)
            {
                positionOrder.GetComponent<Position>().end = false;
                start = true;   
                DisappearBalloonText();
            }
        }
        else 
        {
            Debug.Log("asd");
            PopUpBallonText(); 
            Phases();
            if (start)
            {   
                CheckPhases();
                start = false;
            }
        }
    }

    public void CheckIngredients()
    {
        orderText.text = recipe[numberList].textoPedido;
        strawBerry = recipe[numberList].strawBerry;
        orange = recipe[numberList].orange;
        pineapple = recipe[numberList].pineapple;
        papaya = recipe[numberList].papaya;
        banana = recipe[numberList].banana;
        mango = recipe[numberList].mango;
        granadilla = recipe[numberList].granadilla;
        milk = recipe[numberList].milk;
        type = recipe[numberList].typeDrink;
        size = recipe[numberList].sizeDrink;
    }

    public void CheckPhases()
    {
        phaseCurrent++;
        switch (phaseCurrent)
        {
            case 0:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(true);
                    ingredientsButtons[i].GetComponentInChildren<Button>().interactable = false;
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(false);

                buttonNext.SetActive(false);

                buttonResetPhase1.SetActive(false);

                slider.SetActive(false);
                textMix.SetActive(false);

                glass.SetActive(false);
                break;

            case 1:
                ResetGeneral();
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(true);
                    ingredientsButtons[i].GetComponentInChildren<Button>().interactable = true;
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(false);

                buttonResetPhase1.SetActive(false);

                break;

            case 2:

                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(false);
                }

                buttonNext.SetActive(false);

                buttonResetPhase1.SetActive(false);

                buttonMix.SetActive(true);

                textMix.SetActive(true);

                buttonSize.SetActive(false);
                break;

            case 3:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].SetActive(false);
                }

                slider.SetActive(true);
                glass.SetActive(true);
                buttonNext.SetActive(false);

                buttonMix.SetActive(false);
                textMix.SetActive(false);

                buttonSize.SetActive(true);
                break;

            case 4:
                for (int i = 0; i < ingredientsButtons.Length; ++i)
                {
                    ingredientsButtons[i].GetComponentInChildren<Button>().interactable = false;
                }

                buttonMix.SetActive(false);

                buttonSize.SetActive(false);

                buttonNext.SetActive(false);

                buttonResetPhase1.SetActive(false);

                slider.SetActive(false);

                glass.SetActive(false);

                CheckOrder();

                positionOrder.GetComponent<Position>().client.GetComponent<Client>().end = true;

                numberList++;

                phaseCurrent = -1;

                CheckPhases();

                break;
        }
    }

    public void CheckOrder()
    {
        if (orangeButton != orange)
        {
            fail = true;
        }
        if (pineappleButton != pineapple)
        {
            fail = true;
        }
        if (papayaButton != papaya)
        {
            fail = true;
        }
        if (bananaButton != banana)
        {
            fail = true;
        }
        if (mangoButton != mango)
        {
            fail = true;
        }
        if (granadillaButton != granadilla)
        {
            fail = true;
        }
        if (milkButton != milk)
        {
            fail = true;
        }
        if (typeDrink != type)
        {
            fail = true;
        }
        if (sizeDrink != size)
        {
            fail = true;
        }

        if (fail)
        {
            life--;
            fail = false;
        }
    }

    public void Phases()
    {
        if (phaseCurrent == 1)
        {
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

        if (phaseCurrent == 2)
        {
            if (mixClicks >= 3 && mixClicks <= 7)
            {
                buttonNext.SetActive(true);
            }
            if (mixClicks >= 3 && mixClicks < 4)
            {
                //clasico
                typeDrink = "Classic";
                textMix.GetComponent<Text>().text = typeDrink;
            }
            if (mixClicks >= 4 && mixClicks < 7)
            {
                //especial
                typeDrink = "Specials";
                textMix.GetComponent<Text>().text = typeDrink;
            }
            if (mixClicks >= 7)
            {
                //batido
                typeDrink = "Cream";
                textMix.GetComponent<Text>().text = typeDrink;
                buttonMix.GetComponent<Button>().interactable = false;
            }
            if (mixClicks < 7)
            {
                buttonMix.GetComponent<Button>().interactable = true;
            }
            if (mixClicks < 3)
            {
                typeDrink = "Ninguno";
                textMix.GetComponent<Text>().text = typeDrink;
            }
        }

        if (phaseCurrent == 3)
        {
            if (pause)
            {
                switch (value)
                {
                    case float n when (n >= 0 && n <= 20):
                        sizeDrink = "Small";
                        break;

                    case float n when (n >= 21 && n <= 40):
                        sizeDrink = "Medium";
                        break;

                    case float n when (n >= 41 && n <= 60):
                        sizeDrink = "Large";
                        break;
                }
            }
            else
            {
                if (loop == false)
                {
                    slider.GetComponent<Slider>().value = slider.GetComponent<Slider>().value + multiply * Time.deltaTime;
                }

                else if (loop == true)
                {
                    slider.GetComponent<Slider>().value = slider.GetComponent<Slider>().value - multiply * Time.deltaTime;
                }

                if (slider.GetComponent<Slider>().value == slider.GetComponent<Slider>().minValue)
                {
                    loop = false;
                }
                else if (slider.GetComponent<Slider>().value == slider.GetComponent<Slider>().maxValue)
                {
                    loop = true;

                }
            }
        }
    }
    public void Stop()
    {
        pause = true;
        buttonNext.SetActive(true);
        value = slider.GetComponent<Slider>().value;
    }
    public void Pulsation()
    {
        switch (phaseCurrent)
        {
            case 1:
                ingredientsEntered++;
                break;
            case 2:
                mixClicks++;
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

    private void ResetGeneral()
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
        mixClicks = 0; 
        slider.GetComponent<Slider>().value = 0;
        pause = false;
    }
}

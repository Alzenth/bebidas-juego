using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaguerPosition : MonoBehaviour
{
    public GameObject positionA, positionB, positionC;
    public static bool occupiedA, occupiedB, occupiedC;
    public bool occupieA, occupieB, occupieC;

    private void Awake()
    {
        occupiedA = false;
        occupiedB = false;
        occupiedC = false;
    }

    private void Update()
    {
        occupieA = occupiedA;
        occupieB = occupiedB;
        occupieC = occupiedC;

        occupiedA = positionA.GetComponent<Position>().occupied;
        occupiedB = positionB.GetComponent<Position>().occupied;
        occupiedC = positionC.GetComponent<Position>().occupied;
    }

}

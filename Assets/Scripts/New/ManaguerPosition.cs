using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaguerPosition : MonoBehaviour
{
    public GameObject positionA, positionB, positionC;
    public static bool occupiedA, occupiedB, occupiedC;
    public bool occupieA, occupieB, occupieC;
    public GameObject[] client;
    public float time;
    public int i = 1;

    private void Awake()
    {
        occupiedA = false;
        occupiedB = false;
        occupiedC = false;
        client[i].GetComponent<Client>().stateClient = Client.StateClient.AdvancePosition;
    }

    private void Update()
    {
        if (i < 4)
        {
            time += 1 * Time.deltaTime;
        }
        if (time >= 15 && occupieC == false && i < 5)
        {
            i++;
            client[i].GetComponent<Client>().stateClient = Client.StateClient.AdvancePosition;
            time = 0;
        }
        if (i == 4)
        {
            i = 0;
            time = 0;
        }
        occupieA = occupiedA;
        occupieB = occupiedB;
        occupieC = occupiedC;

        occupiedA = positionA.GetComponent<Position>().occupied;
        occupiedB = positionB.GetComponent<Position>().occupied;
        occupiedC = positionC.GetComponent<Position>().occupied;
    }

}

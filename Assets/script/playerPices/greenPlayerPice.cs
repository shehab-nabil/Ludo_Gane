using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenPlayerPice : playerPice
{

    RollingDice greenHomeRolingDice;
    void Start()
    {
        greenHomeRolingDice = GetComponentInParent<GreenHome>().rollingDice;
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {

            if (!isReady)
            {
                if (GameManager.gm.rollingDice == greenHomeRolingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    GameManager.gm.greenOutPlayer += 1;
                    makePlayerReadyToMove(pathParent.greenPathPoint);
                   GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }

            }
            if (GameManager.gm.rollingDice == greenHomeRolingDice && isReady && GameManager.gm.canPlayerMove)
            {

                GameManager.gm.canPlayerMove = false;
                moveSteps(pathParent.greenPathPoint);
            }


        }

    }



}


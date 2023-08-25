using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPlayerPice : playerPice
{

    RollingDice redHomeRolingDice;
    void Start()
    {
        redHomeRolingDice = GetComponentInParent<RedHome>().rollingDice;
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {

            if (!isReady)
            {
                if (GameManager.gm.rollingDice == redHomeRolingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    GameManager.gm.redOutPlayer += 1;
                    makePlayerReadyToMove(pathParent.redPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }

            }
            if (GameManager.gm.rollingDice == redHomeRolingDice && isReady && GameManager.gm.canPlayerMove)
            {

                GameManager.gm.canPlayerMove = false;
                moveSteps(pathParent.redPathPoint);
            }


        }

    }



}

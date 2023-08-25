using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPlayerPice : playerPice
{

    RollingDice YellowHomeRolingDice;
    void Start()
    {
        YellowHomeRolingDice = GetComponentInParent<YellowHome>().rollingDice;
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {

            if (!isReady)
            {
                if (GameManager.gm.rollingDice == YellowHomeRolingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    GameManager.gm.yellowOutPlayer += 1;
                    makePlayerReadyToMove(pathParent.yellowPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
                 
            }
            if (GameManager.gm.rollingDice == YellowHomeRolingDice && isReady && GameManager.gm.canPlayerMove)
            {

                GameManager.gm.canPlayerMove = false;
                moveSteps(pathParent.yellowPathPoint);
            }


        }

    }



}


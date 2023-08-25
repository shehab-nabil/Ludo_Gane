using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePlayerPice : playerPice
{
    RollingDice blueHomeRolingDice;
    void Start()
    {
        blueHomeRolingDice = GetComponentInParent<BlueHome>().rollingDice;
         
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        { 
        
            if (!isReady)
            {
                if (GameManager.gm.rollingDice == blueHomeRolingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove) { 
                    
                    GameManager.gm.blueOutPlayer += 1 ;
                    makePlayerReadyToMove(pathParent.bluePathPoint);
                    GameManager.gm.numberOfStepsToMove=0;
                    return;
                }
                
            }
            if (GameManager.gm.rollingDice == blueHomeRolingDice && isReady && GameManager.gm.canPlayerMove) 
            {   

                GameManager.gm.canPlayerMove = false;
                moveSteps(pathParent.bluePathPoint);
            }
           
            
        }
        
    }



}

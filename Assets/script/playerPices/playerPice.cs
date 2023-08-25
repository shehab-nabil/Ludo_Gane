using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPice : MonoBehaviour
{
    public bool moveNow;
    public bool isReady;
    public int numberOfStepsToMove;
    public int numberOfStepsAlreadyMoved;

    public pathObjectParent pathParent;
    Coroutine playerMovement;

    public pathPoint priviuosPathPoint;
    public pathPoint currentPathPoint;


    //path point calss
    private void Awake() { pathParent = FindObjectOfType<pathObjectParent>(); }
    //to start moving 
    public void moveSteps(pathPoint[] pathPointsToMoveOn_)
    {
        playerMovement = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));
    }
    public void makePlayerReadyToMove(pathPoint[] pathPointsToMoveOn_)
    {
        isReady = true;
        transform.position = pathPointsToMoveOn_[0].transform.position;
        numberOfStepsAlreadyMoved = 1;
        GameManager.gm.numberOfStepsToMove = 0;
       
        priviuosPathPoint = pathPointsToMoveOn_[0];
        currentPathPoint = pathPointsToMoveOn_[0];
        currentPathPoint.AddLayerPice(this); 
        GameManager.gm.AddPathPoint(currentPathPoint);

        GameManager.gm.rolingDiceTramsform();
       // GameManager.gm.canDiceRoll=true;    
    }

    //steps of the players on board
    IEnumerator MoveSteps_Enum(pathPoint[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.5f); 
        numberOfStepsToMove = GameManager.gm.numberOfStepsToMove;
        for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numberOfStepsToMove); i++)
        {
            // numberOfStepsToMove = GameManager.gm.numberOfStepsToMove;

            if (isPathPointAvailableToMove(numberOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_)) {
                currentPathPoint.RescaleAndRepositioningPlayersPice();
                 transform.position = pathPointsToMoveOn_[i].transform.position;
                GameManager.gm.ads.Play();
                yield return new WaitForSeconds(0.35f); //time of the step
            }
           
        }
        if (isPathPointAvailableToMove(numberOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
        {

            numberOfStepsAlreadyMoved += numberOfStepsToMove;



            GameManager.gm.RemovePathPoint(priviuosPathPoint);
            GameManager.gm.canPlayerMove = true;
            priviuosPathPoint.RemoveLayerPice(this);

            currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];
            GameManager.gm.canPlayerMove = true;
            bool transfer = currentPathPoint.AddLayerPice(this);
            currentPathPoint.RescaleAndRepositioningPlayersPice();
            GameManager.gm.AddPathPoint(currentPathPoint);
            priviuosPathPoint = currentPathPoint;
            if (transfer&& GameManager.gm.numberOfStepsToMove != 6) {
                
                
                    GameManager.gm.transferDice = true;
                
          
            }
           
            GameManager.gm.numberOfStepsToMove = 0;
        }
        GameManager.gm.canPlayerMove = true;
        GameManager.gm.rolingDiceTramsform();


        if (playerMovement != null) {

            StopCoroutine("MoveSteps_Enum");
        }

    }
  public  bool isPathPointAvailableToMove(int numberOfStepsToMove, int numberOfStepsAlreadyMoved, pathPoint[] pathPointsToMoveOn_) {

        if (numberOfStepsToMove == 0) {

            return false;
        }
        int leftNumberOfPath = pathPointsToMoveOn_.Length -numberOfStepsAlreadyMoved;
        if (leftNumberOfPath >= numberOfStepsToMove)
        {
            return true;
        }
        else {
            return false;
        }

    }
}

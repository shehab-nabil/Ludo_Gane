using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprits;
    [SerializeField] SpriteRenderer numberSpriteHolder;
    [SerializeField] SpriteRenderer rolingDiceAnimation;
    [SerializeField] int numberGot;
    
    Coroutine generateRandomNumberDice;
    int otPlayers ;
    int compPlayer;
    List<playerPice> playerPices;
    pathPoint[] curentPathPoint;
    public bool firstPlayerOut;
    public bool secondPlayerOut;
    public bool thirdPlayerOut;
    public bool fourthPlayerOut;



    public pathPoint scale;
    public playerPice curentPlayerPice;

    public DiceSound diceSound;
    public void OnMouseDown()
    {

        generateRandomNumberDice =StartCoroutine(rollDice());
    }
    public void MouseRole()
    {

        generateRandomNumberDice = StartCoroutine(rollDice());
    }
    IEnumerator rollDice() {

        yield return new WaitForEndOfFrame ();
        if (GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            diceSound.playSound();
            numberSpriteHolder.gameObject.SetActive(false);
            rolingDiceAnimation.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f); //time of the step
            int maxnum = 6;
            if (GameManager.gm.TotalSix == 2) { maxnum=5;GameManager.gm.TotalSix = 0; }
            numberGot = Random.Range(0, maxnum);
            if ( numberGot == 5) {GameManager.gm.TotalSix += 1; }
            numberSpriteHolder.sprite = numberSprits[numberGot];
            numberGot++;

            GameManager.gm.numberOfStepsToMove = numberGot;
            GameManager.gm.rollingDice = this;

            numberSpriteHolder.gameObject.SetActive(true);
            rolingDiceAnimation.gameObject.SetActive(false);
            outPlayer();

            if (playerCanMove()) 
            {
                if (otPlayers == 0) 
                { if (compPlayer == 0 ) {readyToMove(0); firstPlayerOut = true; FindObjectOfType<AudioManager>().Play("Out"); }
                  

                }
                else if (otPlayers == 4)
                {
                    curentPlayerPice.moveSteps(curentPathPoint);
                  

                }
                else 
                {
                    if (GameManager.gm.TotalPlayerCanPlay == 1 && otPlayers < 4 && GameManager.gm.numberOfStepsToMove==6) {
                        robotOut();
                    }
                    else
                    {

                        curentPlayerPice.moveSteps(curentPathPoint);


                    }
                    //curentPlayerPice.moveSteps(curentPathPoint);
                }

            }
            
            else
            {
                if (GameManager.gm.numberOfStepsToMove != 6 && otPlayers==0) {
                
                
                    yield return new WaitForSeconds(0.5f);
                    GameManager.gm.transferDice = true;
                   GameManager.gm.rolingDiceTramsform();
                
                }
                else if (GameManager.gm.numberOfStepsToMove != 6 && otPlayers == 1)
                {


                    yield return new WaitForSeconds(0.5f);
                    GameManager.gm.transferDice = true;
                    GameManager.gm.rolingDiceTramsform();

                }



            }
             
           
            //GameManager.gm.canDiceRoll =true;

            if (generateRandomNumberDice != null)
            {
                StopCoroutine(rollDice());
            }

        }
    }
    public void outPlayer()
    {
        if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[0]) {
            playerPices = GameManager.gm.bluePlayerPices;
            curentPathPoint = playerPices[0].pathParent.bluePathPoint;
            otPlayers =GameManager.gm.blueOutPlayer;
            compPlayer = GameManager.gm.blueCompletePlayer;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[1])
        {
            playerPices = GameManager.gm.redPlayerPices;
            curentPathPoint = playerPices[0].pathParent.redPathPoint;

            otPlayers = GameManager.gm.redOutPlayer;
            compPlayer= GameManager.gm.redCompletePlayer;   
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[2])
        {
            playerPices = GameManager.gm.greenPlayerPices;
            curentPathPoint = playerPices[0].pathParent.greenPathPoint;

            otPlayers = GameManager.gm.greenOutPlayer;
            compPlayer =GameManager.gm.greenCompletePlayer;    
        }
        else 
        {
            playerPices = GameManager.gm.yellowPlayerPices;
            curentPathPoint = playerPices[0].pathParent.yellowPathPoint;

            otPlayers = GameManager.gm.yellowOutPlayer;
            compPlayer=GameManager.gm.yellowCompletePlayer;
        }

    }
    public bool playerCanMove() {
        // pc players 
        if (GameManager.gm.TotalPlayerCanPlay == 1)
        {

            if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[2])// 2 is the number of player who will play as the pc
                                                                                 
            {

                if (otPlayers > 0) {
                    for (int i = 0; i < playerPices.Count; i++)
                    {
                        if (playerPices[i].isReady)
                        {
                            if (playerPices[i].isPathPointAvailableToMove(GameManager.gm.numberOfStepsToMove, playerPices[i].numberOfStepsAlreadyMoved, curentPathPoint))
                            {
                                curentPlayerPice = playerPices[i];
                                return true;
                            }
                        }
                    }
                }
            }

        }
       if ( otPlayers==1 &&GameManager.gm.numberOfStepsToMove != 6) 
        {
        
            for(int i = 0; i < playerPices.Count; i++) 
            {
                if (playerPices[i].isReady) 
                {
                    if (playerPices[i].isPathPointAvailableToMove(GameManager.gm.numberOfStepsToMove, playerPices[i].numberOfStepsAlreadyMoved, curentPathPoint))
                    {
                        curentPlayerPice = playerPices[i];
                        return true;
                    }
                }
            }

        }
       else if (otPlayers == 0 && GameManager.gm.numberOfStepsToMove == 6)
        {

            return true;    

        }

        return false;
    
    }
    void readyToMove(int pos) {

        if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[0])
        {
             GameManager.gm.blueOutPlayer+=1;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[1])
        {
         GameManager.gm.redOutPlayer += 1;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[2])
        {
            GameManager.gm.greenOutPlayer += 1;
        }
        else
        {
         GameManager.gm.yellowOutPlayer += 1;
        }
        playerPices[pos].makePlayerReadyToMove(curentPathPoint);

    }
    void robotOut()
    {


        for (int i = 0; i < playerPices.Count; i++)
        {
            if (playerPices[i].isReady)
            {
                readyToMove(i);
                return;
            }
        }
    }

}

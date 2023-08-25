using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager gm;
    public int numberOfStepsToMove;
    public RollingDice rollingDice;

    public bool canPlayerMove = true;

    public bool canDiceRoll = true ;
    public bool transferDice =false;
    //for the players in same point
    List<pathPoint>playersOnPathPointList = new List<pathPoint>();

   
    public List<RollingDice> rollingDiceslist;

    public int blueOutPlayer;
    public int redOutPlayer;
    public int greenOutPlayer;
    public int yellowOutPlayer;

    public int blueCompletePlayer;
    public int redCompletePlayer;
    public int greenCompletePlayer;
    public int yellowCompletePlayer;

    public int TotalPlayerCanPlay;
    public List<GameObject> playerHomes;
    public int TotalSix;

    public List<playerPice>bluePlayerPices;
    public List<playerPice>redPlayerPices;
    public List<playerPice> greenPlayerPices;
    public List<playerPice> yellowPlayerPices;

    public AudioSource ads;

    public bool win = false;


    private void Awake()
    {
        gm = this;
        ads = GetComponent<AudioSource>();
    }

    public void AddPathPoint(pathPoint pathpoint) 
    { 
        
    playersOnPathPointList.Add(pathpoint);
    
    }

    public void RemovePathPoint(pathPoint pathpoint) 
    {

        if (playersOnPathPointList.Contains(pathpoint)) {

            playersOnPathPointList.Remove(pathpoint);
        
        }

    }
    public void rolingDiceTramsform()
    {

        
        if (transferDice)
        {
            GameManager.gm.TotalSix = 0;
            transferRollingDice();


        }
        else
        {
            if (GameManager.gm.TotalPlayerCanPlay == 1)
            {

                if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceslist[2])
                {
                    Invoke("role", 0.6f);
                }

            }
        }
        
        canDiceRoll = true;
        transferDice = false;
    }
    void role() {

        rollingDiceslist[2].MouseRole();
    
     }
    void transferRollingDice() {
        int nextDice;
        if (GameManager.gm.TotalPlayerCanPlay == 1)
        {

            if (rollingDice == rollingDiceslist[0])
            {
                rollingDiceslist[0].gameObject.SetActive(false);
                rollingDiceslist[2].gameObject.SetActive(true);
                Invoke("role",0.6f);
            }
            else
            {

                rollingDiceslist[2].gameObject.SetActive(false);
                rollingDiceslist[0].gameObject.SetActive(true);
            }


        }
        else if (GameManager.gm.TotalPlayerCanPlay == 2) 
        { 
            if (rollingDice == rollingDiceslist[0])
            {
                rollingDiceslist[0].gameObject.SetActive(false);
                rollingDiceslist[2].gameObject.SetActive(true);

            }
            else
            {

                rollingDiceslist[2].gameObject.SetActive(false);
                rollingDiceslist[0].gameObject.SetActive(true);
            }

        }
        else if (GameManager.gm.TotalPlayerCanPlay == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 2) { nextDice = 0; } else { nextDice = i + 1; }
                i = pasOute(i);
                if (rollingDice == rollingDiceslist[i])
                {
                    rollingDiceslist[i].gameObject.SetActive(false);
                    rollingDiceslist[nextDice].gameObject.SetActive(true);


                }
            }

        }
        else if (GameManager.gm.TotalPlayerCanPlay == 4)
        {
            
            
            for (int i = 0; i < rollingDiceslist.Count; i++)
            {
               
                if (i == (rollingDiceslist.Count - 1)) { nextDice = 0; } else { nextDice = i + 1; }
                //i = pasOute(i);
                if (rollingDice == rollingDiceslist[i])
                {
                    rollingDiceslist[i].gameObject.SetActive(false);
                    rollingDiceslist[nextDice].gameObject.SetActive(true);
                }
               
            }

        }
    }
    int pasOute(int  i)
    {
        if (i == 0) { if (blueOutPlayer == 4) { return i + 1; } }
        else if (i == 1) { if (redOutPlayer == 4) { return i + 1; } }
        else if (i == 2) { if (greenOutPlayer == 4) { return i + 1; } }
        else if (i == 3) { if (yellowOutPlayer == 4) { return i + 1; } }
        //else { return i; }
        return i;
    }

}

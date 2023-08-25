using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathPoint : MonoBehaviour
{
    public pathObjectParent pathobjectparents;
    public List<playerPice>playerPicesList=new List<playerPice>();
    pathPoint[] pathPointToMoveOn_;
    RollingDice check;
    void Start()
    {
        pathobjectparents = GetComponentInParent<pathObjectParent>();
    }

    public bool AddLayerPice(playerPice playerPice_) 
    {
        if(this.name == "comonBluePath")
        {
            addPlayer(playerPice_);
            complete(playerPice_);
            //GameManager.gm.blueOutPlayer -= 1;
            //GameManager.gm.blueCompletePlayer += 1;
            return false;


        }
        if ( this.name == "comonRedPath")
        {
            addPlayer(playerPice_);
            complete(playerPice_);
            //GameManager.gm.redOutPlayer -= 1;
            //GameManager.gm.redCompletePlayer += 1;
            return false;

        }
        if ( this.name == "comonGreenPath" )
        {
            addPlayer(playerPice_);
            complete(playerPice_);
           // GameManager.gm.greenOutPlayer -= 1;
            //GameManager.gm.greenCompletePlayer += 1;
            return false;


        }
         if ( this.name == "comonYellowPath")
        {
            addPlayer(playerPice_);
            complete(playerPice_);
           // GameManager.gm.yellowOutPlayer -= 1;
            //GameManager.gm.yellowCompletePlayer += 1;
            return false;


        }
        if (!pathobjectparents.safePoint.Contains(this))
        {
            if (playerPicesList.Count == 1)
            {

                string preePlayerPiceName = playerPicesList[0].name;
                string curentPlayerPiceName = playerPice_.name;
                curentPlayerPiceName = curentPlayerPiceName.Substring(0, curentPlayerPiceName.Length - 4);
                if (!preePlayerPiceName.Contains(curentPlayerPiceName))
                {
                    playerPicesList[0].isReady = false;
                    StartCoroutine(reverOnStart(playerPicesList[0]));
                    playerPicesList[0].numberOfStepsAlreadyMoved = 0;
                    RemoveLayerPice(playerPicesList[0]);
                    playerPicesList.Add(playerPice_);
                    return false;
                }

            }
        }
        addPlayer(playerPice_);
        return true;
    
    }
    IEnumerator reverOnStart(playerPice playerPice_) {

        if (playerPice_.name.Contains("blue")) {
            
            GameManager.gm.blueOutPlayer -= 1; 
            pathPointToMoveOn_ = pathobjectparents.bluePathPoint; 
            
        }
        else if(playerPice_.name.Contains("red")) 
        {
           
            GameManager.gm.redOutPlayer -= 1;
            pathPointToMoveOn_ = pathobjectparents.redPathPoint;
          
        }
        else if (playerPice_.name.Contains("green")) 
        {
            
            GameManager.gm.greenOutPlayer -= 1;
            pathPointToMoveOn_ = pathobjectparents.greenPathPoint;
            
        }
        else 
        {
           
            GameManager.gm.yellowOutPlayer -= 1;
            pathPointToMoveOn_ = pathobjectparents.yellowPathPoint;
            
        }
        for (int i = playerPice_.numberOfStepsAlreadyMoved - 1; i >= 0; i--) 
        {
            playerPice_.transform.position = pathPointToMoveOn_[i].transform.position;
            yield return new WaitForSeconds(0.02f);
            
        }

        playerPice_.transform.position = pathobjectparents.BasePoint[BasePointPosition(playerPice_.name)].transform.position;
        FindObjectOfType<AudioManager>().Play("flashBack");

    }
    public int BasePointPosition(string name) {

        for (int i = 0; i < pathobjectparents.BasePoint.Length; i++) {
            if (pathobjectparents.BasePoint[i].name == name) {
                return i ;
            }
            
        }
        return -1;
    
    }

    public void addPlayer(playerPice playerPice_) {

        playerPicesList.Add(playerPice_);
        RescaleAndRepositioningPlayersPice();

    }
    public void RemoveLayerPice(playerPice playerPice_) 
    {
        if (playerPicesList.Contains(playerPice_))
        {
            playerPicesList.Remove(playerPice_);
            RescaleAndRepositioningPlayersPice();

        }

    }

    public void complete(playerPice playerPice_) {

        int totalCompletePlayer;
        if (playerPice_.name.Contains("blue"))
        {
            GameManager.gm.blueOutPlayer -= 1;
            totalCompletePlayer=GameManager.gm.blueCompletePlayer += 1;
        }
        else if (playerPice_.name.Contains("red"))
        {
            GameManager.gm.redOutPlayer -= 1;
            totalCompletePlayer= GameManager.gm.redCompletePlayer += 1;
            
        }
        else if (playerPice_.name.Contains("green"))
        {
            GameManager.gm.greenOutPlayer -= 1;
            totalCompletePlayer=GameManager.gm.greenCompletePlayer += 1;

        }
        else
        {
            GameManager.gm.yellowOutPlayer -= 1;
            totalCompletePlayer=GameManager.gm.yellowCompletePlayer += 1;
        }
        if (totalCompletePlayer == 4) {
            if (GameManager.gm.TotalPlayerCanPlay == 2) {

                GameManager.gm.win = true;
            }
            else if (GameManager.gm.TotalPlayerCanPlay==3) {
                    GameManager.gm.win= true;
                
            }
            GameManager.gm.win = true;
            FindObjectOfType<AudioManager>().Play("Wining");

        }
    }
   /* void checking (playerPice playerPice_)
    {

        if (playerPice_.name == "bluePlayer")
        {
            check.firstPlayerOut = false;
        }
        else if (playerPice_.name == "bluePlayer (1)")
        {
            check.secondPlayerOut = false;
        }
        else if (playerPice_.name == "bluePlayer (2)")
        {
            check.thirdPlayerOut = false;
        }
        else if(playerPice_.name == "bluePlayer (3)")
        {
            check.fourthPlayerOut = false;
        }
        else if (playerPice_.name == "redPlayer")
        {
            check.firstPlayerOut = false;
        }
        else if (playerPice_.name == "redPlayer (1)")
        {
            check.secondPlayerOut = false;
        }
        else if (playerPice_.name == "redPlayer (2)")
        {
            check.thirdPlayerOut = false;
        }
        else if (playerPice_.name == "redPlayer (3)")
        {
            check.fourthPlayerOut = false;
        }
       else if (playerPice_.name == "greenPlayer")
        {
            check.firstPlayerOut = false;
        }
        else if (playerPice_.name == "greenPlayer (1)")
        {
            check.secondPlayerOut = false;
        }
        else if (playerPice_.name == "greenPlayer (2)")
        {
            check.thirdPlayerOut = false;
        }
        else if(playerPice_.name == "greenPlayer (3)")
        {
            check.fourthPlayerOut = false;
        }
        else if (playerPice_.name == "yellowPlayer")
        {
            check.firstPlayerOut = false;
        }
        else if (playerPice_.name == "yellowPlayer (1)")
        {
            check.secondPlayerOut = false;
        }
        else if (playerPice_.name == "yellowPlayer (2)")
        {
            check.thirdPlayerOut = false;
        }
        else if (playerPice_.name == "yellowPlayer (3)")
        {
            check.fourthPlayerOut = false;
        }

        return;
    }*/

    public void RescaleAndRepositioningPlayersPice()
    {

        int plscont = playerPicesList.Count;
        bool isOdd = (plscont/2)==0 ? false : true;

        int extent =plscont/2;
        int counter = 0;
        int spriteLayer = 0;


        switch (plscont) {
        case 1:
                playerPicesList[counter].transform.localScale = new Vector3(0.1740163f, 0.1784782f, 1f);
                playerPicesList[counter].transform.position = new Vector3(transform.position.x , transform.position.y, 0f);//i * pathObjectparent.positionDifrence[plscont-1])
                counter++;
                break;

        case 2:
                playerPicesList[counter].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 1].transform.localScale = new Vector3(0.09f, 0.09f, 1f);//Vector3(pathObjectparent.scales[plscont - 1], pathObjectparent.scales[plscont-1],1f);
                playerPicesList[counter].transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, 0f);//i * pathObjectparent.positionDifrence[plscont-1])
                playerPicesList[counter + 1].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0f);
                counter++;
                break;
        case 3:
                playerPicesList[counter].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 1].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 2].transform.localScale = new Vector3(0.09f, 0.09f, 1f);

                playerPicesList[counter].transform.position = new Vector3(transform.position.x -.1f, transform.position.y+.1f, 0f);
                playerPicesList[counter + 1].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y+.1f, 0f);
                playerPicesList[counter + 2].transform.position = new Vector3(transform.position.x , transform.position.y-.13f, 0f);
                counter++;
                break;

        case 4:
                playerPicesList[counter].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 1].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 2].transform.localScale = new Vector3(0.09f, 0.09f, 1f);
                playerPicesList[counter + 3].transform.localScale = new Vector3(0.09f, 0.09f, 1f);

                playerPicesList[counter].transform.position = new Vector3(transform.position.x - .1f, transform.position.y + .1f, 0f);
                playerPicesList[counter + 1].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + .1f, 0f);
                playerPicesList[counter + 2].transform.position = new Vector3(transform.position.x-.1f, transform.position.y - .13f, 0f);
                playerPicesList[counter + 3].transform.position = new Vector3(transform.position.x+.1f, transform.position.y - .13f, 0f);
                counter++;

                break;


        }

       /* if (isOdd) 
        {
            for (int i = -extent; i <= extent; i++) 
           {
                playerPicesList[counter].transform.localScale = new Vector3(0.09f, 0.09f,1f);
                playerPicesList[counter+1].transform.localScale = new Vector3(0.09f, 0.09f, 1f);//Vector3(pathObjectparent.scales[plscont - 1], pathObjectparent.scales[plscont-1],1f);
                playerPicesList[counter].transform.position = new Vector3(transform.position.x -0.15f,transform.position.y,0f);//i * pathObjectparent.positionDifrence[plscont-1])
                playerPicesList[counter+1].transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y, 0f);

            }


        }
        else
        {

            for(int i = -extent; i < extent; i++) 
            {
                playerPicesList[counter].transform.localScale = new Vector3(pathObjectparent.scales[plscont - 1], pathObjectparent.scales[plscont - 1], 1f);
                playerPicesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjectparent.positionDifrence[plscont - 1]), transform.position.y+ (i * pathObjectparent.positionDifrence[plscont - 1]), 0f);
            }

        }*/
        for (int i = 0; i < playerPicesList.Count; i++) 
        {

            playerPicesList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayer;
            spriteLayer++;            
        }
    
    }
}

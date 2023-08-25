using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject GamePanel;


    public void Game1()
    {
        GameManager.gm.TotalPlayerCanPlay = 2;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.gm.playerHomes[1].SetActive(false);
        GameManager.gm.playerHomes[3].SetActive(false);
    }
    public void Game2()
    {
        GameManager.gm.TotalPlayerCanPlay = 3;

        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.gm.playerHomes[3].SetActive(false);


    }
    public void Game3() 
    {
        GameManager.gm.TotalPlayerCanPlay = 4;

        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
       

    }


}

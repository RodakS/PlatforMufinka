using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text playerHP;
    public Text playerCoins;
    public Player player;

 public void UpdatePlayerCoins()
    {
        playerCoins.text = "Coins: " + player.coins;
    }
    public void UpdatePlayerHD()
    {
        playerHP.text = "HP: " + player.playerhp + "/3";
    }
}

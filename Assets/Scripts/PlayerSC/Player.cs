using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int playerhp = 3;
    public int coins = 0;

   public PlayerMovement playerMovement;

    public void PlayerHpFunction()
    {
        playerhp--;
        playerMovement.ui.UpdatePlayerHD();
        playerMovement.animator.SetBool("IsHit", true);
        if (playerhp <= 0)
        {
            playerMovement.animator.SetBool("IsDead", true);
            playerMovement.canMove = false;
        }
    }
}

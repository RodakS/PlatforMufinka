using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public GameObject PlayerSprite;
    public UI ui;
    public float speed = 20f;
    public bool canMove = true;
    bool isCollided = true;

    Vector3 positonV;

    void Update()
    {
        MovementKeyboard();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCollided = true;
            animator.SetBool("IsJumping", !isCollided);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") )
        {
            isCollided = true;
            animator.SetBool("IsJumping", !isCollided);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (collision.gameObject.transform.position.x >gameObject.transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 10, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 10, 0);
            }

            player.PlayerHpFunction();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            player.coins++;
            ui.UpdatePlayerCoins();
            Destroy(collision.gameObject);
        }
    }

    private void MovementKeyboard()
    {
         positonV = transform.position;
        if (canMove == false ^ animator.GetBool("IsHit")==true)
        {
            if (animator.GetBool("IsAttacking") == false && animator.GetBool("IsDead")== false)
            {
                canMove = true;
            }
        }
        else
        {

            if (Input.GetKey("w") && isCollided == true)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
                isCollided = false;
                animator.SetBool("IsJumping", !isCollided);
            }
            if (Input.GetKey("s"))
            {

            }
            if (Input.GetKey("d"))
            {
                positonV.x += speed * Time.deltaTime;
                PlayerSprite.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey("a"))
            {
                positonV.x -= speed * Time.deltaTime;
                PlayerSprite.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            animator.SetFloat("SpeedX", Mathf.Abs(positonV.x - transform.position.x)*100);
            transform.position = positonV;

            if (Input.GetKey("space") && isCollided == true)
            {
                animator.SetBool("WantsToAttack", true);
                canMove = false;
            }
        }
    }

}
    

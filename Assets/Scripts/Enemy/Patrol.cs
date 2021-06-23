using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public Enemy enemy;
    float speed = 1f;
    public bool goToTwo = false;
    public bool goToOne = true;
    Vector3 vector;
    private void Update()
    {
        Turn();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            goToTwo = !goToTwo;
            goToOne = !goToOne;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("WayPoint1") && goToOne == true)
        {
            goToTwo = true;
            goToOne = false;
        }
        if (collision.gameObject.CompareTag("WayPoint2") && goToTwo == true)
        {
            goToTwo = false;
            goToOne = true;
        }
    }
        public void Turn()
    {
        vector = transform.position;
        if(Waypoint1 == null) { return ; }
        if (goToOne == true)
        {
            if (gameObject.transform.position.x > Waypoint1.transform.position.x)
            {
                transform.position += (Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.position += (Vector3.right * Time.deltaTime * speed);
            }
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (goToTwo == true)
        {
            if (gameObject.transform.position.x > Waypoint2.transform.position.x)
            {
                transform.position += (Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.position += (Vector3.right * Time.deltaTime * speed);
            }
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }


        enemy.enemyAnimator.SetFloat("Speed", Mathf.Abs(vector.x - transform.position.x)*1.1f);

    }
}

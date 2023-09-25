using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameSystems;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField]private float jumpPower = 1f;
    [SerializeField]private float jumpOknac = 1f;
    [SerializeField]private int jumpCount = 1;
    [SerializeField]private float jumpDuration = 0.5f;
    [SerializeField]private Rigidbody2D playerRB;
    [SerializeField]private Vector3 startposition;
    // Start is called before the first frame update
    void Start()
    {
        transform.right = Vector3.right;
        startposition = Vector3.zero;
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.bodyType = RigidbodyType2D.Static;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateSystem.GetState() == GameState.Playing)
        {
            var direction = playerRB.velocity + Vector2.right*jumpOknac;
            transform.right = direction.normalized;
            
            playerRB.bodyType = RigidbodyType2D.Dynamic;
            if (Input.GetMouseButtonDown(0))
            {
                //transform.DOJump(transform.position + Vector3.up*0.5f, jumpPower, jumpCount, jumpDuration);
                var vel = playerRB.velocity;
                vel.y = 0;
                playerRB.velocity = vel;
                playerRB.AddForce( Vector3.up*jumpPower, ForceMode2D.Impulse);
          
            }
        }
        
        
       
    }

     IEnumerator Jump()
    {
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        transform.DOJump(transform.position + Vector3.up*2.5f, jumpPower, jumpCount, jumpDuration);
        yield return new WaitForSeconds(jumpDuration);
        
    }

     private void OnCollisionEnter2D(Collision2D other)
     {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                GameStateSystem.SetState(GameState.GameOver);
            }
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("FinishLine"))
         {
             GameStateSystem.SetState(GameState.GameWon);
         }
     }

     public void Reset()
     {
         transform.right = Vector3.right;
         transform.position =Vector3.zero;
         playerRB.bodyType = RigidbodyType2D.Static;
     }
}

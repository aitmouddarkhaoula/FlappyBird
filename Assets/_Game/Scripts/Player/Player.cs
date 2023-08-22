using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float jumpPower = 1f;
    [SerializeField]private int jumpCount = 1;
    [SerializeField]private float jumpDuration = 0.5f;
    [SerializeField]private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            transform.DOJump(transform.position + Vector3.up, jumpPower, jumpCount, jumpDuration);
        }
        else
        {
        
            
        }
        //playerRB.bodyType = RigidbodyType2D.Kinematic;
       
    }

     IEnumerator Jump()
    {
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        transform.DOJump(transform.position + Vector3.up, jumpPower, jumpCount, jumpDuration);
        yield return new WaitForSeconds(jumpDuration);
        
    }
}

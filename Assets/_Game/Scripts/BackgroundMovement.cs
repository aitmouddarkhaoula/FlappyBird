using System;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateSystem.GetState() == GameState.Playing)
        {
            transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(8.6f,0,0);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 5f;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject currentBackground;
    [SerializeField] List<GameObject> backgrounds;
    float b;
    // Start is called before the first frame update
    void Start()
    {
        currentBackground = background;
        b = -1;
        InstantiateBackground();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateSystem.GetState() == GameState.Playing)
        {
            transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        }

        var xpos = transform.position.x;
        
        if (xpos/100<b)
        {
            //if(b<-1) Destroy(backgrounds[backgrounds.Count-1]);
            b = (xpos/100)-1;
            InstantiateBackground();
            
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(8.6f,0,0);
    }

    public void InstantiateBackground()
    {
        currentBackground = Instantiate(background, currentBackground.transform.position+Vector3.right*113.8f, Quaternion.identity, transform);
        backgrounds.Add(currentBackground);
    }
}

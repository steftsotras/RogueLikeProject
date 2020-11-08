using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Making GameManager a Singleton
    public static GameManager instance = null;

    public BoardManager boardScript;
    
    private int level = 3;

    void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

        //Persist between scenes
        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        InitGame();    
    }

    void InitGame(){
        boardScript.SetupScene(level);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

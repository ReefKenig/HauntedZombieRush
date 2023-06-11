using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] GameObject mainMenu;
    
    bool playerActive = false, gameOver = false, gameStarted = false;

    public bool PlayerActive {
        get {return playerActive;}
    }
    public bool GameOver {
        get {return gameOver;}
    }
    public bool GameStarted {
        get {return gameStarted;}
    }

    void Awake()
    {
    
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollided(){
        gameOver = true;
    }

    public void PlayerStart(){
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }
}

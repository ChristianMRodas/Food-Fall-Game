using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    private GameManager gameManager;

    public int difficulty; //*update on Unity

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //Find (looks inside the hierarchy

        button.onClick.AddListener(SetDifficulty); //*Note: how we pass the function to the listener, which i think calls run it


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");  //*Note: method to get the name of the object
        gameManager.StartGame(difficulty); //starts game when diff button is pressed
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  //YUses for UI
using UnityEngine.SceneManagement; //used to restart scene
using UnityEngine.UI; //lets us interact with the restart button (or any button

public class GameManager : MonoBehaviour
{
    //we can pass the datatype (whereas in arrays u have to say what it is
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;  //For UI //***Dont forget to add it to the GamerManager scriptin Unity

    public TextMeshProUGUI gameOverText; //In Unity, turn off the text (checkbox next to name), n we will
    //  turn back on via code

    public Button restartButton; //Note: add to the GM script in Unity

    public GameObject titleScreen; //Note: add to the GM script in untiy

    public bool isGameActive;

    private int score;

    private float spawnRate = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive) //if its true, run it
        {
            yield return new WaitForSeconds(spawnRate); //spawnRate is spawn interval rate
            int index = Random.Range(0, targets.Count);  //which object to spawn

            Instantiate(targets[index]); //create object

        }
 
    }

    //used to calc score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(true); //turns on the text //need to set ref in Unity (in GM script)

        isGameActive = false;
    }

    //*Note: In Unity, go to button, on click(), add this GM script (drag n drop), function will be RestartGame()
    public void RestartGame() //Uses the unisng Unity.NEgine.scenemanagement ...
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //u can also just pass Prototype 5

        

    }

    public void StartGame(int difficulty)
    {

        isGameActive = true; //should be on top, before the Co-routine
        score = 0; //Need to start it with a number

        spawnRate /= difficulty; //higher diff, faster spawn rate

        StartCoroutine(SpawnTarget());

        UpdateScore(0); //resets score

        titleScreen.gameObject.SetActive(false);
    }
}

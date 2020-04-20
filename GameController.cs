using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool restart;
    private bool win;
    private int score;
    public AudioSource musicSource;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;


    void Start()
    {

        gameOver = false;
        restart = false;
        win = false;
     
        winText.text = "";
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        
    }

    void Update()

    {

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");

            }

            if (Input.GetKey("escape"))
                Application.Quit();
        }


    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

                
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                break;
            }

            else if (win)
            {
            
                restartText.text = "Press 'Z' for Restart ";
                restart = true;
                break;
            }

         

        }
    }
 

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

        if (score >= 250)
        {
            winText.text = "You win!Game created by Mariangely Quiros";
            restart = true;
            gameOver = true;
       
            musicSource.clip = musicClipThree;
            musicSource.Play();
        }
        else if (score == -5)
        {
            gameOverText.text = "GAME OVER.";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            restart = true;
            gameOver = true;
        }
    
    }

public void GameOver()
    {

        gameOverText.text = "GAME OVER.";
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        gameOver = true;
        restart = true;

    }

}



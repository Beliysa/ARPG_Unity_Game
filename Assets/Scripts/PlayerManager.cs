using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //manages the state of the game
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isNextLevel;
    public GameObject NextLevelScreen;
    public static bool isStartGame;
    public GameObject StartGameScreen;

    public static int enemyCount;

    private int levelIndex;
    
    
    private void Awake()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;
        print(enemyCount);
        //this fun is like the start fun and called when we start the game but it is called just before
        isGameOver = false;
        isNextLevel = false;

        levelIndex = PlayerPrefs.GetInt("level");
        
        //isStartGame = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            
        }

        if (enemyCount <= 0)
        {
            NextLevelScreen.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void NextLevel()
    {
        levelIndex++;
        if (levelIndex >= 3)
        {
            
            levelIndex = 0;
        } 
        PlayerPrefs.SetInt("level",levelIndex);
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartGameScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void ExitGame()
    {
       Application.Quit();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    
}

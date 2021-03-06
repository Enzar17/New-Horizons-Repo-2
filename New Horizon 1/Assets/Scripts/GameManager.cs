﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject healthBar;
    GameObject[] trees;
    float percentHealth;

    //lose condition minimum health
    [SerializeField]
    float minHealth = .2f;

    //maximum enemies left that you are allowed to win with
    [SerializeField]
    int maxEmenies = 0;

    [SerializeField]
    int amtOfSwarms = 0;

    //pause menu
    [SerializeField]
    private Canvas pauseMenu;
    [SerializeField]
    private Canvas hudCanvas;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button unPauseButton;
    [SerializeField]
    private Button quitGameButton;


    GameObject flockOpigs;
    //singleton
    public static GameManager GM = null;

    // Use this for initialization
    void Start()
    {
        percentHealth = 0;
        trees = GameObject.FindGameObjectsWithTag("tree");

        // Button handling for pause menu
        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(goBackToMainMenu);
        Button unPauseBtn = unPauseButton.GetComponent<Button>();
        unPauseBtn.onClick.AddListener(unPause);
        Button quitGameBtn = quitGameButton.GetComponent<Button>();
        quitGameBtn.onClick.AddListener(quitGame);

        //Singleton (makes sure that there is only ever one instance of this code)
        if (GM == null)
            GM = this;
        else if (GM != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //keep cursor within game window
        Cursor.lockState = CursorLockMode.Confined;

        spawnLittleOnes(amtOfSwarms);
    }

    // Update is called once per frame
    void Update()
    {
        //update health bar
        percentHealth = 0;
        foreach (GameObject tree in trees)
        {
            percentHealth += tree.GetComponent<TreeScript>().Health;
        }
        percentHealth = percentHealth / trees.GetLength(0);
        healthBar.GetComponent<Image>().fillAmount = percentHealth;

        //loss condition
        if (percentHealth < minHealth)
        {
            lose();
        }

        // Listen for pause key, pauses upon press.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
    public void win()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Pig").GetLength(0) + GameObject.FindGameObjectsWithTag("littlePig").GetLength(0));
        if (GameObject.FindGameObjectsWithTag("Pig").GetLength(0) == 0 && GameObject.FindGameObjectsWithTag("littlePig").GetLength(0) <= maxEmenies + 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinScn");
        }
    }
    public void lose()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("LoseScn");
    }

    public bool isPause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
            return false;
        else
            return true;
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    private void pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            // hudCanvas.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            //   hudCanvas.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Loads the mainBody scene
    /// </summary>
    private void goBackToMainMenu()
    {
        SceneManager.LoadScene("MainBody");
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Unpauses the game, upon push of a button.
    /// </summary>
    private void unPause()
    {
        pauseMenu.gameObject.SetActive(false);
        hudCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    private void quitGame()
    {
        Application.Quit();
    }


    private void spawnLittleOnes(int amtOfSwarms)
    {
        for (int i = 0; i < amtOfSwarms; i++)
        {
            GameObject.FindGameObjectWithTag("Pig").GetComponent<EnemyAi>().SpawnLittleOnes();
        }
    }
}

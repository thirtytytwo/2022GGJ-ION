using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject player;
    public GameObject deathUI;
    public int current = 1;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void PlayerDie()
    {
        Instantiate(deathUI);
        Destroy(player);
        Invoke("Func", 1f);
    }
    public void GoToNextLevel()
    {
        current += 1;
        SceneManager.LoadScene(current);
    }
    private void Func()
    {
        SceneManager.LoadScene(current);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    int score = 0;
    static GameManager m_instance;

    public static GameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }

    void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }
}

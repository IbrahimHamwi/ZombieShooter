using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector] public bool bullet_And_BulletFX_Created, rocket_Bullet_Created;
    [HideInInspector] public bool playerAlive;
    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;

    void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        playerAlive = true;
    }
    private void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}
public enum GameGoal
{
    KILL_ZOMBIES,
    WALK_TO_GOAL_STEPS,
    DEFEND_FENCE,
    TIMER, COUNTDOWN,
    GAME_OVER
}

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector] public bool bullet_And_BulletFX_Created, rocket_Bullet_Created;
    [HideInInspector] public bool playerAlive, fenceDestroyed;
    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;
    public GameGoal gameGoal = GameGoal.DEFEND_FENCE;

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

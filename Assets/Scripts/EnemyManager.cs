using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public static Transform s_player;

    [Range(1, 15)]
    public int enemyLimit;
    public static int s_enemyLimit;
    public static int s_enemyCount;

    private void Start()
    {
        s_player = player;
        s_enemyLimit = enemyLimit;
        s_enemyCount = 0;
    }
}

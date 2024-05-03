using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ì¢î∞êî
    int killScore = 0;
    public int KillScore { get { return killScore; } set { killScore = value; } }

    int killScore_forFever = 0;
    public int KillScore_ForFever { get { return killScore_forFever; } set { killScore_forFever = value; } }

    [SerializeField] int killScore_forFeverMax = 0;
    public int KillScore_ForFeverMax { get { return killScore_forFeverMax; } set { killScore_forFeverMax = value; } }

    void Start()
    {

    }

    void Update()
    {
        
    }
}

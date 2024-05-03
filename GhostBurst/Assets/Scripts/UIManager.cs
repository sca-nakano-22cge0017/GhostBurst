using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text killScore;

    [SerializeField] Player player;
    [SerializeField] Image hpGuage;
    [SerializeField] Image feverGuage;



    void Start()
    {
        hpGuage.fillAmount = player.maxHP;
        feverGuage.fillAmount = 0;
    }

    void Update()
    {
        UIDisp();
    }

    void UIDisp()
    {
        killScore.text = gameManager.KillScore.ToString() + "‘Ì";

        hpGuage.fillAmount = (float)player.HP / player.maxHP;
        feverGuage.fillAmount = (float)gameManager.KillScore_ForFever / gameManager.KillScore_ForFeverMax;
    }
}

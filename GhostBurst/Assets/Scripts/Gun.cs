using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 銃
/// </summary>
public class Gun : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletsPrefab;
    [SerializeField] Transform bulletsSpawnPos;

    [SerializeField] GameObject fireButton;
    [SerializeField] GameObject reroadButton;

    [SerializeField] int maxBulletsAmount;
    int remainingBullets;

    bool needReroad = false;

    [SerializeField] int defaultMagazineAmount;
    int remainingMagazine;

    bool needMagazineGet = false;


    void Start()
    {
        remainingBullets = maxBulletsAmount;
        remainingMagazine = defaultMagazineAmount;

        fireButton.SetActive(true);
        reroadButton.SetActive(false);
    }

    void Update()
    {
        if(remainingMagazine > 0) needMagazineGet = false;
    }

    public void Fire()
    {
        if(needReroad) return; //! リロードを指示する文章表示

        var obj = Instantiate(bulletsPrefab, bulletsSpawnPos.position, Quaternion.identity, bulletsSpawnPos);
        obj.GetComponent<Bullets>().BulletsForward = transform.forward;

        // 残弾数を減らす
        remainingBullets--;

        if(remainingBullets <= 0) needReroad = true;

        ButtonChange();
    }

    public void Reroad()
    {
        if(needMagazineGet) return; // マガジンが無ければリロード不可

        needReroad = false;

        // 弾丸補充　マガジン消費
        remainingBullets = maxBulletsAmount;
        remainingMagazine--;

        if (remainingMagazine <= 0) needMagazineGet = true;

        ButtonChange();
    }

    public void MagazineRefill()
    {
        remainingMagazine++;
    }

    /// <summary>
    /// 発砲/リロードボタン表示切替
    /// </summary>
    void ButtonChange()
    {
        fireButton.SetActive(!needReroad);
        reroadButton.SetActive(needReroad);
    }
}

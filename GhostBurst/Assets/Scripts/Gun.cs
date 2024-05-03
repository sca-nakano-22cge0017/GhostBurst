using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e
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
        if(needReroad) return; //! �����[�h���w�����镶�͕\��

        var obj = Instantiate(bulletsPrefab, bulletsSpawnPos.position, Quaternion.identity, bulletsSpawnPos);
        obj.GetComponent<Bullets>().BulletsForward = transform.forward;

        // �c�e�������炷
        remainingBullets--;

        if(remainingBullets <= 0) needReroad = true;

        ButtonChange();
    }

    public void Reroad()
    {
        if(needMagazineGet) return; // �}�K�W����������΃����[�h�s��

        needReroad = false;

        // �e�ە�[�@�}�K�W������
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
    /// ���C/�����[�h�{�^���\���ؑ�
    /// </summary>
    void ButtonChange()
    {
        fireButton.SetActive(!needReroad);
        reroadButton.SetActive(needReroad);
    }
}

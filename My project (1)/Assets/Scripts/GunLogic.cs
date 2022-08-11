using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunLogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_bulletPrefab;

    [SerializeField]
    Transform m_bulletSpawnPoint;

    const float Max_cooldown = 0.5f;
    float m_curentCooldown = 0.5f;

    const int Max_Ammo = 20;
    int m_ammotCount = Max_Ammo;

    [SerializeField]
    Text m_amountText;


    // Start is called before the first frame update
    void Start()
    {
        SetAmmoText();
    }

    void SetAmmoText()
    {
        if (m_amountText)
        {
            m_amountText.text = "Ammo: " + m_ammotCount;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (m_curentCooldown > 0.0f)
        {
            m_curentCooldown -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && m_curentCooldown < 0.0f)
        {
            if (m_bulletPrefab && m_bulletSpawnPoint && m_ammotCount > 0)
            {
                Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation * m_bulletPrefab.transform.rotation);
                m_curentCooldown = Max_cooldown;
                --m_ammotCount;

                SetAmmoText();
            }
        }
    }

    public void RefillAmmo() {
        m_ammotCount = Max_Ammo;
        SetAmmoText();
    }
}

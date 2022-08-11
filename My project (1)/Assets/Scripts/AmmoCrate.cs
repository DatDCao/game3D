using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GunLogic gunLogic = other.GetComponentInChildren<GunLogic>();
            if (gunLogic)
            {
                gunLogic.RefillAmmo();
                Destroy(gameObject);
            }
        }
    }
}

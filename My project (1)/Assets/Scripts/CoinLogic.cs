using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    AudioSource m_AudioSource;

    Collider m_Colider;
    MeshRenderer m_Meshreanderer;

    [SerializeField]
    AudioClip m_CoinSound;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_Colider = GetComponent<Collider>();
        m_Meshreanderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, .5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (m_AudioSource && m_CoinSound)
            {
                m_AudioSource.PlayOneShot(m_CoinSound);
            }

            if (m_Colider)
            {
                m_Colider.enabled = false;
            }
            if (m_Meshreanderer)
            {
                m_Meshreanderer.enabled = false;
            }
        }


    }
}

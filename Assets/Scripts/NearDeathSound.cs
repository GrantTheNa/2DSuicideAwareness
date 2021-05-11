using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDeathSound : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        SoundManager.PlaySound("NearDeath");
    }

    void OnTriggerExit(Collider other)
    {
        SoundManager.PlaySound("Splat");
        SoundManager.PlaySound("CityLow");
    }

}

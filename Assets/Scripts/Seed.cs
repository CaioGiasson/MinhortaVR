using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject planta;

    // Trigger to know when clicked
    private void OnMouseDown()
    {
        Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (p.seeds == null) { 
            p.seeds = gameObject;
            gameObject.SetActive(false);
        }
    }
}
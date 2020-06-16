using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public bool empty = true;

    private void OnMouseDown()
    {
        if (empty)
        {
            Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            GameObject go = Instantiate(p.seeds.GetComponent<Seed>().planta, transform.position, Quaternion.identity);
            go.GetComponent<ControlLevel>().terreno = this;

            p.seeds = null;
            empty = false;
        }
    }
}
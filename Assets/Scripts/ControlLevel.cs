using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLevel : MonoBehaviour
{
    public List<GameObject> Levels;
    public List<int> intervalo;
    public Terrain terreno;

    [Range(1, 4)]
    public int actual = 1;

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(controleCrecimento());
    }

    // Update is called once per frame
    void Update()
    {
        for(int n = 1; n <= Levels.Count; n++)
        {
            // Condicional ? true : false;
            Levels[n-1].gameObject.SetActive(n == actual ? true : false);

            /*
            if (n == actual)
            {
                Levels[n].gameObject.SetActive(true);
            }
            else
            {
                Levels[n].gameObject.SetActive(false);
            }
            */
        }  
    }

    IEnumerator controleCrecimento()
    {
        yield return new WaitForSeconds(intervalo[actual - 1]);

        if (actual <= intervalo.Count) {
            actual++;
            StartCoroutine(controleCrecimento());
        }
    }

    private void OnMouseDown()
    {
        switch (actual)
        {
            case 1:
                p.pontos += 1;
                break;
            case 2:
                p.pontos += 2;
                break;
            case 3:
                p.pontos += 3;
                break;
            case 4:
                p.pontos -= 1;
                break;
        }

        terreno.empty = true;
        Destroy(gameObject);
    }

}
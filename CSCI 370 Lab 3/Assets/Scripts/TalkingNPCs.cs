//Based on a script I created for my senior seminar project.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPCs: MonoBehaviour
{
    public GameObject Final1;
    public GameObject Final2;
    public GameObject Final3;

    void Start()
    {
        Final1.SetActive(false);
        Final2.SetActive(false);
        Final3.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Final1.SetActive(true);
            StartCoroutine(WaitForSec());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            Final1.SetActive(false);
            Final2.SetActive(false);
            Final3.SetActive(false);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        Final1.SetActive(false);
        Final2.SetActive(true);
        yield return new WaitForSeconds(3);
        Final2.SetActive(false);
        Final3.SetActive(true);
        yield return new WaitForSeconds(3);
        Final3.SetActive(false);
    }
}
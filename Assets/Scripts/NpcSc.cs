using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcSc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public TMP_Text Paneltext;
    public GameObject contbutton;
    public string[] panelstring;
    private int index;
    public float wordspeed;
    public bool playerIsclose;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerIsclose)
        {
            if (panel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                panel.SetActive(true);
                StartCoroutine(Typing());
            }

        }
        if(Paneltext.text == panelstring[index])
        {
            contbutton.SetActive(true);
        }
    }
    public void ZeroText()
    {
        Paneltext.text = "";
        index = 0;
        panel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in panelstring[index].ToCharArray())
        {
            Paneltext.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }
    public void NextLine()
    {
        contbutton.SetActive(false);
        if (index < panelstring.Length - 1)
        {
            index++;
            Paneltext.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag  ("Player"))
        {
            playerIsclose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsclose = false;
            ZeroText();
        }
    }
}

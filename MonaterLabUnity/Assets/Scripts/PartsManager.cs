using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PartsManager : MonoBehaviour
{

    public Part currentPart;
    [SerializeField]private int current = 0;
    public Sprite[] allParts;
    public Sprite[] playerParts;
    public SpriteRenderer playerPart;
    public Image partInUI;
    public Image partOnMenu;
    public Button left, rigth;
    private bool oppened = false;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        partOnMenu.sprite = allParts[0];
        left.interactable = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (oppened)
            partInUI.sprite = partOnMenu.sprite;

        if(current == 0)
            left.interactable = false;
        else
            left.interactable = true;

        if (current >= allParts.Length-1)
            rigth.interactable = false;
        else
            rigth.interactable = true;
    }
    public void nextPart()
    {
        current++;
        partOnMenu.sprite = allParts[current];
    }
    public void lastPart()
    {
        current--;
        partOnMenu.sprite = allParts[current];
    }

    public void Open()
    {
        oppened = true;
    }

    public void SelectPart()
    {
        playerPart.sprite = playerParts[current];
    }
}

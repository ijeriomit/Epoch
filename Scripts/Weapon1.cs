using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon1 : MonoBehaviour {

    public Button sword_b, wand_b, start_b;
    private int Start_coin;

    //public PlayerInfo player;

    // Use this for initialization
    void Start()
    {
        start_b.interactable = false;
        Start_coin = 3;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sword_update()
    {
        if (Start_coin > 2)
        {
            start_b.interactable = true;
            sword_b.interactable = false;
            Start_coin -= 3;
            PlayerPrefs.SetString("hasSword", "true");
            print("SHITS HAFUBWD");
            PlayerPrefs.SetInt("coins", Start_coin);
        }
        else return;
    }
    public void wand_update()
    {
        if (Start_coin > 2)
        {
            start_b.interactable = true;
            wand_b.interactable = false;
            Start_coin -= 3;
            PlayerPrefs.SetString("hasWand", "true");
            PlayerPrefs.SetInt("coins", Start_coin);
        }
        else return;
    }
}

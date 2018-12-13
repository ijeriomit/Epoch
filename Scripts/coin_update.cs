using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_update : MonoBehaviour {
    public Button Freeze_b, MinorHeal_b, sword_b, wand_b;
    public int curr_num,Freeze,MinorHeal;
    public Text Display;
	//public PlayerInfo player;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetString("hasWand") == "true"){
            wand_b.interactable = false;
        }
        if (PlayerPrefs.GetString("hasSword") == "true")
        {
            sword_b.interactable = false;
        }
        curr_num = PlayerPrefs.GetInt("coins");


    }
	
	// Update is called once per frame
	void Update () {
        Display.text = curr_num.ToString();

	}



    public void Freeze_update()
    {
        if (curr_num > 4)
        {
            curr_num = curr_num - 5;
			Freeze_b.interactable = false;
			PlayerPrefs.SetString ("hasFreeze", "true");
			PlayerPrefs.SetInt ("coins", curr_num);
        }
        else return;
        
    }


    public void minor_update()
    {
        if (curr_num > 4)
        {
            curr_num = curr_num - 5;
			MinorHeal_b.interactable = false;
			PlayerPrefs.SetString ("hasHeal", "true");
			PlayerPrefs.SetInt ("coins", curr_num);
        }
        else return;
    }



	public void Sword_update()
	{
		if (curr_num > 2)
		{
            curr_num -= 3;
			sword_b.interactable = false;
			PlayerPrefs.SetString ("hasSword", "true");
			PlayerPrefs.SetInt ("coins", curr_num);
		}
		else return;
	}
	public void wand_update()
	{
		if (curr_num > 2)
		{
            curr_num -= 3;
			wand_b.interactable = false;
			PlayerPrefs.SetString ("hasWand", "true");
			PlayerPrefs.SetInt ("coins", curr_num);
		}
		else return;
	}
}

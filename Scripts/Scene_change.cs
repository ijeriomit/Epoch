using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_change : MonoBehaviour
{

    public void Menu_Open()
    {

        Application.LoadLevel("start");
    }
    public void Shop_Open()
    {
        Application.LoadLevel("shop");
    }
    public void skill_Open()
    {
        Application.LoadLevel("Skill_Set");

    }
    public void tutorialSelect()
    {
		PlayerPrefs.SetString ("hasFreeze", "false");
		PlayerPrefs.SetString ("hasShield", "false");
		PlayerPrefs.SetString ("hasHeal", "false");
		PlayerPrefs.SetString ("hasLightning", "false");
		PlayerPrefs.SetString ("hasTeleport", "false");


		PlayerPrefs.SetInt ("str", 1);
		PlayerPrefs.SetInt ("spell", 1);
		PlayerPrefs.SetInt ("dex", 1);
		PlayerPrefs.SetInt ("fort", 1);
		//PlayerPrefs.SetInt ("hp", 10);
		//PlayerPrefs.SetInt ("mana", 2);
        Application.LoadLevel("tutorial_scene");
    }
    public void Type_Open()
    {
        Application.LoadLevel("Player_Type");
    }
    public void Credit_Open()
    {
        Application.LoadLevel("Credits");
    }
    public void Level1_Open()
    {

        Application.LoadLevel("Level_1");
    }
	public void Weapon_Open()
	{
        PlayerPrefs.SetString("hasSword", "false");
        PlayerPrefs.SetString("hasWand", "false");
        PlayerPrefs.SetInt("coins", 0);
        Application.LoadLevel ("Weapon");
	}

}
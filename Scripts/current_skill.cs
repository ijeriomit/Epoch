using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class current_skill : MonoBehaviour {
    public Button spell_p, str_p, dex_p, fort_p;
    public int skill_Num;
    public int str, dex, spell, fort;
    public Text Dis_val;
    public Text strT, dexT, spellT, fortT;
    // Use this for initialization
    void Start () {
        skill_Num = 2;
		str = PlayerPrefs.GetInt("str");
		dex = PlayerPrefs.GetInt("dex");
		spell = PlayerPrefs.GetInt("spell");
		fort = PlayerPrefs.GetInt("fort");;
	}
	
	// Update is called once per frame
	void Update () {
        Dis_val.text = skill_Num.ToString();
        strT.text = str.ToString();
        dexT.text = dex.ToString();
        fortT.text = fort.ToString();
        spellT.text = spell.ToString();

        //str_p.OnPointerClick(str + 1);

    }

    public void Strplus()
    {
        if (skill_Num > 0)
        {
            str++;
            skill_Num--;
			PlayerPrefs.SetInt ("str", str);
        }
        else return;
    }
    public void Strmin()
    {
        if (str > 1)
        {
            str--;
            skill_Num++;
            PlayerPrefs.SetInt("str", str);
        }
        else return;
    }
    public void Spellplus()
    {
        if (skill_Num > 0)
        {
            spell++;
            skill_Num--;
			PlayerPrefs.SetInt ("spell", spell);
        }
        else return;
    }
    public void Spellminus()
    {
        if (spell > 1)
        {
            spell--;
            skill_Num++;
            PlayerPrefs.SetInt("spell", spell);
        }
        else return;
    }
    public void Fortplus()
    {
        if (skill_Num > 0)
        {
            fort++;
            skill_Num--;
			PlayerPrefs.SetInt ("fort", fort);
        }
        else return;
    }
    public void Fortminus()
    {
        if (fort > 1)
        {
            fort--;
            skill_Num++;
            PlayerPrefs.SetInt("fort", fort);
        }
        else return;
    }
    public void Dexplus()
    {
        if (skill_Num > 0)
        {
            dex++;
            skill_Num--;
			PlayerPrefs.SetInt ("dex", dex);
        }
        else return;
    }
    public void Dexminus()
    {
        if ( dex> 1)
        {
            dex--;
            skill_Num++;
            PlayerPrefs.SetInt("dex", dex);
        }
        else return;
    }

}

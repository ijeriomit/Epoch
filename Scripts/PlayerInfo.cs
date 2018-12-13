using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PlayerInfo : MonoBehaviour {

	public SpriteRenderer sword;
	public SpriteRenderer wand;
	public Movement player;
	public bool hasSword = false;
	public bool hasWand = false;

	public TextAsset text;
	string content;
	string readPath;
	public List<string> loadData = new List<string> ();
	public int str, dex, spell, fort;
	public int maxHP;
	//public int curHP;
	public int maxMana;
	//public int curMana;
	public CoinDrop coins;
	public Text coinText, hptext, manatext;

	static public int wallet;
	private Collision col2D;
	private int attackPower = 1;

	void OnTriggerEnter(Collider colInfo){
		if (colInfo.gameObject.name.Equals ("Coin(Clone)")) {
			print ("ching!");
			wallet++;
			PlayerPrefs.SetInt ("coins", wallet);
			player.SFX.PlayOneShot (player.CoinSFX);
			//print (wallet);
		}
	}
	// Use this for initialization
	void Start () {
		//text = (TextAsset)Resources.Load("saveData",typeof(TextAsset));
		//content = text.text;
		//print (content);
		//DontDestroyOnLoad(gameObject);
		player = GetComponent<Movement>();
		if(PlayerPrefs.GetString("hasWand") == "true"){
            print("HAS WAND");
			hasWand = true;
		}
		if (PlayerPrefs.GetString ("hasSword") == "true") {
            print("HAS SWORD");
			hasSword = true;
		}
		str = PlayerPrefs.GetInt ("str");
		dex = PlayerPrefs.GetInt ("dex");
		fort = PlayerPrefs.GetInt ("fort");
		spell = PlayerPrefs.GetInt ("spell");
		maxHP = 10 + 2 * fort;
		maxMana = 2 + spell;
		readPath = Application.dataPath + "/Resources/SaveData/saveData.txt";

		readFile (readPath);
		wallet = PlayerPrefs.GetInt ("coins");

		/*setMaxHP ();
		setMaxMana();*/
		//col2D = GetComponent<Collision>();
	}
	public int GetAttackPower()
	{
		return attackPower;
	}
	public void MultiplyAttackPower(int multipier)// used to multiply attack values subject to change if we arent using multipliers
	{
		attackPower = multipier * attackPower;
	}

	// Update is called once per frame
	void Update () {
		coinText.text = "Coins: " + wallet.ToString ();

		setWeapon ();

	}

	public void setWeapon(){
        if (hasSword)
        {
            sword.enabled = true;
        }
        else if (!hasSword){
            sword.enabled = false;
        }
        if (hasWand) {
			wand.enabled = true;
		} else if (!hasWand) {
			wand.enabled = false;
		}
	}

	public void readFile(string filePath){
		StreamReader inStream = new StreamReader (filePath);
		while (!inStream.EndOfStream) {
			string line = inStream.ReadLine ();
			loadData.Add (line);
		}
		inStream.Close ();
	}

	public void writeFile(List<string> loadData)
    {
		File.WriteAllLines(Application.dataPath + "/SaveData/Save1.txt", loadData.ToArray());

	}

	public int getMaxHP()
    {
		return maxHP;
	}

	public int getMaxMana()
    {
		return maxMana;
	}

	public void setMaxHP()
    {
		//maxHP = 10;
		//PlayerPrefs.SetInt ("hp", 10);
		//maxHP = int.Parse(loadData [0]);
	}

	public void setMaxMana()
    {
		//PlayerPrefs.SetInt ("mana", 2);
		//maxMana = 2;
		//maxMana = int.Parse(loadData [2]);
	}


}

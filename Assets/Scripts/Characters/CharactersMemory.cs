using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharactersMemory : MonoBehaviour
{
    private string[] listNom;
    private string[] listPrenom;

    public string randomNom {
        get{return listNom[Random.Range(0,listNom.Length)];}
    }
    public string randomPrenom {
        get{return listNom[Random.Range(0,listNom.Length)];}
    }
    public int randomAge {get{return Random.Range(35,80);}}


    public static CharactersMemory instance;
    private List<Character> characters;

    private Character _player;
    
    [SerializeField] private int _maxHeadImages;
    [SerializeField] private int _maxHairImages;
    [SerializeField] private int _maxBodyImages;
    
    void Awake()
    {
        listNom = File.ReadAllLines("Assets/Resources/locales/characters/nom_fr.txt");
        listPrenom = File.ReadAllLines("Assets/Resources/locales/characters/prenom_fr.txt");
        characters = new List<Character>();
        instance = this;

        _player = new Character("PLAYER","PLAYER",50,50);
    }


    public void ChangeLanguage(string newL){
        listNom = File.ReadAllLines("Assets/Resources/locales/characters/nom_"+newL+".txt");
        listPrenom = File.ReadAllLines("Assets/Resources/locales/characters/prenom_"+newL+".txt");
    }

    public Character AddNewRandomCharacter(){
        Character ch = new Character(randomNom,randomPrenom,50,randomAge);
        characters.Add(ch);
        return ch;
    }

    public void AddPlayerPop(int val){
        player.popularite = Mathf.Clamp(player.popularite+=val,0,100);
        if(player.popularite == 0){
            //END GAME
        }

    }

    public Character player {get{return _player;}}
    public int maxBodyImages {get{return _maxBodyImages;}}
    public int maxHeadImages {get{return _maxHeadImages;}}
    public int maxHairImages {get{return _maxHairImages;}}

}

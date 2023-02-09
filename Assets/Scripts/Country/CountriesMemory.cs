using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountriesMemory : MonoBehaviour
{
    public static CountriesMemory instance;

    [SerializeField] private List<Country> _countries;

    private Country _player;

    private bool _chooseCountry;

    private int _playerId; 

    void Awake(){
        playerId = 0;
        _chooseCountry = true;
        instance = this;
        for(int i = 0;i<countries.Count;i++){
            foreach(Province prov in countries[i].ownedTerrotory){
                prov.ownerId = i;
            }
        }
    }

    public void SelectCountry(){
        _chooseCountry = false;
        _player = countries[_playerId];
        PlayerUI.instance.UpdateParties();
    }


    public List<Country> countries {
        get{return _countries;}
    }



    public Country player {
        get{return _player;}
        set{_player = value;}
    }

    public bool chooseCountry {
        get{return _chooseCountry;}
    }

    public int playerId {
        get{return _playerId;}
        set{_playerId = value;}
    }

}

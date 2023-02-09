using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryColors : MonoBehaviour
{
    public static CountryColors instance;

    public enum MAPMODE {
        NORMAL,
        PLAYERONLY
    }

    private MAPMODE mapMode;

    void Start(){
        instance = this;
        mapMode = MAPMODE.NORMAL;
        UpdateMap();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            mapMode = MAPMODE.NORMAL;
            UpdateMap();
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            mapMode = MAPMODE.PLAYERONLY;
            UpdateMap();
        }
    }


    public void UpdateMap(){
        foreach(Country country in CountriesMemory.instance.countries){
            foreach(Province province in country.ownedTerrotory){
                switch(mapMode){
                    case MAPMODE.NORMAL:
                        province.SetColor(country.color);
                        break;
                    case MAPMODE.PLAYERONLY:
                        province.SetColor((CountriesMemory.instance.player==country) ? country.color : Color.black);
                        break;
                }
            }
        }
    }
}

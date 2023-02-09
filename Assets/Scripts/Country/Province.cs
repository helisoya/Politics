using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Province : MonoBehaviour
{
    private int _ownerId;

    private SpriteRenderer render;

    public int ownerId {
        get{return _ownerId;}
        set{_ownerId=value;}
    }


    void Awake(){
        render = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color col){
        render.color = col;
    }


    void OnMouseDown(){
        PlayerUI.instance.UpdateCountry(CountriesMemory.instance.countries[_ownerId]);
        if(CountriesMemory.instance.chooseCountry){
            CountriesMemory.instance.playerId = ownerId;
            return;
        }
    }
}

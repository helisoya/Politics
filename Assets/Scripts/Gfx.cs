using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gfx
{
    public static Sprite GetSpriteParty(int alignement,int index){
        return Resources.Load<Sprite>("gfx/party/"+alignement.ToString()+"_"+(index+1).ToString());
    }

    public static Sprite GetSpriteFlag(string id){
        return Resources.Load<Sprite>("gfx/flag/"+id);
    }


    public static Sprite GetSpriteBody(int index){
        return Resources.Load<Sprite>("gfx/characters/body/body_"+index.ToString());
    }

    public static Sprite GetSpriteHead(int index){
        return Resources.Load<Sprite>("gfx/characters/head/head_"+index.ToString());
    }

    public static Sprite GetSpriteHair(int index){
        return Resources.Load<Sprite>("gfx/characters/hair/hair_"+index.ToString());
    }
}

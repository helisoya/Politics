using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyCreationUI : MonoBehaviour
{
    [SerializeField] private Image flag;
    [SerializeField] private InputField partyName;
    [SerializeField] private Dropdown alignement;

    private int currFlag = 0;

    public void ChangeFlag(int val){
        currFlag = (currFlag + val + PartiesMemory.instance.maxFlagPerIdeology) % PartiesMemory.instance.maxFlagPerIdeology;
        flag.sprite = Gfx.GetSpriteParty(alignement.value,currFlag+1);
    }   

    public void ChangeAlignement(){
        ChangeFlag(0);
    }

    public void ValidChoice(){
        PartiesMemory.instance.player.alignement = alignement.value;
        PartiesMemory.instance.player.indexFlag = currFlag;
        PartiesMemory.instance.player.partyName = partyName.text;
        PartiesMemory.instance.InitialiseParties();
        Destroy(gameObject);
    }
}

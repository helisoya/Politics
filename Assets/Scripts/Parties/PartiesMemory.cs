using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartiesMemory : MonoBehaviour
{

    public static PartiesMemory instance;
    private List<Party> _parties;

    private Party _player;
    
    [SerializeField] private int _maxFlagPerIdeology;

    
    void Awake()
    {
        instance = this;
        _player = new Party("",1,0);
        _parties = new List<Party>();
    }

    public Party player {get{return _player;}}
    public int maxFlagPerIdeology {get{return _maxFlagPerIdeology;}}

    public List<Party> parties{
        get{return _parties;}
    }

    public void InitialiseParties(){
        for(int i = 0;i<=4;i++){
            if(i != player.alignement){
                Party p = new Party("Party",Random.Range(0,maxFlagPerIdeology),i);
                p.partyLeader=CharactersMemory.instance.AddNewRandomCharacter();
                for(int j =0;j<20;j++){
                    Character ch = CharactersMemory.instance.AddNewRandomCharacter();
                    ch.party = p;
                    p.partyMembers.Add(ch);
                }
                _parties.Add(p);
            }else{
                for(int j =0;j<20;j++){
                    Character ch = CharactersMemory.instance.AddNewRandomCharacter();
                    ch.party = player;
                    player.partyMembers.Add(ch);
                }
            }


        }
    }
}

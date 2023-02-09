using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party
{
    private string _partyName;

    private Character _partyLeader;

    private List<Character> _partyMembers;

    private int _alignement;

    private int _indexFlag;

    public Party(string name,int flag,int alignementParty){
        partyName = name;
        partyLeader = null;
        indexFlag = flag;
        alignement = alignementParty;
        partyMembers = new List<Character>();
    }

    public string partyName {
        get{return _partyName;}
        set{_partyName = value;}
    }
    public Character partyLeader {
        get{return _partyLeader;}
        set{_partyLeader = value;}
    }

    public List<Character> partyMembers {
        get{return _partyMembers;}
        set{_partyMembers = value;}
    }

    public int indexFlag {
        get{return _indexFlag;}
        set{_indexFlag = value;}
    }

    public int alignement {
        get{return _alignement;}
        set{_alignement = value;}
    }

}

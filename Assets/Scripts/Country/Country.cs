using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Country
{
    [SerializeField] private string _countryName;
    [SerializeField] private string _id;
    [SerializeField] private Color _color;
    [SerializeField] private List<Province> _ownedTerrotory;


    [SerializeField] private int _maxBudget = 50;
    [SerializeField] private int[] _budgets = new int[6];

    public enum ReligionLaw {
        FREEDOM,
        LAW,
        FORBID
    }

    private ReligionLaw _religionLaw = 0;

        public enum PartyLaw {
        MULTIPARTY,
        ONEPARTY,
        FORBID
    }

    private PartyLaw _partyLaw = 0;


    public enum ElectionLaw {
        FREEELECTION,
        CONTROLLEDELECTION,
        NOELECTION
    }

    private ElectionLaw _electionLaw = 0;


    public enum IndustryLaw {
        MAJORHELP,
        LITTLEHELP,
        NOHELP
    }

    private IndustryLaw _industryLaw = 0;


    public enum SocialLaw {
        MAJORHELP,
        LITTLEHELP,
        NOHELP
    }

    private SocialLaw _socialLaw = 0;

    public enum ArmyLaw {
        NOMILITARY,
        DEFENCE,
        OFFENCE
    }

    private ArmyLaw _armyLaw = 0;

    public string countryName {
        get{return _countryName;}
        set{countryName = value;}
    }

    public string id {
        get{return _id;}
        set{_id = value;}
    }

    public Color color {
        get{return _color;}
        set{_color = value;}
    }

    public List<Province> ownedTerrotory {
        get{return _ownedTerrotory;}
        set{_ownedTerrotory = value;}
    }

    public int maxBudget{
        get{return _maxBudget;}
        set{_maxBudget=value;}
    }

    public int[] budgets{
        get{return _budgets;}
        set{_budgets=value;}
    }

    public ReligionLaw religionLaw{
        get{return _religionLaw;}
        set{_religionLaw=value;}
    }

    public PartyLaw partyLaw{
        get{return _partyLaw;}
        set{_partyLaw=value;}
    }

    public ElectionLaw electionLaw{
        get{return _electionLaw;}
        set{_electionLaw=value;}
    }

    public IndustryLaw industryLaw{
        get{return _industryLaw;}
        set{_industryLaw=value;}
    }

    public SocialLaw socialLaw{
        get{return _socialLaw;}
        set{_socialLaw=value;}
    }

    public ArmyLaw armyLaw{
        get{return _armyLaw;}
        set{_armyLaw=value;}
    }


    public int getAvailableBudget(int ignore){
        int res = maxBudget;
        for(int i =0;i<budgets.Length;i++){
            if(i!=ignore){
                res-=budgets[i];
            }
        }

        return res;
    }
}

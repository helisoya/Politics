using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private string _nom;
    private string _prenom;
    private int _popularite;
    private int _age;
    private int _bodyIndex;
    private Color _bodyColor;
    private int _headIndex;
    private Color _headColor;
    private int _hairIndex;
    private Color _hairColor;
    private Party _party;

    public Character(string nomC,string prenomC,int populariteC,int ageC){
        _nom = nomC;
        _prenom = prenomC;
        _popularite = populariteC;
        _age = ageC;

        _party = null;

        _bodyColor = new Color();
        _headColor = new Color();
        _hairColor = new Color();
        _bodyIndex = 0;
        _headIndex = 0;
        _hairIndex = 0;
    }

    public void GetOlder(int nb){
        age+=nb;
    }

    public string nom {
        get{return _nom;}
        set{_nom = value;}
    }

    public string prenom {
        get{return _prenom;}
        set{_prenom = value;}
    }

    public int popularite {
        get{return _popularite;}
        set{_popularite = value;}
    }

    public int age {
        get{return _age;}
        set{_age = value;}
    }

    public int headIndex {
        get{return _headIndex;}
        set{_headIndex = value;}
    }

    public int bodyIndex {
        get{return _bodyIndex;}
        set{_bodyIndex = value;}
    }

    public int hairIndex {
        get{return _hairIndex;}
        set{_hairIndex = value;}
    }

    public Color headColor {
        get{return _headColor;}
        set{_headColor = value;}
    }

    public Color bodyColor {
        get{return _bodyColor;}
        set{_bodyColor = value;}
    }

    public Color hairColor {
        get{return _hairColor;}
        set{_hairColor = value;}
    }

    public Party party {
        get{return _party;}
        set{_party = value;}
    }
}

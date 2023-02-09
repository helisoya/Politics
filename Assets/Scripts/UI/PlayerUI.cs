using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    [SerializeField] private Image body;
    [SerializeField] private Image head;
    [SerializeField] private Image hair;

    [SerializeField] private Text nom;
    [SerializeField] private Text popularite;
    [SerializeField] private Image populariteFill;

    [SerializeField] private Image countryFlagChoose;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private Image countryFlag;
    [SerializeField] private Text countryName;

    [SerializeField] private Tab[] tabs;

    [SerializeField] private Image piechart_prefab;
    [SerializeField] private Transform piechartRoot;
    [SerializeField] private GameObject budgetTab;

    [SerializeField] private GameObject graphlabelPrefab;
    [SerializeField] private Transform labelsRoot;

    [SerializeField] private ToggleGroup groupReligion;
    [SerializeField] private ToggleGroup groupLaw;
    [SerializeField] private ToggleGroup groupElection;

    [SerializeField] private ToggleGroup groupIndustry;

    [SerializeField] private ToggleGroup groupArmy;

    [SerializeField] private ToggleGroup groupSocial;

    [SerializeField] private GameObject partyLabelPrefab;
    [SerializeField] private Transform partiesRoot;

    void Awake(){
        instance = this;
    }

    public void UpdatePlayerImage(){
        head.color = CharactersMemory.instance.player.headColor;
        hair.color = CharactersMemory.instance.player.hairColor;
        body.color = CharactersMemory.instance.player.bodyColor;

        head.sprite = Gfx.GetSpriteHead(CharactersMemory.instance.player.headIndex);
        hair.sprite = Gfx.GetSpriteHair(CharactersMemory.instance.player.hairIndex);
        body.sprite = Gfx.GetSpriteBody(CharactersMemory.instance.player.bodyIndex);

        nom.text = CharactersMemory.instance.player.prenom+" "+CharactersMemory.instance.player.nom;
        popularite.text = CharactersMemory.instance.player.popularite.ToString()+"%";
        populariteFill.color = Color.Lerp(Color.red,Color.green,CharactersMemory.instance.player.popularite*0.01f);
    }



    public void UpdateCountry(Country c){
        if(!CountriesMemory.instance.chooseCountry){
            countryFlag.sprite = Gfx.GetSpriteFlag(c.id);
            countryName.text = c.countryName;
        }else{
            countryFlagChoose.sprite = Gfx.GetSpriteFlag(c.id);
        }

    }


    public void SelectCountry(GameObject obj){
        CountriesMemory.instance.SelectCountry();
        UpdateCountry(CountriesMemory.instance.player);
        Destroy(obj);
        mainUI.SetActive(true);
    }


    public void OpenTab(int index){
        mainUI.SetActive(false);
        tabs[index].tab.SetActive(true);
        UpdateTab(index, CountriesMemory.instance.player.budgets[index]);
    }

    public void UpdateTab(int index,int val){
        Country c = CountriesMemory.instance.player;
        tabs[index].sliderText.text=val.ToString()+"M";
        tabs[index].slider.minValue=0;
        tabs[index].slider.maxValue=c.getAvailableBudget(index);
        tabs[index].slider.SetValueWithoutNotify(val);
        CountriesMemory.instance.player.budgets[index] =(int)(tabs[index].slider.value);
    }


    public void UpdateSlider(int index){
        int val = (int)(tabs[index].slider.value);

        CountriesMemory.instance.player.budgets[index] = val;

        UpdateTab(index,val);
    }

    public void ShowMainUI(){
        UpdatePlayerImage();
        foreach(Tab t in tabs){
            t.tab.SetActive(false);
        }
        budgetTab.SetActive(false);
        mainUI.SetActive(true);
    }


    public void LoadBudgetView(){
        mainUI.SetActive(false);
        budgetTab.SetActive(true);
        MakeGraph();
        
    }


    void ResetGraph(){
        foreach(Transform child in piechartRoot){
            GameObject.Destroy(child.gameObject);
        }
        foreach(Transform child in labelsRoot){
            GameObject.Destroy(child.gameObject);
        }
    }

    void MakeGraph(){
        ResetGraph();
        int total = CountriesMemory.instance.player.maxBudget;
        float zrotation = 0f;
        Image newWedge = Instantiate(piechart_prefab) as Image;
        newWedge.transform.SetParent(piechartRoot,false);
        newWedge.fillAmount = 1;
        newWedge.color = Color.black;
        for(int i=0;i<tabs.Length;i++){
            if(CountriesMemory.instance.player.budgets[i] == 0.0){
                continue;
            }
            newWedge = Instantiate(piechart_prefab) as Image;
            newWedge.transform.SetParent(piechartRoot,false);
            newWedge.color = tabs[i].color;
            newWedge.fillAmount = (float)(CountriesMemory.instance.player.budgets[i]) / (float)total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,zrotation));
            zrotation -= newWedge.fillAmount * 360f;


            GameObject label = Instantiate(graphlabelPrefab);
            label.GetComponent<Image>().color = tabs[i].color;
            label.GetComponentInChildren<Text>().text = tabs[i].tabName;
            label.transform.SetParent(labelsRoot);
        }
    }



    public void UpdatePlayerBudget(int val){
        if(CountriesMemory.instance.player.maxBudget+val>=0){
            CountriesMemory.instance.player.maxBudget+=val;
            CharactersMemory.instance.AddPlayerPop(-val);
        }

        MakeGraph();
    }

    public void SetReligionFreedom(){
        int value = int.Parse(groupReligion.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.religionLaw == (Country.ReligionLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.religionLaw = (Country.ReligionLaw)(value);
    }

    public void SetPartyFreedom(){
        int value = int.Parse(groupLaw.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.partyLaw == (Country.PartyLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.partyLaw = (Country.PartyLaw)(value);
    }

    public void SetElectionFreedom(){
        int value = int.Parse(groupElection.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.electionLaw == (Country.ElectionLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.electionLaw = (Country.ElectionLaw)(value);
    }

    public void SetIndutryMoney(){
        int value = int.Parse(groupIndustry.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.industryLaw == (Country.IndustryLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.industryLaw = (Country.IndustryLaw)(value);
    }

    public void SetSocialMoney(){
        int value = int.Parse(groupSocial.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.socialLaw == (Country.SocialLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.socialLaw = (Country.SocialLaw)(value);
    }

    public void SetArmyLaw(){
        int value = int.Parse(groupArmy.GetFirstActiveToggle().name);
        if(CountriesMemory.instance.player.armyLaw == (Country.ArmyLaw)value) return;

        switch (value)
        {
            case 0:
                CharactersMemory.instance.AddPlayerPop(5);
                break;
            case 1:
                CharactersMemory.instance.AddPlayerPop(-2);
                break;
            case 2:
                CharactersMemory.instance.AddPlayerPop(-5);
                break;

        }
        CountriesMemory.instance.player.armyLaw = (Country.ArmyLaw)(value);
    }

    public void UpdateParties(){
        GameObject obj = Instantiate(partyLabelPrefab);
        obj.transform.SetParent(partiesRoot);
        obj.GetComponent<Image>().sprite = Gfx.GetSpriteParty(PartiesMemory.instance.player.alignement,PartiesMemory.instance.player.indexFlag);

        foreach(Party p in PartiesMemory.instance.parties){
            obj = Instantiate(partyLabelPrefab);
            obj.transform.SetParent(partiesRoot);
            obj.GetComponent<Image>().sprite = Gfx.GetSpriteParty(p.alignement,p.indexFlag);
        }
    }
}

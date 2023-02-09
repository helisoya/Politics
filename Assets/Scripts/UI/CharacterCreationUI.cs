using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUI : MonoBehaviour
{
    [SerializeField] private Slider hairR;
    [SerializeField] private Slider hairG;
    [SerializeField] private Slider hairB;
    [SerializeField] private Slider headR;
    [SerializeField] private Slider headG;
    [SerializeField] private Slider headB;
    [SerializeField] private Slider bodyR;
    [SerializeField] private Slider bodyG;
    [SerializeField] private Slider bodyB;

    [SerializeField] private Image body;
    [SerializeField] private Image head;
    [SerializeField] private Image hair;

    [SerializeField] private InputField nom;
    [SerializeField] private InputField prenom;
    [SerializeField] private Slider age;

    [SerializeField] private Text ageText;

    private int headIndex = 0;
    private int hairIndex = 0;
    private int bodyIndex = 0;

    public void UpdateColors(){
        hair.color = new Color(hairR.value,hairG.value,hairB.value);
        head.color = new Color(headR.value,headG.value,headB.value);
        body.color = new Color(bodyR.value,bodyG.value,bodyB.value);
    }

    public void UpdateAge(){
        ageText.text = ((int)age.value).ToString();
    }


    public void UpdateBody(int val){
        bodyIndex = (bodyIndex + val + CharactersMemory.instance.maxBodyImages) % CharactersMemory.instance.maxBodyImages;
        body.sprite = Gfx.GetSpriteBody(bodyIndex);
    }

    public void UpdateHair(int val){
        hairIndex = (hairIndex + val + CharactersMemory.instance.maxHairImages) % CharactersMemory.instance.maxHairImages;
        hair.sprite = Gfx.GetSpriteHair(hairIndex);
    }

    public void UpdateHead(int val){
        headIndex = (headIndex + val + CharactersMemory.instance.maxHeadImages) % CharactersMemory.instance.maxHeadImages;
        head.sprite = Gfx.GetSpriteHead(headIndex);
    }


    public void Valid(){
        CharactersMemory.instance.player.age = (int)age.value;
        CharactersMemory.instance.player.nom = nom.text;
        CharactersMemory.instance.player.prenom = prenom.text;
        CharactersMemory.instance.player.hairColor = new Color(hairR.value,hairG.value,hairB.value);
        CharactersMemory.instance.player.headColor = new Color(headR.value,headG.value,headB.value);
        CharactersMemory.instance.player.bodyColor = new Color(bodyR.value,bodyG.value,bodyB.value);
        CharactersMemory.instance.player.bodyIndex = bodyIndex;
        CharactersMemory.instance.player.headIndex = headIndex;
        CharactersMemory.instance.player.hairIndex = hairIndex;
        PlayerUI.instance.UpdatePlayerImage();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

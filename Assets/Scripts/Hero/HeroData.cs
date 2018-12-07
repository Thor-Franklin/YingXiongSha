using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData
{

    //protected AbstractMediator absMediator;
    public StringType heroName { get; set; }
    public HeroGender heroGender { get; set; }  // no asignment
    public IntType curHandCardsCount { get; set; }
    public IntType maxHP { get; set; }
    public IntType curHP { get; set; }
    public IntType targetNumber { get; set; }
    public IntType canPlayCardNum { get; set; }
    public IntType attackRange { get; set; }
    public IntType defenseRange { get; set; }
    public BoolType isEquipArmor { get; set; }
    public BoolType isIgnoreArmor { get; set; }  //qinggangjian effect
    public BoolType isUnlimitedKill { get; set; } //hufu effect
    public BoolType isHuntDown { get; set; }  //panlonggun effect
    public BoolType isCanRemove2Card { get; set; } //longlindao effect
    public BoolType isCanRemoveHorse { get; set; } //bawanggong effect
    public BoolType isCanRemove2CardToDamage { get; set; } //bolangchui effect
    public BoolType isMyRound { get; set; }
    public WeaponEffect weapEff { get; set; }
    public ArmorEffect armorEff { get; set; }
    public List<CardSkillType> cardSkillTypePool { get; set; }
    public List<PlayerSkillType> playerSkillType{ get; set; }
    public GameObjListType CurEquipCards { get; set; }
    public GameObjListType CurHandCards { get; set; }
    public GameObjListType CacheCards { get; set; }
    public GameObjListType CacheTargetPlayer { get; set; }
    public GameObjListType JudgeCards { get; set; }


    public HeroData(string hName,int mHP)
    {
        heroName = new StringType(hName);
        heroGender = HeroGender.None;
        curHandCardsCount = new IntType(0);
        maxHP = new IntType(mHP);
        curHP = new IntType(mHP);
        targetNumber = new IntType(1);
        canPlayCardNum = new IntType(1);
        attackRange = new IntType(1);
        defenseRange = new IntType(1);
        isEquipArmor = new BoolType(false);
        isIgnoreArmor = new BoolType(false);
        isUnlimitedKill = new BoolType(false);
        isHuntDown = new BoolType(false);
        isCanRemove2Card = new BoolType(false);
        isCanRemoveHorse = new BoolType(false);
        isCanRemove2CardToDamage = new BoolType(false);
        isMyRound = new BoolType(false);
        weapEff = WeaponEffect.None;
        armorEff = ArmorEffect.None;
        cardSkillTypePool = new List<CardSkillType>();
        playerSkillType = new List<PlayerSkillType>();
        CurEquipCards = new GameObjListType();
        CurHandCards = new GameObjListType();
        CacheCards = new GameObjListType();
        CacheTargetPlayer = new GameObjListType();
        JudgeCards = new GameObjListType();


    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindow : MonoBehaviour
{
    [SerializeField] Button confirmButton, cancelButton;
    [SerializeField] TextMeshProUGUI skillname, description, element, power, cooltime, range;
    int skillID;

    private void Start()
    {
        cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
        confirmButton.onClick.AddListener(() => 
        { 
            UnlockSkillInShop(); 
            gameObject.SetActive(false);
        });
    }

    public void SetInfo(int skillID)
    {
        this.skillID = skillID;
        skillname.text = $"{DataManager.Instance.SkillDict[skillID].Name}";
        description.text = $"{DataManager.Instance.SkillDict[skillID].Description}";
        element.text = $"속성 : {DataManager.Instance.SkillDict[skillID].SkillType}";
        power.text = $"위력 : {DataManager.Instance.SkillDict[skillID].Damage * 100}%";
        cooltime.text = $"기본 쿨타임 : {DataManager.Instance.SkillDict[skillID].CoolTime}초";
        range.text = $"범위 : {DataManager.Instance.SkillDict[skillID].Range}";
    }

    public void UnlockSkillInShop()
    {
        int cost = DataManager.Instance.SkillDict[skillID].Price;

        if (SkillUnlockManager.Instance.IsSkillUnlocked(skillID))
        {
            Debug.Log("이미 해금된 스킬입니다.");
        }
        else if (GameManager.Instance.HasEnoughGold(cost))
        {
            GameManager.Instance.SpendGold(cost);
            SkillUnlockManager.Instance.UnlockSkill(skillID);
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
}

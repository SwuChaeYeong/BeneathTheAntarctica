using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager<LevelManager>
{
    private int[] requiredExpPerLevel = { 0, 416, 981, 1856, 3125, 4896, 7301, 10496, 14661, 20000 }; // 각 레벨마다 필요한 경험치
    private int[] hpLevel = { 100, 400, 1350, 3200, 6250, 10800, 17150, 25600, 36450, 50000 }; // 각 레벨별 체력

    // 현재 레벨과 경험치
    private int currentLevel = 1;
    private int currentExp = 0;
    

    // 경험치 획득
    public void AddExp(int exp)
    {
        currentExp += exp;
        UIManager.Instance.UpdateExpBar(currentExp, requiredExpPerLevel[currentLevel]);
        UIManager.Instance.UpdateLevelText(currentLevel, currentExp, requiredExpPerLevel[currentLevel]);

        // 레벨업 체크
        while (currentExp >= requiredExpPerLevel[currentLevel] && currentLevel < requiredExpPerLevel.Length - 1)
        {
            LevelUp();
        }
    }

    // 레벨업
    private void LevelUp()
    {
        currentLevel++;
        currentExp -= requiredExpPerLevel[currentLevel - 1];
        //EXP 재설정
        UIManager.Instance.UpdateLevelText(currentLevel, currentExp, requiredExpPerLevel[currentLevel]);
        UIManager.Instance.UpdateExpBar(currentExp, requiredExpPerLevel[currentLevel]);
        //HP 재설정
        UIManager.Instance.UpdateLevelHpText(hpLevel[currentLevel]);
        UIManager.Instance.UpdateLevelHpBar(hpLevel[currentLevel]);
    }

    // 현재 레벨 반환
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    // 현재 경험치 반환
    public int GetCurrentExp()
    {
        return currentExp;
    }

    // 현재 최대 체력 반환
    public int GetCurrentHp()
    {
        return hpLevel[currentLevel];
    }
}

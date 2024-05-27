using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Status
{
    public int grade;
    public int intelligence;
    public int attractiveness;
    public int health;
}
[Serializable]
public struct missionList
{
    //clear한 미션 이름을 담는 배열
    public List<string> missions;
}
[Serializable]
public class PlayerData
{
    public Status status;
    public Dictionary<string, missionList> clearMissionList;
}


public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    instance = go.AddComponent<GameManager>();
                    instance.gameObject.AddComponent<LoadScene>(); // 씬 로드 기능도 가지고 있기
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    public string nowMissionCode; // 현재 미션 정보
    public PlayerData playerData;


    /// <summary>
    /// 미션 코드 설정하기 (AR 인증 화면으로 이동 시에 호출)
    /// </summary>
    /// <param name="code"></param>
    public void SetMissionCode(string code)
    {
        nowMissionCode = code;
    }

    #region Status Up and Down
    /// <summary>
    /// num으로 학년 바꾸기 (1~4)
    /// </summary>
    /// <param name="num"></param>
    public void ChangeGrade(int num)
    {
        playerData.status.grade = num;
    }

    public void IntelligenceStatusUpDown(int num)
    {
        playerData.status.intelligence += num;
    }
    public void AttractivenessStatusUpDown(int num)
    {
        playerData.status.attractiveness += num;
    }
    public void HealthStatusUpDown(int num)
    {
        playerData.status.health += num;
    }
    #endregion
}
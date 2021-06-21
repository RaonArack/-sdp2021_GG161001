using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour, ISubject
{
    #region 메뉴 모음
    [Header("메뉴 오브젝트")]
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject fieldMenu;
    public GameObject bossMenu;
    public GameObject resultMenu;
    [HideInInspector] public GameObject selectedMenu;
    #endregion

    #region 메인메뉴
    #endregion

    #region 환경설정
    string changeKeyName;
    [Header("환경설정")]
    public Text leftKey;
    public Text rightKey;
    public Text jumpKey;
    public Text attackKey;
    #endregion

    #region 게임_필드전
    #endregion

    #region 게임_보스전
    #endregion

    #region 게임종료
    #endregion

    #region 옵저버 패턴
    List<Observer> notifyList;
    public void AddObserver(Observer observer)
    {
        notifyList.Add(observer);
        Debug.Log("추가한 후의 옵저버 길이 : " + notifyList.Count);
    }
    public void RemoveObserver(Observer observer)
    {
        notifyList.Remove(observer);
        Debug.Log("제거한 후의 옵저버 길이 : " + notifyList.Count);
    }
    public void OnNotify()
    {
        foreach (Observer obs in notifyList)
        {
            obs.OnNotify();
        }
    }
    #endregion

    void Awake()
    {
        notifyList = new List<Observer>();
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
        fieldMenu.SetActive(false);
        bossMenu.SetActive(false);
        resultMenu.SetActive(false);
    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && Input.anyKeyDown)
        {
            Debug.Log("키입력 시도함");
            if (changeKeyName == null) { return; }
            Debug.Log(changeKeyName + " / " + e.keyCode);
            GameManager.Instance().player.command.SetCommand(changeKeyName, e.keyCode);
            changeKeyName = null;
            OnNotify();
        }
    }

    public void CommandChange(string name)
    {
        // 환경설정 UI의 조작키 변경 버튼에 들어감
        changeKeyName = name;
        Debug.Log("현재 선택한 조작키 : " + changeKeyName);
    }
}
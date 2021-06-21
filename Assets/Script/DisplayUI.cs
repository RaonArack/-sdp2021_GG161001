using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour, ISubject
{
    #region �޴� ����
    [Header("�޴� ������Ʈ")]
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject fieldMenu;
    public GameObject bossMenu;
    public GameObject resultMenu;
    [HideInInspector] public GameObject selectedMenu;
    #endregion

    #region ���θ޴�
    #endregion

    #region ȯ�漳��
    string changeKeyName;
    [Header("ȯ�漳��")]
    public Text leftKey;
    public Text rightKey;
    public Text jumpKey;
    public Text attackKey;
    #endregion

    #region ����_�ʵ���
    #endregion

    #region ����_������
    #endregion

    #region ��������
    #endregion

    #region ������ ����
    List<Observer> notifyList;
    public void AddObserver(Observer observer)
    {
        notifyList.Add(observer);
        Debug.Log("�߰��� ���� ������ ���� : " + notifyList.Count);
    }
    public void RemoveObserver(Observer observer)
    {
        notifyList.Remove(observer);
        Debug.Log("������ ���� ������ ���� : " + notifyList.Count);
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
            Debug.Log("Ű�Է� �õ���");
            if (changeKeyName == null) { return; }
            Debug.Log(changeKeyName + " / " + e.keyCode);
            GameManager.Instance().player.command.SetCommand(changeKeyName, e.keyCode);
            changeKeyName = null;
            OnNotify();
        }
    }

    public void CommandChange(string name)
    {
        // ȯ�漳�� UI�� ����Ű ���� ��ư�� ��
        changeKeyName = name;
        Debug.Log("���� ������ ����Ű : " + changeKeyName);
    }
}
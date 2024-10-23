using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Text QuestListtext;

    public List<QuestDataSO> Quests;
    private static QuestManager instance;
    private string questPrint;

    public static QuestManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        LoadQuestList();
    }

    private void LoadQuestList()
    {

        for (int i = 0; i < Quests.Count; i++)
        {
            questPrint += $"Quest {i + 1} - {Quests[i].QuestName} (�ּ� ���� {Quests[i].QuestRequiredLevel})";

            if (Quests[i] is MonsterQuestDataSO monsterQuestDataSO)
            {
                questPrint += $"\n           {monsterQuestDataSO.MonsterName} ��(��) {monsterQuestDataSO.KillCount} ��ŭ ����\n\n";
            }
            else if (Quests[i] is EncounterQuestDataSO encounterQuestDataSO)
            {
                questPrint += $"\n           {encounterQuestDataSO.NPCName} �� ��ȭ�ϱ�\n\n";
            }
        }
        QuestListtext.text = questPrint;
    }
}
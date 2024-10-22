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
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            questPrint += $"Quest {i + 1} - {Quests[i].QuestName} (최소 레벨 {Quests[i].QuestRequiredLevel})";

            if (Quests[i] is MonsterQuestDataSO monsterQuestDataSO)
            {
                questPrint += $"\n           {monsterQuestDataSO.MonsterName} 을(를) {monsterQuestDataSO.KillCount} 만큼 소탕\n\n";
            }
            else if (Quests[i] is EncounterQuestDataSO encounterQuestDataSO)
            {
                questPrint += $"\n           {encounterQuestDataSO.NPCName} 과 대화하기\n\n";
            }
        }
        QuestListtext.text = questPrint;
    }
}
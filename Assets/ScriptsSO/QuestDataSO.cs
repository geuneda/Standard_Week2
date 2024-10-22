using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "Quest/QuestData")]
public class QuestDataSO : ScriptableObject
{
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites = new List<int>();
}

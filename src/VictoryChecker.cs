using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    public bool allVictoryConditionsMet;
    public List<VictoryCondition> victoryConditions;
    private void Update()
    {
        allVictoryConditionsMet = CheckVictoryConditions();
    }

    public bool CheckVictoryConditions()
    {
        for (int i = 0; i < victoryConditions.Count; i++)
        {
            if (!victoryConditions[i].conditionMet)
            {
                return false;
            }
        }
        return true;
    }
}

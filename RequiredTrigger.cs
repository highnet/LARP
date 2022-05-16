using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RequiredTrigger : VictoryCondition
{
    private void Start()
    {
    }

    public void UpdateRequirementsMet(bool _requirementMet)
    {
        conditionMet = _requirementMet;

    }


}

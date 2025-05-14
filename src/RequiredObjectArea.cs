using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RequiredObjectArea : VictoryCondition
{
    public List<GameObject> requiredObjects;
    public List<GameObject> collidingObjects;
    private Collider area;
    public Material[] displayMaterials;
    private MeshRenderer meshRenderer;


    private void Start()
    {
        area = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateRequirementsMet();

    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObjects.Add(other.gameObject);
        UpdateRequirementsMet();
    }


    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);
        UpdateRequirementsMet();
    }

    public void UpdateRequirementsMet()
    {
        if (requiredObjects.Count == 0)
        {
            conditionMet = true;
        } else
        {
            var intersectionOfLists = requiredObjects.Where(x => collidingObjects.Any(y => x == y)).ToList();
            conditionMet = (intersectionOfLists.Count == requiredObjects.Count);
        }
        if (conditionMet)
        {
            meshRenderer.material = displayMaterials[1];
        }
        else
        {
            meshRenderer.material = displayMaterials[0];

        }

    }


}

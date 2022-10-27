
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        MEDIEVAL,
        SCI_FI,
        ANCIENT
    }

    public List<ArtSetup> artSetups;

    public GameObject GetPropByType(ArtType artType)
    {
        foreach(var setup in artSetups)
        {
            if(setup.artType == artType)
            {
                return setup.artProps[Random.Range(0, setup.artProps.Count)];
            }
        }

        return null;
    }

}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public List<GameObject> artProps;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject artProp;

    public void ChangeArtProp(GameObject prop)
    {
        if (artProp != null) Destroy(artProp);

        artProp = Instantiate(prop, transform);
    }
}

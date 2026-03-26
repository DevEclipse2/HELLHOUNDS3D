using System;
using UnityEngine;

public class Discombobulate : MonoBehaviour
{
    public GameObject[] bodyParts;
    string[] bodybits = new string[0];
    bool[] destroyed;
    public GameObject mesh;
    public void Dismember( string bodyPart)
    {
        int index;
        if((index = Array.IndexOf(bodybits, bodyPart )) >= 0)
        {
            bodyParts[index].GetComponent<DiscombobulateBit>().Ondisembowl();
        }
    }
    private void Start()
    {
        mesh.GetComponent<SkinnedMeshRenderer>().material.renderQueue = 3002;
        bodybits = new string[bodyParts.Length];
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodybits[i] = bodyParts[i].name;
        }
    }

}

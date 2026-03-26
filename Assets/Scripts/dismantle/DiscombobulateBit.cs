using UnityEngine;

public class DiscombobulateBit : MonoBehaviour
{
    public GameObject root;
    public GameObject child;
    public void Ondisembowl()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        if(child != null )
        {
            child.GetComponent<DiscombobulateBit>().Ondisembowl();
        }
    }
}

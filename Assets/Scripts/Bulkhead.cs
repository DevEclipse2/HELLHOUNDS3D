using UnityEngine;
using System.Collections.Generic;
public class Bulkhead : MonoBehaviour
{
    List<GameObject> adjacentLoaders = new List<GameObject>();
    List<GameObject> entities = new List<GameObject>();
    Collider collider;
    public LayerMask mask;
    private void OnTriggerEnter(Collider other)
    {
        if(collider.gameObject.layer == 7)
        {
            //add to load
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, transform.localScale * 0.5f, Vector3.zero ,transform.rotation,0.1f ,mask , QueryTriggerInteraction.Ignore);
        foreach (RaycastHit hit in hits) 
        {
            entities.Add(hit.collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

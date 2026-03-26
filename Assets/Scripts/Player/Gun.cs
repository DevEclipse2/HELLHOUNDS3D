using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    public int clipMax;
    public int clipCurrent;
    public int reserveMax;
    public int reserveCurrent;
    public Animator animator;
    public GameObject animationFlag;
    AnimValues values;
    public Transform tracerpoint;
    public Transform crosshair;
    public float maxRange = 200;
    public LayerMask mask;
    public LineRenderer lineRenderer;
    Material mat;
    Vector3 point;
    float shootTimer;
    bool canS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        lineRenderer.positionCount = 2;
        mat = new Material(lineRenderer.material);
        lineRenderer.material = mat;
        values = animationFlag.GetComponent<AnimValues>();
    }
    private IEnumerator turnoff()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetInteger("action", 0);

        yield return null;
    }

    public void Shoot()
    {
        if(values.boolNames.IndexOf("canShoot") != -1)
        {
            if (values.boolVals[values.boolNames.IndexOf("canShoot")])
            {
                animator.SetInteger("action", 1);
                StartCoroutine(turnoff());
                RaycastHit hit;
                Ray ray = new Ray(crosshair.position, crosshair.forward);
                //Debug.DrawRay(Crosshair.position, Crosshair.position.normalized * 400 , Color.azure);
            
                Physics.Raycast(ray, out hit , maxRange , mask);
                if(hit.collider != null)
                {
                    point = hit.point;
                    //Debug.Log(hit.collider.gameObject.name);
                    lineRenderer.SetPosition(0, tracerpoint.position);
                    lineRenderer.SetPosition(1, point);
                    shootTimer = 0;
                    if (hit.collider.CompareTag("enemy"))
                    {
                        Debug.Log("enemy hit");
                        hit.collider.gameObject.GetComponent<DiscombobulateBit>().root.GetComponent<Discombobulate>().Dismember(hit.collider.name);
                    }
                }
                else
                {
                    lineRenderer.SetPosition(0, tracerpoint.position);
                    lineRenderer.SetPosition(1, crosshair.forward * 200f);
                    shootTimer = 0;
                }
            }
        }
    }
    private void Update()
    {
        shootTimer += Time.deltaTime;
        mat.SetFloat("_Transparency", shootTimer);
        lineRenderer.material = mat;
    }

}

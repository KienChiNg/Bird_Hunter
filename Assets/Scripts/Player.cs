using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_player;
    public float waitingShot;
    float m_waitingShot;
    // bool shot = true;
    GameObject m_viewFinderClone;
    Vector3 m_Worldpos;
    void Start()
    {
        m_viewFinderClone = Instantiate(m_player, Vector3.zero, Quaternion.identity);
        m_waitingShot = waitingShot;
        // StartCoroutine(waitShot());
    }
    public void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        m_Worldpos = Worldpos;
        if (m_viewFinderClone)
        {
            m_viewFinderClone.transform.position = Worldpos;
        }
        m_waitingShot -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && m_waitingShot <= 0){
            show(Worldpos);
            m_waitingShot = waitingShot;
        }
    }

    // IEnumerator waitShot(){
    //     while()
    //     yield return new WaitForSeconds(3);
    //     if (Input.GetMouseButtonDown(0))
    //         show(m_Worldpos);
    // }
    public void show(Vector3 mousePos)
    {
        Vector3 shootDis = Camera.main.transform.position - mousePos;
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDis);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider && (Vector3.Distance((Vector2)hits[i].collider.transform.position, (Vector2)mousePos) < 0.4f))
            {
                Bird bird = hits[i].collider.GetComponent<Bird>();
                if (bird){
                    bird.die();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGate : MonoBehaviour
{
    Collider m_boxCollider = null;
    GameManager m_gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clear()
    {
        m_boxCollider.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            m_boxCollider.isTrigger = false;
            m_gameManager.Goal();
        }
    }
}

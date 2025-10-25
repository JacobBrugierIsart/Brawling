using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] protected float m_Speed;

    protected Vector3 m_Direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        print("update move");
        transform.position += m_Direction * m_Speed * Time.deltaTime;
    }
}

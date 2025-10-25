using Unity.Android.Gradle;
using UnityEngine;

public class Player : Move
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private string _HorizontalAxis = "Horizontal";
    private string _VerticalAxis = "Vertical";

    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        print("update player");
        m_Direction = Input.GetAxis(_HorizontalAxis) * Vector3.right + Input.GetAxis(_VerticalAxis) * Vector3.forward;
    }
}

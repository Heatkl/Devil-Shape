using UnityEngine;
using UnityEngine.Events;

public class MouseAction : MonoBehaviour
{
    public Color hoverColor;
    MeshRenderer mesh;
    Color normalColor;
    bool isOver = false;

    public UnityEvent MouseEnter;
    public UnityEvent MouseExit;
    public UnityEvent MouseDown;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        normalColor = mesh.material.color;
    }
    private void OnMouseEnter()
    {
        mesh.material.color = hoverColor;
        isOver = true;
        Debug.Log("OVer");
        MouseEnter.Invoke();
    }

    private void OnMouseExit()
    {
        mesh.material.color = normalColor;
        isOver = false;
        MouseExit.Invoke();
    }

    private void OnMouseDown()
    {
        mesh.material.color = Color.black;
        Debug.Log("Down");
        MouseDown.Invoke();
    }
}

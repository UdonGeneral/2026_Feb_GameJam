using UnityEngine;
public class ColorChange : MonoBehaviour
{
    [SerializeField] Material mat = default;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
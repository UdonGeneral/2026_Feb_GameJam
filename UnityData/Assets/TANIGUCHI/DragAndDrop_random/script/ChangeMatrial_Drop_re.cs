using UnityEngine;
public class ColorMatrial_Drop_re : MonoBehaviour
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
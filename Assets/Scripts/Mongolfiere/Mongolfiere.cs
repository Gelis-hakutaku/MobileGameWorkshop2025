using UnityEngine;

public class Mongolfiere : MonoBehaviour
{
    public GameObject otherGameObject;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = otherGameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        otherGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

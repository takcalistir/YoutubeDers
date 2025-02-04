using UnityEngine;

public class MermiKontrol : MonoBehaviour
{
    Vector3 hedef;
    Vector3 yon;

    public float hiz;

    void Start()
    {
        
    }

    void Update()
    {
        if (yon != null)
        {
            transform.position += hiz * Time.deltaTime * yon;
        }
    }

    public void HedefBelirle(Vector3 hedefPoz)
    {
        hedef = hedefPoz;
        yon = (hedef - transform.position).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hedef vuruldu");
        Destroy(gameObject);
    }
}

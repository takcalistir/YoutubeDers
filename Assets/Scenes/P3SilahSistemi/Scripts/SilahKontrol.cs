using UnityEngine;

public class SilahKontrol : MonoBehaviour
{
    Camera kamera;
    public GameObject mermi;

    Vector3 mermiPoz;
    Vector3 hedefPoz;

    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AtesEt();
        }
    }

    void AtesEt()
    {
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hedefPoz = hit.point;
            mermiPoz = transform.GetChild(0).transform.position;

            GameObject tempMermi = Instantiate(mermi, mermiPoz, Quaternion.identity);
            tempMermi.GetComponent<MermiKontrol>().HedefBelirle(hedefPoz);
        }
    }
}

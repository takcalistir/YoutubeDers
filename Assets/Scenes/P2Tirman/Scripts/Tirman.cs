using UnityEngine;

public class Tirman : MonoBehaviour
{
    Camera kamera;

    bool tirmanBulundu = false;
    bool tirmanTuttu = false;
    bool tirmanGidiyor = false;

    public float hiz = 20f;

    RaycastHit hit;
    Vector3 tirmanPozisyon;

    void Start()
    {
        kamera = transform.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!tirmanBulundu)
        {
            TirmanTarama();
        }

        if (tirmanBulundu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tirmanTuttu = true;
            }

            if (tirmanTuttu)
            {
                TirmanTut();
            }

            if (Input.GetMouseButtonUp(0))
            {
                tirmanGidiyor = true;
            }

            if(tirmanGidiyor)
            {
                TirmanGit();
            }

            if (Input.GetMouseButtonDown(1))
            {
                TirmanBirak();
            }
        }
    }
    void TirmanTarama()
    {
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Tirman"))
                {
                    tirmanBulundu = true;
                    return;
                }
            }
        }

        tirmanBulundu = false;
    }
    void TirmanTut()
    {
        tirmanPozisyon = hit.point;
    }

    void TirmanGit()
    {
        Vector3 yeniPoz = tirmanPozisyon + (Vector3.up * 2);
        transform.position = Vector3.MoveTowards(transform.position, yeniPoz, hiz * Time.deltaTime);

        if (Vector3.Distance(transform.position, yeniPoz) == 0)
        {
            TirmanBirak();
        }
    }

    void TirmanBirak()
    {
        tirmanBulundu = false;
        tirmanGidiyor = false;
        tirmanTuttu = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPGFXManager : MonoBehaviour
{
    public GameObject HPPrefab;
    public float distanceFromPivot = 10f;

    public void SetHealth(int n)
    {
        Clear();
        if (n == 0)
            return;

        float interval = 360 / n;
        float rotCount = 0f;

        for(int i=0; i<n; i++)
        {
            GameObject hp = Instantiate(HPPrefab, transform.position, Quaternion.identity, transform);
            float radians = rotCount * 2f * Mathf.PI / 360f;
            float dx = Mathf.Cos(radians) * distanceFromPivot;
            float dy = Mathf.Sin(radians) * distanceFromPivot;
            hp.transform.localPosition += hp.transform.localPosition + new Vector3(dx,dy);
            rotCount += interval;
        }
    }

    private void Clear()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            Destroy(transform.GetChild(i).gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    //public float scrollSpeed;
    //public float tileSizeZ;

    //private Vector3 startPosition;

    //void Start()
    //{
    //    startPosition = transform.position;
    //}

    //void Update()
    //{
    //    float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
    //    transform.position = startPosition + Vector3.forward * newPosition;
    //}
    public float scrollSpeed;

    private Renderer m_render;
    private Vector2 savedOffset;

    void Awake()
    {
        GetComponents();
    }

    void Start()
    {
        InitialiseOffset();
    }

    void Update()
    {
        Scroll();
    }

    void GetComponents()
    {
        m_render = GetComponent<Renderer>();
    }

    void InitialiseOffset()
    {
        savedOffset = m_render.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Scroll()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, x);
        m_render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        m_render.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}

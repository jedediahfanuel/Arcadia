using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-10f,10f)]
    public float scrollSpeed = 1f;
    private float offset;
    private Material mat;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}

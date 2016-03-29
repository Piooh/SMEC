using UnityEngine;
using System.Collections;

public class ScrollBehaviour : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;

	private Renderer render = null;

	private void Awake()
	{
		render = GetComponent<Renderer>();
	}

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (null != render && render.enabled)
        {
			render.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
			//renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}

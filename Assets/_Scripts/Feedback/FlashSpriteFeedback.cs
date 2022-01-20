using System.Collections;
using UnityEngine;

public class FlashSpriteFeedback : Feedback
{
    [SerializeField] private SpriteRenderer modelRenderer;
    [SerializeField] private float flashTime;
    [SerializeField] private Material flashMaterial;

    private Shader originalShader;

    private void Start()
    {
        originalShader = modelRenderer.material.shader;
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        modelRenderer.material.shader = originalShader;
    }

    public override void CreateFeedback()
    {
        if (!modelRenderer.material.HasProperty("_IsHit"))
            modelRenderer.material.shader = flashMaterial.shader;

        modelRenderer.material.SetInt("_IsHit", 1);
        StartCoroutine(WaitForChangeBack());
    }

    private IEnumerator WaitForChangeBack()
    {
        yield return new WaitForSeconds(flashTime);
        if (modelRenderer.material.HasProperty("_IsHit"))
            modelRenderer.material.SetInt("_IsHit", 0);
        else
            modelRenderer.material.shader = originalShader;
    }
}
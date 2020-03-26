using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public Image previewImage;

    public void Awake()
    {
        meshRenderer = gameObject.GetComponentInParent<MeshRenderer>();
    }

    public void SetMaterial(Material newMaterial)
    {
        meshRenderer.material = newMaterial;
        previewImage.color = newMaterial.color;
    }
}

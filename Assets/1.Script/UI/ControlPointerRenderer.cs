using System;
using UnityEngine;

namespace _1.Script.UI
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ControlPointerRenderer : MonoBehaviour
    {
        private static readonly int ColorID = Shader.PropertyToID("_Color");
        
        private Material _material;
        private void Awake()
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            _material = new Material(meshRenderer.material);
            meshRenderer.material = _material;
        }


        public void SetColor(Color color)
        {
            _material.SetColor(ColorID, color);
        }
    }
}
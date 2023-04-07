using System.Collections.Generic;
using UnityEngine;

namespace ncs {

    using UnityEngine;

    public class PacmanSpriteGenerator : MonoBehaviour {

        public Material spriteMaterial;
        public float radius = 1f;
        public float mouthAngle = 45f;

        private void Start() {
            CreatePacManSprite(radius, mouthAngle);
        }

        private void CreatePacManSprite(float br, float ma) {
            GameObject pacMan = new GameObject("PacMan");
            pacMan.transform.SetParent(transform);
            pacMan.transform.localPosition = Vector3.zero;

            MeshFilter meshFilter = pacMan.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = pacMan.AddComponent<MeshRenderer>();

            meshFilter.mesh = CreatePacManMesh(br, ma);
            meshRenderer.material = spriteMaterial;
        }

        private Mesh CreatePacManMesh(float br, float ma) {
            Mesh mesh = new Mesh();
            int numSegments = 50;
            float angleStep = (360f - ma) / numSegments;
            Vector3[] vertices = new Vector3[numSegments + 2];
            int[] triangles = new int[numSegments * 3];

            vertices[0] = Vector3.zero;

            for (int i = 0; i <= numSegments; i++) {
                float angle = (ma / 2 + i * angleStep) * Mathf.Deg2Rad;
                vertices[i + 1] = new Vector3(br * Mathf.Cos(angle), br * Mathf.Sin(angle), 0f);

                if (i < numSegments) {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 2;
                    triangles[i * 3 + 2] = i + 1;
                    
                }
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            return mesh;
        }

    }

}
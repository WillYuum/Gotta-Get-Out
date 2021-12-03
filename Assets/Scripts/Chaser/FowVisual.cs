using UnityEngine;

namespace Chaser
{
    public class FowVisual : MonoBehaviour
    {
        private FOW fow;
        float angleIncrements;
        [SerializeField] private int rayCount = 200;


        private Vector3 origin;
        private Mesh mesh;
        [SerializeField] private Material lightMaterial;

        private float startingAngle;
        private Transform target;

        void Awake()
        {
            target = transform.parent;
            fow = gameObject.GetComponent<FOW>();

            CreateFowVisionMesh();
        }


        void Update()
        {
            UpdateFowVision();
        }

        private void CreateFowVisionMesh()
        {
            mesh = new Mesh();
            angleIncrements = fow.viewAngle / (rayCount);

            mesh = gameObject.GetComponent<MeshFilter>().mesh;
            gameObject.GetComponent<MeshRenderer>().material = lightMaterial;

            origin = Vector3.zero;
        }

        private void UpdateFowVision()
        {
            mesh.Clear();

            float angle = startingAngle;

            Vector3[] vertices = new Vector3[rayCount + 1 + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount * 3];

            vertices[0] = Vector3.zero;

            int vertexIndex = 1;
            int triangleIndex = 0;

            for (int i = 0; i <= rayCount; i++)
            {
                Vector3 vertex;
                Vector3 dirFromAngle = GetVectorFromAngle(angle, false);

                Vector3 globalDir = GetVectorFromAngle(angle, true);

                // Debug.DrawRay(origin, globalDir, Color.red);
                if (Physics.Raycast(origin, globalDir, out RaycastHit hitInfo, fow.viewRadius))
                {
                    vertex = target.InverseTransformPoint(hitInfo.point);
                    vertex.y = 0;
                }
                else
                {
                    vertex = dirFromAngle * fow.viewRadius;
                }

                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                vertexIndex++;
                angle -= angleIncrements;
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
            mesh.Optimize();
        }

        public void SetOrigin(Vector3 _origin)
        {
            origin = _origin;
        }

        private Vector3 GetVectorFromAngle(float angleInDegs, bool angleIsGlobal)
        {
            if (angleIsGlobal)
            {
                angleInDegs += target.eulerAngles.y;
            }
            float angleRad = (angleInDegs * Mathf.Deg2Rad);
            return new Vector3(Mathf.Sin(angleRad), 0, Mathf.Cos(angleRad));
        }


        public void SetAimDirection(Vector3 aimDirection)
        {
            startingAngle = GetAngleFromVectorFloat(aimDirection) + fow.viewAngle / 2;
        }

        private float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }
    }
}
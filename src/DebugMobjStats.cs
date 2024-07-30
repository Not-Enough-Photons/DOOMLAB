using UnityEngine;

using Il2CppTMPro;

using NEP.DOOMLAB.Entities;

namespace NEP.DOOMLAB.Debug
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class DebugMobjStats : MonoBehaviour
    {
        public DebugMobjStats(System.IntPtr ptr) : base(ptr) { }

        public TextMeshPro statText;
        private Mobj mobj;
        private Camera camera;
        private LineRenderer lineRenderer;

        private GameObject debugColliderRoot;

        private LineRenderer topRenderer;
        private LineRenderer bottomRenderer;
        private LineRenderer topLeftRenderer;
        private LineRenderer bottomLeftRenderer;
        private LineRenderer topRightRenderer;
        private LineRenderer bottomRightRenderer;

        private void Awake()
        {
            camera = Camera.main;
            statText = GetComponent<TextMeshPro>();
            mobj = GetComponentInParent<Mobj>();
            lineRenderer = GetComponent<LineRenderer>();
            
            lineRenderer.alignment = LineAlignment.View;
            lineRenderer.startWidth = 0.0075f;
            lineRenderer.endWidth = 0.0075f;

            debugColliderRoot = transform.parent.GetChild(2).gameObject;

            topRenderer = debugColliderRoot.transform.GetChild(0).GetComponent<LineRenderer>();
            bottomRenderer = debugColliderRoot.transform.GetChild(1).GetComponent<LineRenderer>();
            topLeftRenderer = debugColliderRoot.transform.GetChild(2).GetComponent<LineRenderer>();
            bottomLeftRenderer = debugColliderRoot.transform.GetChild(3).GetComponent<LineRenderer>();
            topRightRenderer = debugColliderRoot.transform.GetChild(4).GetComponent<LineRenderer>();
            bottomRightRenderer = debugColliderRoot.transform.GetChild(5).GetComponent<LineRenderer>();

            SetMobj(mobj);

            statText.enableWordWrapping = false;
            statText.fontSize = 1;
        }

        public void SetMobj(Mobj mobj)
        {
            this.mobj = mobj;
            statText.transform.localPosition = Vector3.up * mobj.height / 32f;
        }

        public void Update()
        {
            gameObject.SetActive(Settings.EnableMobjDebug);
            debugColliderRoot.SetActive(Settings.EnableMobjDebugColliders);
            lineRenderer.enabled = Settings.EnableMobjDebugLines;

            Vector3 cameraPosition = camera.transform.position;
            Quaternion rotation = Quaternion.LookRotation(cameraPosition - transform.position, Vector3.up);
            Vector3 targetRotationEuler = new Vector3(transform.eulerAngles.x, rotation.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(targetRotationEuler);

            SetText();

            if(Settings.EnableMobjDebugLines)
            {
                Vector3 origin = mobj.transform.position + Vector3.up;
                Vector3 direction = Mobj.player.transform.position + Vector3.up;
                DrawDebugLine(origin, direction, mobj.brain.SeesTarget ? Color.green : Color.red);
            }

            if(Settings.EnableMobjDebugColliders)
            {
                DrawDebugBox(mobj.collider);
            }
        }

        private void SetText()
        {
            string type = mobj.type.ToString();
            string health = mobj.health.ToString();
            string currentState = mobj.currentState.ToString();
            string action = mobj.CurrentAction?.Method.Name;
            string actionExecutionTime = mobj.ActionStopwatch.Elapsed.TotalMilliseconds.ToString();
            string direction = mobj.moveDirection.ToString();
            string moveCount = mobj.moveCount.ToString();
            string canSeeTarget = mobj.brain.SeesTarget ? "<color=green>True</color>" : "<color=red>False</color>";

            string output = "";
            output += type + "\n";
            output += "Health: " + health + '\n';
            output += "State: " + currentState + "\n";
            output += "Action: " + action + $"({actionExecutionTime} ms)" + "\n";
            output += $"Direction - {direction} | Move Count - {moveCount}\n\n";
            output += "<size=0.75>Sees Target: " + canSeeTarget;

            statText.text = output;
        }

        private void DrawDebugLine(Transform a, Transform b, Color color)
        {
            if(a == null || b == null)
            {
                return;
            }

            DrawDebugLine(a.position, b.position, color);
        }

        public void DrawDebugBox(BoxCollider boxCollider)
        {
            if (topRenderer == null || bottomRenderer == null)
            {
                return;
            }

            if (boxCollider == null)
            {
                return;
            }

            Vector3 halfSize = boxCollider.size * 0.5f;
            Vector3 offset = Vector3.up * (mobj.height / 32f) / 2f;

            Vector3 t1 = new Vector3(-halfSize.x, halfSize.y, -halfSize.z);
            Vector3 t2 = new Vector3(halfSize.x, halfSize.y, -halfSize.z);
            Vector3 t3 = new Vector3(-halfSize.x, halfSize.y, halfSize.z);
            Vector3 t4 = new Vector3(halfSize.x, halfSize.y, halfSize.z);

            Vector3 b1 = new Vector3(-halfSize.x, -halfSize.y, -halfSize.z);
            Vector3 b2 = new Vector3(halfSize.x, -halfSize.y, -halfSize.z);
            Vector3 b3 = new Vector3(-halfSize.x, -halfSize.y, halfSize.z);
            Vector3 b4 = new Vector3(halfSize.x, -halfSize.y, halfSize.z);

            t1 += offset;
            t2 += offset;
            t3 += offset;
            t4 += offset;

            b1 += offset;
            b2 += offset;
            b3 += offset;
            b4 += offset;

            topRenderer.positionCount = 5;
            topRenderer.SetPositions(new Vector3[] { t1, t2, t4, t3, t1 });

            bottomRenderer.positionCount = 5;
            bottomRenderer.SetPositions(new Vector3[] { b1, b2, b4, b3, b1 });

            topLeftRenderer.positionCount = 2;
            bottomLeftRenderer.positionCount = 2;
            topRightRenderer.positionCount = 2;
            bottomRightRenderer.positionCount = 2;

            topLeftRenderer.SetPositions(new Vector3[] { b1, t1 });
            bottomLeftRenderer.SetPositions(new Vector3[] { b2, t2 });
            topRightRenderer.SetPositions(new Vector3[] { b3, t3 });
            bottomRightRenderer.SetPositions(new Vector3[] { b4, t4 });
        }

        private void DrawDebugLine(Vector3 a, Vector3 b, Color color)
        {
            if(lineRenderer == null)
            {
                return;
            }

            lineRenderer.SetPositions(new Vector3[] { a, b });
            lineRenderer.SetColors(color, color);
        }
    }
}
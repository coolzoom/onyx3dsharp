using Onyx3D;
using OpenTK;
using System.Collections.Generic;

namespace Onyx3DEditor
{
    public static class EditorSceneObjectUtils 
    {
        public static void Group(List<SceneObject> objects)
        {
            if (objects.Count == 0)
                return;

            SceneObject newObj = new SceneObject("New Group", SceneManagement.ActiveScene);
            newObj.Transform.LocalPosition = Selection.ActiveObject.Transform.LocalPosition;
            newObj.Parent = objects[0].Parent;
            foreach (SceneObject obj in objects)
            {
                obj.Parent = newObj;
            }

            Selection.ActiveObject = newObj;
        }

        // --------------------------------------------------------------------

        public static void Duplicate()
        {
            if (Selection.ActiveObject == null)
                return;

            List<SceneObject> newSelected = new List<SceneObject>();
            foreach (SceneObject selected in Selection.Selected)
            { 
                SceneObject clone = selected.Clone();
                newSelected.Add(clone);
            }

            Selection.Set(newSelected);
            
        }

        // --------------------------------------------------------------------

        public static void Delete(List<SceneObject> objs)
        {
            
			foreach (SceneObject selected in Selection.Selected)
			{
				selected.Destroy();
			}
            
            Selection.ActiveObject = null;
        }

        // --------------------------------------------------------------------

        public static void SetActiveAsParent()
        {
            if (Selection.ActiveObject == null)
                return;

            foreach (SceneObject obj in Selection.Selected)
            {
                if (obj != Selection.ActiveObject)
                    obj.Parent = Selection.ActiveObject;
            }

            MainWindow.Instance.UpdateHierarchy();
        }

        // --------------------------------------------------------------------

        public static void ClearParent()
        {
            if (Selection.ActiveObject == null || Selection.Selected.Count == 0)
                return;

            Scene scene = SceneManagement.ActiveScene;
            foreach (SceneObject obj in Selection.Selected)
            {
                obj.Parent = scene.Root;
            }

            MainWindow.Instance.UpdateHierarchy();
        }

        // --------------------------------------------------------------------

        public static void AddPrimitive(int meshType, string name, bool select = true)
        {
            SceneObject primitive = SceneObject.CreatePrimitive(meshType, name);
            primitive.Parent = SceneManagement.ActiveScene.Root;
            if (select)
                Selection.ActiveObject = primitive;
        }
        // --------------------------------------------------------------------

        public static void AddLine(string name, Vector3 point1, Vector3 point2, Vector3 color, bool select = true)
        {
            SceneObject primitive = SceneObject.CreateLine(name, point1, point2, color);
            primitive.Parent = SceneManagement.ActiveScene.Root;
            //if (select)
            //    Selection.ActiveObject = primitive;
        }

        // --------------------------------------------------------------------

        public static void AddCircle(string name, Vector3 position, float radius, Vector3 color, Vector3 up, int segments, bool select = true)
        {
            SceneObject primitive = SceneObject.CreateCircle(name, position, radius, color, up, segments);
            primitive.Parent = SceneManagement.ActiveScene.Root;
            //if (select)
            //    Selection.ActiveObject = primitive;
        }
        // --------------------------------------------------------------------

        public static void AddPrimitive(int meshType, string name, Vector3 position, Vector3 scale, Vector4 color, bool select = true)
        {
            SceneObject primitive = SceneObject.CreatePrimitive(meshType, name, position, scale, color);
            primitive.Parent = SceneManagement.ActiveScene.Root;
            if (select)
                Selection.ActiveObject = primitive;
        }

        // --------------------------------------------------------------------

        public static void AddReflectionProbe(bool select = true)
        {
            SceneObject obj = new SceneObject("ReflectionProbe", SceneManagement.ActiveScene);
            obj.Parent = SceneManagement.ActiveScene.Root;
            obj.Transform.LocalPosition = new Vector3(0, 0, 0);
            ReflectionProbe mReflectionProbe = obj.AddComponent<ReflectionProbe>();
            mReflectionProbe.Init(64);
            if (select)
                Selection.ActiveObject = obj;
        }
        public static void AddReflectionProbe(Vector3 position, int size, bool select = true)
        {
            SceneObject obj = new SceneObject("ReflectionProbe", SceneManagement.ActiveScene);
            obj.Parent = SceneManagement.ActiveScene.Root;
            obj.Transform.LocalPosition = position; new Vector3(0, 0, 0);
            ReflectionProbe mReflectionProbe = obj.AddComponent<ReflectionProbe>();
            mReflectionProbe.Init(size); //64
            //if (select)
            //    Selection.ActiveObject = obj;
        }
        // --------------------------------------------------------------------

        public static void AddLight()
        {
            SceneObject light = new SceneObject("Light");
            Light lightC = light.AddComponent<Light>();
            light.Parent = SceneManagement.ActiveScene.Root;
            Selection.ActiveObject = light;
        }

        // --------------------------------------------------------------------

        public static void AddCamera()
        {
            PerspectiveCamera cam = new PerspectiveCamera("Camera", MathHelper.DegreesToRadians(45), 1.5f);
            cam.Aspect = 1;
            cam.Parent = SceneManagement.ActiveScene.Root;
            Selection.ActiveObject = cam;
        }
    }
}

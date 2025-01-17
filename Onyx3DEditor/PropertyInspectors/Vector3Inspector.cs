﻿using OpenTK;

using System.ComponentModel;

namespace Onyx3DEditor
{
	[TypeConverter(typeof(Vector3Converter))]
	public class Vector3Inspector : PropertyInspector<Vector3>
	{

		public Vector3Inspector(Vector3 v) : base(v) { }

		public float X
		{
			get { return mObject.X; }
			set { mObject.X = value; }
		}
		public float Y
		{
			get { return mObject.Y; }
			set { mObject.Y = value; }
		}
		public float Z
		{
			get { return mObject.Z; }
			set { mObject.Z = value; }
		}

		public override string ToString()
		{
			return "["+ X + "," + Y + "," + Z + "]";
		}
	}

}
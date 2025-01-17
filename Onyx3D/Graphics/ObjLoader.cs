﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using OpenTK;

namespace Onyx3D
{
	public static class ObjLoader
	{

		public class Face
		{
			public FaceIndices[] Indices = new FaceIndices[3];
			public Vector3 Tangent;
			public Vector3 Bitangent;
		}

		public class FaceIndices
		{
			public string VertexId = "";
			public int VertexIndex = -1;
			public int TextureCoordIndex = -1;
			public int NormalIndex = -1;
		}

		public static Mesh Load(string path)
		{

			if (!File.Exists(path))
			{
				throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
			}

			List<Vector4> vertices = new List<Vector4>();
			List<Vector3> textureVertices = new List<Vector3>();
			List<Vector3> normals = new List<Vector3>();
			//List<FaceIndices> indices = new List<FaceIndices>();
			List<Face> faces = new List<Face>();

			using (StreamReader streamReader = new StreamReader(path))
			{
				while (!streamReader.EndOfStream)
				{
					List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
					words.RemoveAll(s => s == string.Empty);

					if (words.Count == 0)
						continue;

					string type = words[0];
					words.RemoveAt(0);

					switch (type)
					{
						// vertex
						case "v":
							vertices.Add(new Vector4(float.Parse(words[0]), float.Parse(words[1]),
													float.Parse(words[2]), words.Count < 4 ? 1 : float.Parse(words[3])));
							break;

						case "vt":
							textureVertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]),
															words.Count < 3 ? 0 : float.Parse(words[2])));
							break;

						case "vn":
							normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
							break;

						// face
						case "f":

							Face face = new Face();
							int i = 0;
							foreach (string w in words)
							{
								if (w.Length == 0)
									continue;

								string[] comps = w.Split('/');

								FaceIndices fi = new FaceIndices();

								fi.VertexId = w;

								// subtract 1: indices start from 1, not 0
								fi.VertexIndex = int.Parse(comps[0]) - 1;

								if (comps.Length > 1 && comps[1].Length != 0)
									fi.TextureCoordIndex = int.Parse(comps[1]) - 1;

								if (comps.Length > 2)
									fi.NormalIndex = int.Parse(comps[2]) - 1;

								face.Indices[i] = fi;
								i++;
							}

							// Calculate face Tangent/Bitangent
							Vector4 pos1 = vertices[face.Indices[0].VertexIndex];
							Vector4 pos2 = vertices[face.Indices[1].VertexIndex];
							Vector4 pos3 = vertices[face.Indices[2].VertexIndex];

							Vector3 uv1 = textureVertices[face.Indices[0].TextureCoordIndex];
							Vector3 uv2 = textureVertices[face.Indices[1].TextureCoordIndex];
							Vector3 uv3 = textureVertices[face.Indices[2].TextureCoordIndex];

							Vector4 edge1 = pos2 - pos1;
							Vector4 edge2 = pos3 - pos1;
							Vector3 deltaUV1 = uv2 - uv1;
							Vector3 deltaUV2 = uv3 - uv1;

							float f = 1.0f / (deltaUV1.X * deltaUV2.Y - deltaUV2.X * deltaUV1.Y);

							Vector3 tangent = new Vector3();
							tangent.X = f * (deltaUV2.Y * edge1.X - deltaUV1.Y * edge2.X);
							tangent.Y = f * (deltaUV2.Y * edge1.Y - deltaUV1.Y * edge2.Y);
							tangent.Z = f * (deltaUV2.Y * edge1.Z - deltaUV1.Y * edge2.Z);
							tangent.Normalize();

							Vector3 bitangent = new Vector3();
							bitangent.X = f * (-deltaUV2.X * edge1.X + deltaUV1.X * edge2.X);
							bitangent.Y = f * (-deltaUV2.X * edge1.Y + deltaUV1.X * edge2.Y);
							bitangent.Z = f * (-deltaUV2.X * edge1.Z + deltaUV1.X * edge2.Z);
							bitangent.Normalize();

							face.Tangent = tangent;
							face.Bitangent = bitangent;

							faces.Add(face);

							break;

						default:
							break;
					}
				}
			}

			List<int> meshIndices = new List<int>();
			Mesh m = new Mesh();
			Dictionary<String, int> vertmap = new Dictionary<string, int>();
			int index = 0;

			foreach (Face face in faces)
			{
				foreach (FaceIndices fi in face.Indices)
				{
					Vertex v;

					if (vertmap.ContainsKey(fi.VertexId))
					{
						int vindex = vertmap[fi.VertexId];
						v = m.Vertices[vindex];
						v.Tangent += face.Tangent;
						v.Bitangent += face.Bitangent;
						v.Tangent = v.Tangent.Normalized();
						v.Bitangent = v.Bitangent.Normalized();
						m.Vertices[vindex] = v;

						meshIndices.Add(vindex);
					}
					else
					{
						v = new Vertex(vertices[fi.VertexIndex].Xyz);
						v.Tangent = face.Tangent;
						v.Bitangent = face.Bitangent;
						if (fi.NormalIndex >= 0) v.Normal = normals[fi.NormalIndex];
						if (fi.TextureCoordIndex >= 0) v.TexCoord = textureVertices[fi.TextureCoordIndex].Xy;
						m.Vertices.Add(v);
						vertmap.Add(fi.VertexId, index);
						meshIndices.Add(index);
						index++;
					}
				}
			}

			m.Indices = meshIndices.ToArray();
			m.GenerateVAO();

			return m;
		}
	}
}

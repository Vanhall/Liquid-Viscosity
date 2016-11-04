using System;
using System.Collections.Generic;
using System.IO;
using Tao.OpenGl;

namespace LiquidViscosity
{
    class model
    {
        private string modelPath = "";
        private string modelName = "";

        private int[] VertBuf = new int[1];
        private int[] NormBuf = new int[1];
        private int VertexCount = 0;

        public material mat;
        public void setMaterial(material new_mat)
        {
            mat = new_mat;
        }

        public model(string path, string name)
        {
            modelName = name;
            modelPath = path;
            
            #region Obj parser
            List<float> VertexCoords = new List<float>();
            List<float> NormalCoords = new List<float>();
            List<int> VIndexes = new List<int>();
            List<int> NIndexes = new List<int>();

            string[] ObjContent = File.ReadAllLines(path + name + ".obj");
            string[][] ObjSplit = new string[ObjContent.Length][];
            for (int i = 0; i < ObjContent.Length; i++)
            {
                ObjSplit[i] = ObjContent[i].Split(' ', '/');
                if (ObjSplit[i][0] == "v")
                {
                    for (int j = 1; j < 4; j++)
                    {
                        VertexCoords.Add(float.Parse(ObjSplit[i][j],
                            System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                if (ObjSplit[i][0] == "vn")
                {
                    for (int j = 1; j < 4; j++)
                    {
                        NormalCoords.Add(float.Parse(ObjSplit[i][j],
                            System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                if (ObjSplit[i][0] == "f")
                {
                    for (int j = 1; j < 9; j += 3)
                    {
                        VIndexes.Add(int.Parse(ObjSplit[i][j]));
                        NIndexes.Add(int.Parse(ObjSplit[i][j + 2]));
                    }
                }
            }

            VertexCount = VIndexes.Count;
            float[] VertArray = new float[VIndexes.Count * 3];
            float[] NormArray = new float[VIndexes.Count * 3];

            for (int i = 0; i < VIndexes.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    VertArray[i * 3 + j] = VertexCoords[(VIndexes[i] - 1) * 3 + j];
                    NormArray[i * 3 + j] = NormalCoords[(NIndexes[i] - 1) * 3 + j];
                }
            }
            #endregion

            Gl.glGenBuffers(1, VertBuf);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, VertBuf[0]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(VertArray.Length * sizeof(float)), VertArray, Gl.GL_STATIC_DRAW);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

            Gl.glGenBuffers(1, NormBuf);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, NormBuf[0]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(NormArray.Length * sizeof(float)), NormArray, Gl.GL_STATIC_DRAW);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

        }

        public void render()
        {
            mat.applyMaterial();

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, VertBuf[0]);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, NormBuf[0]);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, IntPtr.Zero);
           
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, VertexCount);

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
        }
    }
}

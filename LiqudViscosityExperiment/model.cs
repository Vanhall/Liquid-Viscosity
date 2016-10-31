using System;
using System.Collections.Generic;
using System.IO;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidViscosity
{
    class model
    {
        private int[] VertBuf = new int[1];
        private int[] NormBuf = new int[1];
        private int VertexCount = 0;

        private float[] matAmb = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        private float[] matDif = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
        private float[] matSpec = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        private float[] matShine = new float[] { 80.0f, 80.0f, 80.0f, 1.0f };
        private float[] matEmis = new float[] { 0.1f, 0.1f, 0.1f, 1.0f };

        public void setMatAttrib(string attrib, float R, float G, float B, float A )
        {
            float[] AttribVector = new float[] { R, G, B, A };
            switch(attrib)
            {
                case "ambient":
                    {
                        matAmb = AttribVector;
                    } break;
                case "diffuse":
                    {
                        matDif = AttribVector;
                    }
                    break;
                case "specular":
                    {
                        matSpec = AttribVector;
                    }
                    break;
                case "shininess":
                    {
                        AttribVector[0] *= 128; AttribVector[1] *= 128;
                        AttribVector[2] *= 128; AttribVector[3] *= 128;
                        matShine = AttribVector;
                    }
                    break;
                case "emission":
                    {
                        matEmis = AttribVector;
                    }
                    break;
            }
        }

        public float[] getMatAttrib(string attrib)
        {
            float[] RetVector = new float[4];
            switch (attrib)
            {
                case "ambient":
                    RetVector = matAmb;
                    break;
                case "diffuse":
                    RetVector = matDif;
                    break;
                case "specular":
                    RetVector = matSpec;
                    break;
                case "shininess":
                    matShine.CopyTo(RetVector, 0);
                    for (int i = 0; i < 4; i++) RetVector[i] /= 128;
                    break;
                case "emission":
                    RetVector = matEmis;
                    break;
            }
            return RetVector;
        }

        public model(string Fname)
        {
            #region Obj parser
            List<float> VertexCoords = new List<float>();
            List<float> NormalCoords = new List<float>();
            List<int> VIndexes = new List<int>();
            List<int> NIndexes = new List<int>();

            string[] ObjContent = File.ReadAllLines(Fname);
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
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, matAmb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, matDif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, matSpec);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, matShine);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, matEmis);

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

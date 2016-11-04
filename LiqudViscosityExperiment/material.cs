using System.IO;
using Tao.OpenGl;

namespace LiquidViscosity
{
    class material
    {
        private string matPath = "";
        private string matName = "";

        private float[] Ambient = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
        private float[] Diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
        private float[] Specular = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        private float[] Shininess = new float[] { 60.0f, 60.0f, 60.0f, 1.0f };
        private float[] Emission = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };

        public void setAttrib(string attrib, float R, float G, float B, float A)
        {
            float[] AttribVector = new float[] { R, G, B, A };
            switch (attrib)
            {
                case "ambient":
                    {
                        Ambient = AttribVector;
                    }
                    break;
                case "diffuse":
                    {
                        Diffuse = AttribVector;
                    }
                    break;
                case "specular":
                    {
                        Specular = AttribVector;
                    }
                    break;
                case "shininess":
                    {
                        AttribVector[0] *= 128; AttribVector[1] *= 128;
                        AttribVector[2] *= 128; AttribVector[3] *= 128;
                        Shininess = AttribVector;
                    }
                    break;
                case "emission":
                    {
                        Emission = AttribVector;
                    }
                    break;
            }
        }

        public float[] getAttrib(string attrib)
        {
            float[] RetVector = new float[4];
            switch (attrib)
            {
                case "ambient":
                    RetVector = Ambient;
                    break;
                case "diffuse":
                    RetVector = Diffuse;
                    break;
                case "specular":
                    RetVector = Specular;
                    break;
                case "shininess":
                    Shininess.CopyTo(RetVector, 0);
                    for (int i = 0; i < 4; i++) RetVector[i] /= 128;
                    break;
                case "emission":
                    RetVector = Emission;
                    break;
            }
            return RetVector;
        }

        public material(string path, string name)
        {
            matPath = path;
            matName = name;

            if (File.Exists(path + name + ".material"))
            {
                string[] matAttribs = File.ReadAllLines(path + name + ".material");
                for (int i = 0; i < matAttribs.Length && i < 5; i++)
                {
                    string[] matParams = matAttribs[i].Split(' ');
                    float[] RGBA = new float[4];
                    for (int j = 0; j < 4; j++)
                        RGBA[j] = float.Parse(matParams[j + 1]);
                    setAttrib(matParams[0], RGBA[0], RGBA[1], RGBA[2], RGBA[3]);
                }
            }
        }

        public void saveMaterial()
        {
            if (File.Exists(matPath + matName + ".material"))
                File.Delete(matPath + matName + ".material");
            StreamWriter outFile = new StreamWriter(matPath + matName + ".material");
            outFile.WriteLine("ambient " + string.Join(" ", Ambient));
            outFile.WriteLine("diffuse " + string.Join(" ", Diffuse));
            outFile.WriteLine("specular " + string.Join(" ", Specular));
            float[] matShineNorm = new float[4];
            for (int i = 0; i < 4; i++) matShineNorm[i] = Shininess[i] / 128;
            outFile.WriteLine("shininess " + string.Join(" ", matShineNorm));
            outFile.WriteLine("emission " + string.Join(" ", Emission));
            outFile.Close();
        }

        public void applyMaterial()
        {
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Ambient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Diffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Specular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, Shininess);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, Emission);
        }
    }
}

﻿using System.IO;
using Tao.OpenGl;

namespace LiquidViscosity
{
    public class material
    {
        // Путь к файлу материала
        private string matName = "";

        // Свойства компонент (R, G, B, A) -----------------------------------
        // Фоновый свет
        private float[] Ambient = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
        // Рассеянный свет
        private float[] Diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
        // Отраженный свет (блик)
        private float[] Specular = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        // "Блескучесть" (матовая/глянцевая поверхность)
        private float[] Shininess = new float[] { 60.0f, 60.0f, 60.0f, 1.0f };
        // Излучаемый свет
        private float[] Emission = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };

        private float[] Default;
        public void SetDefault()
        {
            setAttrib("ambient", Default[0], Default[1], Default[2], Default[3]);
            setAttrib("diffuse", Default[4], Default[5], Default[6], Default[7]);
            setAttrib("specular", Default[8], Default[9], Default[10], Default[11]);
            setAttrib("shininess", Default[12], Default[13], Default[14], Default[15]);
            setAttrib("emission", Default[16], Default[17], Default[18], Default[19]);
        }

        // Set и Get функции для компонент -----------------------------------
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

        // Конструктор -------------------------------------------------------
        public material(string name, float[] new_default)
        {
            matName = name;
            Default = new_default;

            // Читаем данные из файла и задаем компоненты
            if (File.Exists(name + ".material"))
            {
                string[] matAttribs = File.ReadAllLines(name + ".material");
                for (int i = 0; i < matAttribs.Length && i < 5; i++)
                {
                    string[] matParams = matAttribs[i].Split(' ');
                    float[] RGBA = new float[4];
                    for (int j = 0; j < 4; j++)
                        RGBA[j] = float.Parse(matParams[j + 1]);
                    setAttrib(matParams[0], RGBA[0], RGBA[1], RGBA[2], RGBA[3]);
                }
            }
            else
            {
                SetDefault();
            }
        }

        // Функция сохранения в файл -----------------------------------------
        public void saveMaterial()
        {
            if (File.Exists(matName + ".material"))
                File.Delete(matName + ".material");
            StreamWriter outFile = new StreamWriter(matName + ".material");
            outFile.WriteLine("ambient " + string.Join(" ", Ambient));
            outFile.WriteLine("diffuse " + string.Join(" ", Diffuse));
            outFile.WriteLine("specular " + string.Join(" ", Specular));
            float[] matShineNorm = new float[4];
            for (int i = 0; i < 4; i++) matShineNorm[i] = Shininess[i] / 128;
            outFile.WriteLine("shininess " + string.Join(" ", matShineNorm));
            outFile.WriteLine("emission " + string.Join(" ", Emission));
            outFile.Close();
        }

        // Применение свойств материала --------------------------------------
        public void applyMaterial()
        {
            // Вызываем соответствующую команду OpenGL для каждого компонента
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Ambient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Diffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Specular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, Shininess);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, Emission);
        }
    }
}

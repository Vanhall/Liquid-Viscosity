using System;
using System.Collections.Generic;
using System.IO;
using Tao.OpenGl;

namespace LiquidViscosity
{
    public class model
    {
        // Путь к файлу модели
        private string modelPath = "";
        private string modelName = "";

        // Указатели на буферы вершин и нормалей
        private int[] VertBuf = new int[1];
        private int[] NormBuf = new int[1];
        private int VertexCount = 0;    // счетчик вершин

        // Материал модели
        public material mat;
        public void setMaterial(material new_mat)
        {
            mat = new_mat;
        }

        // Конструктор
        public model(string path, string name)
        {
            modelName = name;
            modelPath = path;
            
            #region парсер файлов .obj
            // Списки для записи информации из файла
            List<float> VertexCoords = new List<float>();
            List<float> NormalCoords = new List<float>();
            List<int> VIndexes = new List<int>();
            List<int> NIndexes = new List<int>();

            // Читаем файл
            string[] ObjContent = File.ReadAllLines(path + name + ".obj");

            // "Просеиваем" информацию из полученных строк и
            // разносим всё по соответсвующим спискам 
            for (int i = 0; i < ObjContent.Length; i++)
            {
                string[] line = ObjContent[i].Split(' ', '/');

                if (line[0] == "v")      // Вершины
                    for (int j = 1; j < 4; j++)
                        VertexCoords.Add(float.Parse(line[j],
                            System.Globalization.CultureInfo.InvariantCulture));

                if (line[0] == "vn")    // Нормали
                    for (int j = 1; j < 4; j++)
                        NormalCoords.Add(float.Parse(line[j],
                            System.Globalization.CultureInfo.InvariantCulture));

                if (line[0] == "f")     // Поверхности
                    for (int j = 1; j < 9; j += 3)
                    {
                        VIndexes.Add(int.Parse(line[j]));
                        NIndexes.Add(int.Parse(line[j + 2]));
                    }
            }

            VertexCount = VIndexes.Count;
            // Выделяем массивы для вершин и нормалей
            float[] VertArray = new float[VIndexes.Count * 3];
            float[] NormArray = new float[VIndexes.Count * 3];

            // Заполняем массивы
            for (int i = 0; i < VIndexes.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    VertArray[i * 3 + j] = VertexCoords[(VIndexes[i] - 1) * 3 + j];
                    NormArray[i * 3 + j] = NormalCoords[(NIndexes[i] - 1) * 3 + j];
                }
            }
            #endregion

            // Создаем VBO (Vertex Buffer Object)-------------------------------------
            // Создание буфера по указателю VertBuf
            Gl.glGenBuffers(1, VertBuf);
            // Сообщаем OpenGL что хотим связать VertBuf с массивом
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, VertBuf[0]);
            // Привязываем массив вершин к указателю VertBuf
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(VertArray.Length * sizeof(float)), VertArray, Gl.GL_STATIC_DRAW);
            // Освобождаем привязку буфера
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

            // То же что выше, но для нормалей
            Gl.glGenBuffers(1, NormBuf);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, NormBuf[0]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(NormArray.Length * sizeof(float)), NormArray, Gl.GL_STATIC_DRAW);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

        }

        // Функция отрисовки модели
        public void render()
        {
            // Применяем свойства заданного материала
            mat.applyMaterial();

            // Подключаем ранее созданный буфер вершин
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, VertBuf[0]);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            // Подключаем ранее созданный буфер нормалей
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, NormBuf[0]);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, IntPtr.Zero);
           
            // Рисуем модель
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, VertexCount);

            // Отключаем режим отрисовки VBO
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
        }
    }
}

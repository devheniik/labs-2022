using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMGraphs1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Apex> apexes = new List<Apex>();
            List<Link> links = new List<Link>();
            uint num = 0;
            bool tf = false;
            bool oriented = false;

            //Вводим кол-во вершин
            while (!tf)
            {
                Console.WriteLine("enter the Apex number:");
                tf = uint.TryParse(Console.ReadLine(), out num);
                if (num == 0) tf = false; // 0 - empty 
            }

            //Добавляем вершины в массив
            for (int i = 1; i <= num; i++)
                apexes.Add(new Apex(i));

            //Узнаем, ореинтированный ли график
            while (true)
            {
                Console.WriteLine("Ориентированный? 1 - да, 0 - нет");
                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    oriented = true;
                    break;
                }
                if (answer == "0")
                {
                    oriented = false;
                    break;
                }
            }

            int graphIndex = 1;
            //Вводим ребра
            while (true)
            {
                Console.WriteLine($"Введите  для ребра {graphIndex} выходную (а) и входную (б) вершины (вершина - номер графа) через пробел в формате: 'а б' ");
                Console.WriteLine("Введите 0, чтобы закончить вводить ребра");
                string s = Console.ReadLine();
                if (s == "0")
                {
                    break;
                }

                Link link = new Link(graphIndex);
                //проверяем существуют ли заданные вершины
                try
                {
                    string[] ss = s.Split(' ');
                    bool exists1 = false;
                    bool exists2 = false;

                    foreach (Apex apex in apexes)
                    {
                        if (apex.index.ToString() == ss[0])
                        {
                            exists1 = true;
                            //apex.outside ++;
                            link.from = apex;
                        }
                        if (apex.index.ToString() == ss[1])
                        {
                            exists2 = true;
                            //apex.inside ++;
                            link.to = apex;
                        }
                    }
                    if (!exists1 || !exists2) { Console.WriteLine("Таких вершин нету"); continue; }
                }
                catch { Console.WriteLine("Таких вершин нету"); continue; }

                links.Add(link);
                graphIndex++;
            }

            Console.ReadLine();

            Console.WriteLine("\n///////// МАТРИЦЯ ІНЦИДЕНТНОСТІ //////////\n");

            int[,] arrayincidence = new int[apexes.Count, links.Count];
            for (int i = 0; i < apexes.Count; i++)
            {
                for (int j = 0; j < links.Count; j++)
                {
                    arrayincidence[i, j] = 0;
                }
            }

            foreach (Link l in links)
            {
                if (l.from.index == l.to.index)
                {
                    arrayincidence[l.from.index - 1, l.index - 1] = 2;
                    continue;
                }

                if (oriented)
                    arrayincidence[l.from.index - 1, l.index - 1] = -1;
                else
                    arrayincidence[l.from.index - 1, l.index - 1] = 1;

                arrayincidence[l.to.index - 1, l.index - 1] = 1;
            }

            int[] tablei = { 0, 0 };
            for (int i = -1; i < apexes.Count; i++)
            {
                Console.Write(tablei[0] + "\t");
                tablei[0]++;
                for (int j = 0; j < links.Count; j++)
                {
                    if (i == -1)
                    {
                        tablei[1]++;
                        Console.Write(tablei[1] + "\t");
                    }
                    else
                    {
                        Console.Write(arrayincidence[i, j] + "\t");
                    }
                }
                Console.WriteLine("\n");
            }

            Console.ReadLine();
            Console.WriteLine("\n//////////////////////////// МАТРИЦА СУМИЖНОСТИ ///////////////////////////////////////////////////////\n");

            int[,] arraysummij = new int[apexes.Count, apexes.Count];
            for (int i = 0; i < apexes.Count; i++)
            {
                //цикл прогоняет все грани (столбец)
                for (int j = 0; j < apexes.Count; j++)
                {
                    arraysummij[i, j] = 0;
                }
            }
            foreach (Link l in links)
            {
                arraysummij[l.from.index - 1, l.to.index - 1] = 1;
                if (!oriented)
                    arraysummij[l.to.index - 1, l.from.index - 1] = 1;

            }

            int[] table = { 0, 0 };
            for (int i = -1; i < apexes.Count; i++)
            {
                Console.Write(table[0] + "\t");
                table[0]++;
                for (int j = 0; j < apexes.Count; j++)
                {
                    if (i == -1)
                    {
                        table[1]++;
                        Console.Write(table[1] + "\t");
                    }
                    else
                    {
                        Console.Write(arraysummij[i, j] + "\t");
                    }
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n////////////////////////////////////////////////////////////////////////////////////////////////////////\n");

            if (oriented)
            {
                foreach (Link link in links)
                {
                    link.from.outside++;
                    link.to.inside++;
                }
            }
            else
            {
                List<Link> realLink = links.ToList();
                foreach (Link linkToCheck in links)
                {
                    foreach (Link link in links)
                    {
                        if (link.from == linkToCheck.to && link.to == linkToCheck.from && realLink.Contains(link) && realLink.Contains(linkToCheck))
                            realLink.Remove(link);
                    }
                }

                foreach (Link link in realLink)
                {
                    link.from.outside++;
                    link.to.inside++;
                }
            }

            foreach (Apex apex in apexes)
            {
                if (oriented)
                    Console.WriteLine($"Вершина {apex.index} - вход: {apex.inside}, выход: {apex.outside}, степень: {apex.inside + apex.outside}");
                else
                    Console.WriteLine($"Вершина {apex.index} - степень: {apex.inside + apex.outside}");

                if (apex.inside + apex.outside == 0)
                    Console.WriteLine($"Вершина {apex.index} ізольована");
                else if (apex.inside + apex.outside == 1)
                    Console.WriteLine($"Вершина {apex.index} висяча");
                Console.WriteLine("---------------------------");
            }
        }
    }

    class Apex
    {
        public int index;
        public int inside;
        public int outside;
        public Apex(int index)
        {
            this.index = index;
        }
    }

    class Link
    {
        public int index;
        public Apex from;
        public Apex to;
        public Link(int index)
        {
            this.index = index;
        }
    }
}

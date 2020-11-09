using System;

namespace SourceNamespace
{

    public class MainClass
    {
        static BinaryTree isTree;

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/UserGenerateTree/*'/>
        static void UserGenerateTree(int isQuantityNode)
        {
            Console.Write("\n\n");
            int isNewNodeTree = 0;
            for (int i = 0; i < isQuantityNode; i++)
            {
                Console.Write("Введите значение узла № {0}, [100..999]: ", i + 1);
                isNewNodeTree = Convert.ToInt32(Console.ReadLine());
                isTree.InsertNode(isNewNodeTree);
            }
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/AutoGenerateTree/*'/>
        static void AutoGenerateTree(int isQuantityNode)
        {
            int isNewNodeTree = 0;
            Random rnd = new Random();
            for (int i = 0; i < isQuantityNode; i++)
            {
                isNewNodeTree = rnd.Next(100, 999);
                isTree.InsertNode(isNewNodeTree);
            }
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/GenerateChoice/*'/>
        static void GenerateChoice(int isQuantityNode)
        {
            int Choice = 0;
            Console.Write("\n\nХотите инициализировать узлы случайно или самостоятельно?\n\n1) Случайно" +
                 "\n2) Самостоятельно\n\nВаш выбор: ");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    AutoGenerateTree(isQuantityNode);
                    break;
                case 2:
                    UserGenerateTree(isQuantityNode);
                    break;
                default: throw new Exception();
            };
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/UserAddQuantityNode/*'/>
        static void UserAddQuantityNode()
        {
            int isQuantityNode = 0;
            Console.Write("\n\nВведите количество узлов (до 103, включительно): ");
            isQuantityNode = Convert.ToInt32(Console.ReadLine());
            GenerateChoice(isQuantityNode);
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/AutoAddQuantityNode/*'/>
        static void AutoAddQuantityNode()
        {
            int isQuantityNode = 0;
            Random rnd = new Random();
            isQuantityNode = rnd.Next(10, 50);
            Console.Write("\n\nПсевдослучайное количество узлов равно: {0:d}.\n", isQuantityNode);
            GenerateChoice(isQuantityNode);
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/QuantityChoice/*'/>
        static void QuantityChoice(int isChoice)
        {
            switch (isChoice)
            {
                case 1:
                    AutoAddQuantityNode();
                    break;
                case 2:
                    UserAddQuantityNode();
                    break;
                default: throw new Exception();
            };
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="Program.cs"]/Main/*'/>
        static void Main()
        {
            try
            {
                isTree = new BinaryTree();
                Console.Write("Реализация программы без рекурсии.\n\nХотите задать количество узлов случайно или самостоятельно?\n\n1) " +
                     "Случайно\n2) Самостоятельно" +
                     "\n\nВаш выбор: ");
                int Choice = Convert.ToInt32(Console.ReadLine());
                QuantityChoice(Choice);
                string isPathFile = "C:\\TextFile.txt";
                isTree.PrintTextFile(isPathFile);
                Console.Write("\n\nБинарное дерево успешно сохранено в файл по следующему пути: {0}", $"{isPathFile}");
            }
            catch (Exception)
            {
                Console.Write("\n\nОшибка ввода данных. Программа завершает свою работу.");
            }
            finally
            {
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
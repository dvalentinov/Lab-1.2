using System;
using System.IO;

namespace SourceNamespace
{

    /// <include file='Tutorial.xml' path='Tutorial/members[@name="BinaryTree.cs"]/BinaryTree/*'/>
    public class BinaryTree
    {
        const int isMaxQuantityNode = 10000;
        int isCurSize = 0;
        int isMaxLevel = 0;
        int isMaxCountDigit = 3;
        int[] TreeArray = new int[isMaxQuantityNode];
        bool[] TreeInitArray = new bool[isMaxQuantityNode];
        static StreamWriter isTextFile;

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="BinaryTree.cs"]/PrintSpaces/*'/>
        public void PrintSpaces(int isQuantitySpace, StreamWriter TextFile)
        {
            for (int i = 0; i < isQuantitySpace; i++)
                TextFile.Write(' ');
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="BinaryTree.cs"]/PrintTextFile/*'/>
        public void PrintTextFile(string isPathFile)
        {
            int i = 0;
            isTextFile = new StreamWriter($"{isPathFile}");
            for (int Level = 0; Level <= isMaxLevel; Level++)
            {
                int isCountNodeInLevel = (int)Math.Pow(2, Level);
                int iLim = i + isCountNodeInLevel;
                int isCountFirstSpace = ((int)Math.Pow(2, isMaxLevel - Level) - 1) * isMaxCountDigit;
                int isCountSpace = ((int)Math.Pow(2, isMaxLevel - Level + 1) - 1) * isMaxCountDigit;
                PrintSpaces(isCountFirstSpace, isTextFile);
                for (; i < iLim; i++)
                {
                    if (TreeInitArray[i])
                        isTextFile.Write(TreeArray[i]);
                    else
                        PrintSpaces(isMaxCountDigit, isTextFile);
                    PrintSpaces(isCountSpace, isTextFile);
                }
                isTextFile.Write("\n\n");
            }
            isTextFile.Close();
        }

        /// <include file='Tutorial.xml' path='Tutorial/members[@name="BinaryTree.cs"]/InsertNode/*'/>
        public void InsertNode(int isNewNodeTree)
        {
            if (isCurSize == 0)
            {
                TreeArray[0] = isNewNodeTree;
                TreeInitArray[0] = true;
                isCurSize = 1;
                return;
            }
            int isCurLevel = 0, i = 0;
            while (TreeInitArray[i] != false)
            {
                if (isNewNodeTree <= TreeArray[i])
                    i = 2 * i + 1;
                else
                    i = 2 * i + 2;
                if (i >= isMaxQuantityNode)
                {
                    Console.WriteLine("Ошибка. Индекс нового элемента превысил размер дерева.");
                    return;
                }
                isCurLevel++;
            }
            TreeArray[i] = isNewNodeTree;
            TreeInitArray[i] = true;
            isCurSize = Math.Max(i, isCurSize);
            isMaxLevel = Math.Max(isMaxLevel, isCurLevel);
        }
    }
}
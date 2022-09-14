using Lab02LuisG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02LuisG
{

    public partial class Form1 : Form
    {


        List<HuffmanNode> nodeList; // store nodes on List.
        ProcessMethods pMethods = new ProcessMethods();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Console.Clear();
                nodeList = pMethods.getListFromFile();
                Console.Clear();
                if (nodeList == null)
                {
                    //setColor();
                    Console.WriteLine("File cannot be read!");
                    Console.WriteLine("Pressthe any key to continue or Enter \"E\" to exit the program.");
                    //setColorDefault();
                    string choise = Console.ReadLine();
                    if (choise.ToLower() == "e")
                        break;
                    else
                        continue;
                }
                else
                {
                    Console.Clear();
                    //setColor();
                    Console.WriteLine("Frecuencia");
                    //setColorDefault();
                    pMethods.PrintInformation(nodeList);
                    pMethods.getTreeFromList(nodeList);
                    pMethods.setCodeToTheTree("", nodeList[0]);
                    Console.WriteLine("\n\n");
                    //setColor();
                    //setColorDefault();
                    //pMethods.PrintTree(0, nodeList[0]);
                    //setColor();
                    Console.WriteLine("\n\n#Symbols    -    #Codes\n");
                    //setColorDefault();


                    pMethods.PrintfLeafAndCodes(nodeList[0]);
                    Console.WriteLine("\n\n");
                    //setColor();
                    Console.WriteLine("Press the any key to contunie");
                    Console.WriteLine("Enter the\"E\" to exit the program.");
                    //setColorDefault();
                    string choise = Console.ReadLine();
                    if (choise.ToLower() == "e")
                        break;
                    else
                        continue;

                }
            }
        }
    }
}

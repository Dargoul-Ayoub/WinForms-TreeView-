using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._8.TreeView___Médiathèque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageList image = new ImageList();
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\folder.png")) ;
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\right-arrow.png"));
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\book.png"));
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\cd.png"));
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\dvd.png"));
            image.Images.Add(Image.FromFile(@"C:\Users\Devman\Downloads\youtube.png"));

            treeView1.ImageList = image;

            TreeNode livre1 = new TreeNode("Antigone", 2, 2);
            TreeNode livre2 = new TreeNode("Code da vinci", 2, 2);
            TreeNode livre3 = new TreeNode("You", 2, 2);
            TreeNode[] Collection_Livre = new TreeNode[] {livre1,livre2,livre3 };
            TreeNode treeNode = new TreeNode("Book",0,1,Collection_Livre);
            treeView1.Nodes.Add(treeNode);
            //
            // Another node following the first node.
            //
            
            treeNode = new TreeNode("CD",0,1);
            treeView1.Nodes.Add(treeNode);

            treeNode = new TreeNode("DVD", 0, 1);
            treeView1.Nodes.Add(treeNode);

            TreeNode video1 = new TreeNode("C# Tutorial",5,5);
            TreeNode video2 = new TreeNode("WPF Tutorial",5,5);
            TreeNode[] array = new TreeNode[] { video1, video2 };
            treeNode = new TreeNode("Video",0,1, array);
            treeView1.Nodes.Add(treeNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           toolStripStatusLabel1.Text = treeView1.SelectedNode.Text;
           toolStripStatusLabel2.Text = treeView1.SelectedNode.Nodes.Count.ToString()+" Element(s)";
            if (treeView1.SelectedNode.Parent != null)
            {
                toolStripStatusLabel2.Text = treeView1.SelectedNode.Text;
                toolStripStatusLabel1.Text = treeView1.SelectedNode.Parent.Text;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            if (treeView1.SelectedNode.Text == "Book" || treeView1.SelectedNode.Text == "CD" || treeView1.SelectedNode.Text == "DVD" || treeView1.SelectedNode.Text == "Video")
            {
                FormAjouterNode ajouterNode = new FormAjouterNode();
                ajouterNode.ShowDialog();
                if (FormAjouterNode.Name_node_Ajouté != null)
                {
                    TreeNode nodeAjout;
                    if (treeView1.SelectedNode.Text == "Book")
                    {
                        nodeAjout = new TreeNode(FormAjouterNode.Name_node_Ajouté, 2, 2);
                        treeView1.SelectedNode.Nodes.Add(nodeAjout);
                    }
                    else if (treeView1.SelectedNode.Text == "CD")
                    {
                        nodeAjout = new TreeNode(FormAjouterNode.Name_node_Ajouté, 3, 3);
                        treeView1.SelectedNode.Nodes.Add(nodeAjout);
                    }
                    else if (treeView1.SelectedNode.Text == "DVD")
                    {
                        nodeAjout = new TreeNode(FormAjouterNode.Name_node_Ajouté, 4, 4);
                        treeView1.SelectedNode.Nodes.Add(nodeAjout);
                    }
                    else
                    {
                        nodeAjout = new TreeNode(FormAjouterNode.Name_node_Ajouté, 5, 5);
                        treeView1.SelectedNode.Nodes.Add(nodeAjout);
                    }

                }
            }
            else
                MessageBox.Show("please chose a parent node then click on button ajouter");
            else
                MessageBox.Show("Please select a treenode first then click on button ajouter");
        }

       
    }
}

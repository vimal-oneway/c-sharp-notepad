using System.Drawing.Printing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public SaveFileDialog sfd;//instance of savefiledialog to save files       
        public OpenFileDialog ofd;//instance of openfiledialog to open files       
        public FontDialog fd;
        public String str = "";

        public Form1()
        {
            InitializeComponent();
            sfd = new SaveFileDialog();

            ofd = new OpenFileDialog();
            fd = new FontDialog();

            this.Text = "Untitled-Digital Diary";

            richTextBox1.Focus();

        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            str = "";
            if (str == "")
            {
                DialogResult dr = MessageBox.Show("Do you want to save the file", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr.Equals(DialogResult.Yes))//statement that execute when user click on yes button            
                {

                    SaveFile();//calling user defined function SaveFile function                        }
                }
                else if (dr.Equals(DialogResult.No))//statament that execute when user click on no button of dialog            
                {

                    richTextBox1.Clear();

                    this.Text = "Untitled-Digital Diary";

                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Modified == false)
                Application.Exit();


            if (richTextBox1.Modified == true)
            {

                DialogResult dr = MessageBox.Show("Do you want to save the file before exiting", "unsaved file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (str != sfd.FileName)
                    {
                        SaveFile();
                    }
                    richTextBox1.Modified = false;

                    Application.Exit();
                }
            }

            else
            {

                richTextBox1.Modified = false;

                Application.Exit();

            }

        }

        private void SaveFile()
        {

            //setting title of savefiledialog to Save As   

            sfd.Title = "Save As";
            sfd.Filter = "text files (*.txt)|*.txt|c# files|*.cs|all files(*.*)|*.*"; //applied filter        

            // sfd.DefaultExt = "txt";//applied default extension     

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                str = sfd.FileName;
                this.Text = str;
            }
        }

        private void OpenFile()

        {
            ofd.Title = "Open Document";
            ofd.ShowDialog();
            richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
            str = ofd.FileName;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "text files (*.txt)|*.txt|c# files|*.cs|all files(*.*)|*.*"; //applied filter    

            if ((richTextBox1.Modified == true) || (str != sfd.FileName))
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes to the opened file ", "unsaved file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (str == "")
            {
                SaveFile();
            }
            else
            {
                richTextBox1.SaveFile(str, RichTextBoxStreamType.PlainText);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 100, 20);

        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {

            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;

        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Cut();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Paste();

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectAll();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FontFamily fname = fd.Font.FontFamily;
                float fsize = fd.Font.Size;
                FontStyle fstyle = fd.Font.Style;
                Font font;
                font = new Font(fname, fsize, fstyle);
                richTextBox1.Font = font;
            }
        }

            private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCotSC;

namespace WFACounterSmokedCigarettes
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnt_First_Click(object sender, EventArgs e)
        {
            //
            btn_Current.Visible = true;
            bnt_First.Visible = false;
            btn_Last.Visible = true;
            // Запись события
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.First);
        }
        private void btn_Current_Click(object sender, EventArgs e)
        {
            //Запись события
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Current);
        }
        private void btn_Last_Click(object sender, EventArgs e)
        {
            //
            btn_Current.Visible = false;
            btn_Last.Visible = false;
            bnt_First.Visible = true;
            //Запись события
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Last);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //
            btn_Current.Visible = false;
            btn_Last.Visible = false;
            // 
            //label2.Text = ;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

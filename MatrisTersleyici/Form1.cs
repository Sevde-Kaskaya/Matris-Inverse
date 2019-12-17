using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrisTersleyici
{
    public partial class Form1 : Form
    {
        double[,] matris2;
        int satir, sutun;
        int toplam_islem_sayisi=0, cıkarma_islem_sayisi=0, carpma_islem_sayisi=0, bolme_islem_sayisi=0,tersiyok=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Ters_Matris(ref decimal[,] matrix)
        {
            decimal[,] birim_matris = new decimal[matrix.GetLength(0), matrix.GetLength(1)];

            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if (k == p)
                    {
                        birim_matris[k, p] = 1;
                    }
                    else
                    {
                        birim_matris[k, p] = 0;
                    }
                }

            }
            decimal gecici, gecici_2;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                gecici = matrix[i, i];
                try
                {
                    if (gecici == 0)
                    {
                        MessageBox.Show("Bu matrisin tersi yoktur!!!");
                        tersiyok += 1;
                        break;
                    }
                }
                catch
                {

                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] / gecici;                    
                    birim_matris[i, j] = birim_matris[i, j] / gecici;
                    bolme_islem_sayisi += 2;
                }
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    if (x != i)
                    {
                        gecici_2 = matrix[x, i];
                        for (int y = 0; y < matrix.GetLength(1); y++)
                        {
                            matrix[x, y] = matrix[x, y] - (matrix[i, y] * gecici_2);
                            birim_matris[x, y] = birim_matris[x, y] - (birim_matris[i, y] * gecici_2);
                            carpma_islem_sayisi += 2;
                            cıkarma_islem_sayisi += 2;
                            
                        }
                        
                    }
                    

                }
                
            }                   
            matrix = birim_matris;
            
            
        }

        private void Tronspose_Alma(ref double[,] matrix)
        {
            double[,] transpose = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transpose[j, i] = matrix[i, j];

                }
            }
            matrix = transpose;
        }

        private void Karesel_Matris_Alma(ref double[,] matrix, ref double[,] transpose)
        {

            double[,] Karesel_Matris = new double[matrix.GetLength(0), transpose.GetLength(1)];
            //matrix'in satır sayısı kadar
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //transpozun sütun sayısı kadar
                for (int j = 0; j < transpose.GetLength(1); j++)
                {
                    double toplam = 0;
                    if (matrix.GetLength(1) > 1)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            toplam += matrix[i, k] * transpose[k, j];
                            toplam_islem_sayisi += 1;
                            carpma_islem_sayisi += 1;
                        }
                        Karesel_Matris[i, j] = toplam;
                    }
                    else if (transpose.GetLength(0) > 1)
                    {
                        for (int k = 0; k < transpose.GetLength(0); k++)
                        {
                            toplam += matrix[i, k] * transpose[k, j];
                            toplam_islem_sayisi += 1;
                            carpma_islem_sayisi += 1;
                        }
                        Karesel_Matris[i, j] = toplam;
                    }
                    else if (matrix.GetLength(1) <= 1)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            toplam += matrix[i, k] * transpose[k, j];
                            toplam_islem_sayisi += 1;
                            carpma_islem_sayisi += 1;
                        }
                        Karesel_Matris[i, j] = toplam;
                    }

                }
            }
            matrix = Karesel_Matris;


        }

        private void Button_Temizle_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox31.Clear();
            Satir_textBox.Clear();
            Sutun_textBox.Clear();
        }

        private void Button_Rastgele_Click(object sender, EventArgs e)
        {

            Random rastgele = new Random();
            int rastgele_satir = rastgele.Next(1, 6);
            int rastgele_sutun = rastgele.Next(1, 6);

            double[,] matris = new double[rastgele_satir, rastgele_sutun];

            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            textBox30.Clear();
            textBox31.Clear();
            toplam_islem_sayisi = 0;
            carpma_islem_sayisi = 0;
            cıkarma_islem_sayisi = 0;
            bolme_islem_sayisi = 0;
            tersiyok = 0;

            //Matris Gösterme
            for (int i = 0; i < rastgele_satir; i++)
            {

                TextBox1.Text += "\t";
                for (int j = 0; j < rastgele_sutun; j++)
                {
                    matris[i, j] = rastgele.Next(1, 10);
                    TextBox1.Text += matris[i, j].ToString() + "  ";

                }
                TextBox1.Text += Environment.NewLine;

            }

            //Kare Matris Değilse
            if (rastgele_satir != rastgele_sutun)
            {
                double[,] transpose = (double[,])matris.Clone();

                Tronspose_Alma(ref transpose);
                for (int x = 0; x < transpose.GetLength(0); x++)
                {
                    TextBox2.Text += "  ";
                    for (int y = 0; y < transpose.GetLength(1); y++)
                    {
                        TextBox2.Text += transpose[x, y].ToString() + "  ";
                    }
                    TextBox2.Text += Environment.NewLine;
                }
                Karesel_Matris_Alma(ref matris, ref transpose);

                for (int i = 0; i < matris.GetLength(0); i++)
                {
                    TextBox3.Text += "  ";
                    for (int j = 0; j < matris.GetLength(1); j++)
                    {
                        TextBox3.Text += matris[i, j].ToString() + "     ";
                    }
                    TextBox3.Text += Environment.NewLine;
                }

            }
            //Tür Dönüşümlü Yeni Matris
            decimal[,] decimal_matris = new decimal[matris.GetLength(0), matris.GetLength(1)];
            for (int x = 0; x < matris.GetLength(0); x++)
            {
                for (int y = 0; y < matris.GetLength(1); y++)
                {
                    decimal_matris[x, y] = (decimal)matris[x, y];
                }

            }
            //Ters Matris
            Ters_Matris(ref decimal_matris);
            if (tersiyok == 0)
            {
                for (int i = 0; i < decimal_matris.GetLength(0); i++)
                {
                    TextBox4.Text += "  ";
                    for (int j = 0; j < decimal_matris.GetLength(1); j++)
                    {
                        TextBox4.Text += Decimal.Round(decimal_matris[i, j], 1).ToString() + "\t";
                    }
                    TextBox4.Text += Environment.NewLine;
                }
            }
            else
            {
                TextBox4.Text = "Bu Matrisin Tersi Yok!";
            }
            
            
            textBox30.Text = toplam_islem_sayisi.ToString() + cıkarma_islem_sayisi.ToString();
            textBox31.Text = carpma_islem_sayisi.ToString() + bolme_islem_sayisi.ToString();


        }

        private void Button_Satir_Sutun_Click(object sender, EventArgs e)
        {
            satir = Convert.ToInt32(Satir_textBox.Text);
            sutun = Convert.ToInt32(Sutun_textBox.Text);
            matris2 = new double[satir, sutun];
        }

        private void Satir_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 1 || Convert.ToInt32(Satir_textBox.Text) > 5)
                {
                    MessageBox.Show("Değer 1-5 arasında olmalı");
                    Satir_textBox.Text = "";
                    Satir_textBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                Satir_textBox.Text = "";
                Satir_textBox.Focus();
            }
        }
        private void Sutun_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 1 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    MessageBox.Show("Değer 1-5 arasında olmalı");
                    Sutun_textBox.Text = "";
                    Sutun_textBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                Sutun_textBox.Text = "";
                Sutun_textBox.Focus();
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void Button_Elle_Giris_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            textBox30.Clear();
            textBox31.Clear();
            toplam_islem_sayisi = 0;
            carpma_islem_sayisi = 0;
            cıkarma_islem_sayisi = 0;
            bolme_islem_sayisi = 0;
            tersiyok = 0;

            //Matris Gösterme
            for (int i = 0; i < satir; i++)
            {

                TextBox1.Text += "\t";
                for (int j = 0; j < sutun; j++)
                {
                    TextBox1.Text += matris2[i, j].ToString() + "  ";

                }
                TextBox1.Text += Environment.NewLine;

            }

            //Kare Matris Değilse
            if (satir != sutun)
            {
                double[,] transpose = (double[,])matris2.Clone();

                Tronspose_Alma(ref transpose);
                for (int x = 0; x < transpose.GetLength(0); x++)
                {
                    TextBox2.Text += "  ";
                    for (int y = 0; y < transpose.GetLength(1); y++)
                    {
                        TextBox2.Text += transpose[x, y].ToString() + "  ";
                    }
                    TextBox2.Text += Environment.NewLine;
                }
                Karesel_Matris_Alma(ref matris2, ref transpose);

                for (int i = 0; i < matris2.GetLength(0); i++)
                {
                    TextBox3.Text += "  ";
                    for (int j = 0; j < matris2.GetLength(1); j++)
                    {
                        TextBox3.Text += matris2[i, j].ToString() + "     ";
                    }
                    TextBox3.Text += Environment.NewLine;
                }

            }
            //Tür Dönüşümlü Yeni Matris
            decimal[,] decimal_matris = new decimal[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    decimal_matris[x, y] = (decimal)matris2[x, y];
                }

            }

            //Ters Matris
            Ters_Matris(ref decimal_matris);
            if (tersiyok == 0)
            {
                for (int i = 0; i < decimal_matris.GetLength(0); i++)
                {
                    TextBox4.Text += "  ";
                    for (int j = 0; j < decimal_matris.GetLength(1); j++)
                    {
                        TextBox4.Text += Decimal.Round(decimal_matris[i, j], 1).ToString() + "\t";
                    }
                    TextBox4.Text += Environment.NewLine;
                }
            }
            else
            {
                TextBox4.Text = "Bu Matrisin Tersi Yok!";
            }
            textBox30.Text = toplam_islem_sayisi.ToString() + cıkarma_islem_sayisi.ToString();
            textBox31.Text = carpma_islem_sayisi.ToString() + bolme_islem_sayisi.ToString();
        }

        private void Button_Sayi_Girisi_Click(object sender, EventArgs e)
        {
            int[,] sanal_matris = new int[satir, sutun];
            if (satir==1 && sutun ==1)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
            }
            else if (satir == 1 && sutun == 2)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
            }
            else if (satir == 1 && sutun == 3)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
            }
            else if (satir == 1 && sutun == 4)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
            }
            else if (satir == 1 && sutun == 5)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[0, 4] = Convert.ToInt32(textBox9.Text);
            }
            else if (satir == 2 && sutun == 1)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
            }
            else if (satir == 2 && sutun == 2)
            {                
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
            }
            else if (satir == 2 && sutun == 3)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                
            }
            else if (satir == 2 && sutun == 4)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);                
            }
            else if (satir == 2 && sutun == 5)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[0, 4] = Convert.ToInt32(textBox9.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[1, 4] = Convert.ToInt32(textBox14.Text);
            }
            else if (satir == 3 && sutun == 1)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
            }
            else if (satir == 3 && sutun == 2)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                
            }
            else if (satir == 3 && sutun == 3)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                
            }
            else if (satir == 3 && sutun == 4)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                
            }
            else if (satir == 3 && sutun == 5)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[0, 4] = Convert.ToInt32(textBox9.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[1, 4] = Convert.ToInt32(textBox14.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                sanal_matris[2, 4] = Convert.ToInt32(textBox19.Text);
            }
            else if (satir == 4 && sutun == 1)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
            }
            else if (satir == 4 && sutun == 2)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
            }
            else if (satir == 4 && sutun == 3)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);

            }
            else if (satir == 4 && sutun == 4)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);
                sanal_matris[3, 3] = Convert.ToInt32(textBox23.Text);

            }
            else if (satir == 4 && sutun == 5)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[0, 4] = Convert.ToInt32(textBox9.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[1, 4] = Convert.ToInt32(textBox14.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                sanal_matris[2, 4] = Convert.ToInt32(textBox19.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);
                sanal_matris[3, 3] = Convert.ToInt32(textBox23.Text);
                sanal_matris[3, 4] = Convert.ToInt32(textBox24.Text);
            }
            else if (satir == 5 && sutun == 1)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[4, 0] = Convert.ToInt32(textBox25.Text);
            }
            else if (satir == 5 && sutun == 2)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[4, 0] = Convert.ToInt32(textBox25.Text);
                sanal_matris[4, 1] = Convert.ToInt32(textBox26.Text);
            }
            else if (satir == 5 && sutun == 3)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);
                sanal_matris[4, 0] = Convert.ToInt32(textBox25.Text);
                sanal_matris[4, 1] = Convert.ToInt32(textBox26.Text);
                sanal_matris[4, 2] = Convert.ToInt32(textBox27.Text);

            }
            else if (satir == 5 && sutun == 4)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);
                sanal_matris[3, 3] = Convert.ToInt32(textBox23.Text);
                sanal_matris[4, 0] = Convert.ToInt32(textBox25.Text);
                sanal_matris[4, 1] = Convert.ToInt32(textBox26.Text);
                sanal_matris[4, 2] = Convert.ToInt32(textBox27.Text);
                sanal_matris[4, 3] = Convert.ToInt32(textBox28.Text);
            }
            else if (satir == 5 && sutun == 5)
            {
                sanal_matris[0, 0] = Convert.ToInt32(textBox5.Text);
                sanal_matris[0, 1] = Convert.ToInt32(textBox6.Text);
                sanal_matris[0, 2] = Convert.ToInt32(textBox7.Text);
                sanal_matris[0, 3] = Convert.ToInt32(textBox8.Text);
                sanal_matris[0, 4] = Convert.ToInt32(textBox9.Text);
                sanal_matris[1, 0] = Convert.ToInt32(textBox10.Text);
                sanal_matris[1, 1] = Convert.ToInt32(textBox11.Text);
                sanal_matris[1, 2] = Convert.ToInt32(textBox12.Text);
                sanal_matris[1, 3] = Convert.ToInt32(textBox13.Text);
                sanal_matris[1, 4] = Convert.ToInt32(textBox14.Text);
                sanal_matris[2, 0] = Convert.ToInt32(textBox15.Text);
                sanal_matris[2, 1] = Convert.ToInt32(textBox16.Text);
                sanal_matris[2, 2] = Convert.ToInt32(textBox17.Text);
                sanal_matris[2, 3] = Convert.ToInt32(textBox18.Text);
                sanal_matris[2, 4] = Convert.ToInt32(textBox19.Text);
                sanal_matris[3, 0] = Convert.ToInt32(textBox20.Text);
                sanal_matris[3, 1] = Convert.ToInt32(textBox21.Text);
                sanal_matris[3, 2] = Convert.ToInt32(textBox22.Text);
                sanal_matris[3, 3] = Convert.ToInt32(textBox23.Text);
                sanal_matris[3, 4] = Convert.ToInt32(textBox24.Text);
                sanal_matris[4, 0] = Convert.ToInt32(textBox25.Text);
                sanal_matris[4, 1] = Convert.ToInt32(textBox26.Text);
                sanal_matris[4, 2] = Convert.ToInt32(textBox27.Text);
                sanal_matris[4, 3] = Convert.ToInt32(textBox28.Text);
                sanal_matris[4, 4] = Convert.ToInt32(textBox29.Text);
            }

            for (int i = 0; i < matris2.GetLength(0); i++)
            {
                for (int j = 0; j < matris2.GetLength(1); j++)
                {
                    matris2[i, j] = sanal_matris[i, j];
                    //Debug.WriteLine(sanal_matris[i, j]);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 1 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox6.Text = "";
                    textBox6.Focus();

                }
            }
            catch
            {

            }
            
            try
            {
                if (Convert.ToInt32(textBox5.Text) < 0 || Convert.ToInt32(textBox5.Text) > 10)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox5.Text = "";
                    textBox5.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox5.Text = "";
                textBox5.Focus();
            }

        }

        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 2 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox6.Text = "";
                    textBox6.Focus();
                }

            }
            catch
            {
                
            }
            try
            {
                if (Convert.ToInt32(textBox6.Text) < 0 || Convert.ToInt32(textBox6.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox6.Text = "";
                    textBox6.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox6.Text = "";
                textBox6.Focus();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 3 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox7.Text = "";
                    textBox7.Focus();

                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox7.Text) < 0 || Convert.ToInt32(textBox7.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox7.Text = "";
                    textBox7.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox7.Text = "";
                textBox7.Focus();
            }
            
        }
    

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 4 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox8.Text = "";
                    textBox8.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox8.Text) < 0 || Convert.ToInt32(textBox8.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox8.Text = "";
                    textBox8.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox8.Text = "";
                textBox8.Focus();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Sutun_textBox.Text) < 5 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox9.Text = "";
                    textBox9.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox9.Text) < 0 || Convert.ToInt32(textBox9.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox9.Text = "";
                    textBox9.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox9.Text = "";
                textBox9.Focus();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text)<2 || Convert.ToInt32(Satir_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox10.Text = "";
                    textBox10.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox10.Text) < 0 || Convert.ToInt32(textBox10.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox10.Text = "";
                    textBox10.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox10.Text = "";
                textBox10.Focus();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 2 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 2 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox11.Text = "";
                    textBox11.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox11.Text = "";
                textBox11.Focus();
            }
            try
            {
                if (Convert.ToInt32(textBox11.Text) < 0 || Convert.ToInt32(textBox11.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox11.Text = "";
                    textBox11.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox11.Text = "";
                textBox11.Focus();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 2 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 3 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox12.Text = "";
                    textBox12.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox12.Text) < 0 || Convert.ToInt32(textBox12.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox12.Text = "";
                    textBox12.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox12.Text = "";
                textBox12.Focus();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 2 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 4 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox13.Text = "";
                    textBox13.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox13.Text) < 0 || Convert.ToInt32(textBox13.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox13.Text = "";
                    textBox13.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox13.Text = "";
                textBox13.Focus();
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 2 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 5 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox14.Text = "";
                    textBox14.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox14.Text) < 0 || Convert.ToInt32(textBox14.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox14.Text = "";
                    textBox14.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox14.Text = "";
                textBox14.Focus();
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 3 || Convert.ToInt32(Satir_textBox.Text) > 5 )
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox15.Text = "";
                    textBox15.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox15.Text) < 0 || Convert.ToInt32(textBox15.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox15.Text = "";
                    textBox15.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox15.Text = "";
                textBox15.Focus();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 3 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 2 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox16.Text = "";
                    textBox16.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox16.Text) < 0 || Convert.ToInt32(textBox16.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox16.Text = "";
                    textBox16.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox16.Text = "";
                textBox16.Focus();
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 3 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 3 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox17.Text = "";
                    textBox17.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox17.Text) < 0 || Convert.ToInt32(textBox17.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox17.Text = "";
                    textBox17.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox17.Text = "";
                textBox17.Focus();
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 3 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 4 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox18.Text = "";
                    textBox18.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox18.Text) < 0 || Convert.ToInt32(textBox18.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox18.Text = "";
                    textBox18.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox18.Text = "";
                textBox18.Focus();
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 3 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 5 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox19.Text = "";
                    textBox19.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox19.Text) < 0 || Convert.ToInt32(textBox19.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox19.Text = "";
                    textBox19.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox19.Text = "";
                textBox19.Focus();
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 4 || Convert.ToInt32(Satir_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox20.Text = "";
                    textBox20.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox20.Text) < 0 || Convert.ToInt32(textBox20.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox20.Text = "";
                    textBox20.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox20.Text = "";
                textBox20.Focus();
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 4  || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 2 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox21.Text = "";
                    textBox21.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox21.Text) < 0 || Convert.ToInt32(textBox21.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox21.Text = "";
                    textBox21.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox21.Text = "";
                textBox21.Focus();
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 4 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 3 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox22.Text = "";
                    textBox22.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox22.Text) < 0 || Convert.ToInt32(textBox22.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox22.Text = "";
                    textBox22.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox22.Text = "";
                textBox22.Focus();
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 4 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 4 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox23.Text = "";
                    textBox23.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox23.Text) < 0 || Convert.ToInt32(textBox23.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox23.Text = "";
                    textBox23.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox23.Text = "";
                textBox23.Focus();
            }
        }

        

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 4 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 5 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox24.Text = "";
                    textBox24.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox24.Text) < 0 || Convert.ToInt32(textBox24.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox24.Text = "";
                    textBox24.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox24.Text = "";
                textBox24.Focus();
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 5 || Convert.ToInt32(Satir_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox25.Text = "";
                    textBox25.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox25.Text) < 0 || Convert.ToInt32(textBox25.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox25.Text = "";
                    textBox25.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox25.Text = "";
                textBox25.Focus();
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 5 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 2 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                   
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox26.Text = "";
                    textBox26.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox26.Text) < 0 || Convert.ToInt32(textBox26.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox26.Text = "";
                    textBox26.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox26.Text = "";
                textBox26.Focus();
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 5 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 3 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox27.Text = "";
                    textBox27.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox27.Text) < 0 || Convert.ToInt32(textBox27.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox27.Text = "";
                    textBox27.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox27.Text = "";
                textBox27.Focus();
            }
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 5 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 4 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox28.Text = "";
                    textBox28.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox28.Text) < 0 || Convert.ToInt32(textBox28.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox28.Text = "";
                    textBox28.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox28.Text = "";
                textBox28.Focus();
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Satir_textBox.Text) < 5 || Convert.ToInt32(Satir_textBox.Text) > 5 || Convert.ToInt32(Sutun_textBox.Text) < 5 || Convert.ToInt32(Sutun_textBox.Text) > 5)
                {
                    
                    MessageBox.Show("Buraya Değer Giremezsiniz");
                    textBox29.Text = "";
                    textBox29.Focus();
                }

            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(textBox29.Text) < 0 || Convert.ToInt32(textBox29.Text) > 9)
                {
                    MessageBox.Show("Değer 1-9 arasında olmalı");
                    textBox29.Text = "";
                    textBox29.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                textBox29.Text = "";
                textBox29.Focus();
            }
        }

    }

        

        
}

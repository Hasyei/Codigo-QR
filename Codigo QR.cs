using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace algo_con_base_de_datos
{
    public partial class Codigo_QR : Form
    {
        string texto, nombre_wifi, contraseña;
        public Codigo_QR()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "WEB";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "WEB")
                {
                    texto = textBox1.Text;
                    Url url = new Url(texto);
                    QRCodeGenerator qRCode = new QRCodeGenerator();
                    QRCodeData qRDatos = qRCode.CreateQrCode(url, QRCodeGenerator.ECCLevel.H);
                    QRCode qRCodigo = new QRCode(qRDatos);
                    Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                    pictureBox1.Image = QRImagen;
                }
                if (comboBox1.Text == "Numero de telefono")
                {
                    texto = textBox1.Text;
                    PhoneNumber phoneNumber = new PhoneNumber(texto);
                    QRCodeGenerator qRCode = new QRCodeGenerator();
                    QRCodeData qRDatos = qRCode.CreateQrCode(phoneNumber, QRCodeGenerator.ECCLevel.H);
                    QRCode qRCodigo = new QRCode(qRDatos);
                    Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                    pictureBox1.Image = QRImagen;
                }
                if (comboBox1.Text == "Mensaje")
                {
                    texto = textBox1.Text;
                    SMS sms = new SMS(texto);
                    QRCodeGenerator qRCode = new QRCodeGenerator();
                    QRCodeData qRDatos = qRCode.CreateQrCode(sms, QRCodeGenerator.ECCLevel.H);
                    QRCode qRCodigo = new QRCode(qRDatos);
                    Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                    pictureBox1.Image = QRImagen;
                }
                if (comboBox1.Text == "Whatsapp")
                {
                    texto = textBox1.Text;
                    WhatsAppMessage whatsApp = new WhatsAppMessage(texto);
                    QRCodeGenerator qRCode = new QRCodeGenerator();
                    QRCodeData qRDatos = qRCode.CreateQrCode(whatsApp, QRCodeGenerator.ECCLevel.H);
                    QRCode qRCodigo = new QRCode(qRDatos);
                    Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                    pictureBox1.Image = QRImagen;
                }
                if (comboBox1.Text == "Contraseña de WIFI")
                {
                    texto = textBox1.Text;
                    nombre_wifi = textBox2.Text;
                    contraseña = textBox3.Text;
                    if (checkBox1.Checked == true)
                    {
                        WiFi wifi = new WiFi(nombre_wifi, contraseña, WiFi.Authentication.nopass);
                        QRCodeGenerator qRCode = new QRCodeGenerator();
                        QRCodeData qRDatos = qRCode.CreateQrCode(wifi, QRCodeGenerator.ECCLevel.H);
                        QRCode qRCodigo = new QRCode(qRDatos);
                        Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                        pictureBox1.Image = QRImagen;
                    }
                    if (checkBox2.Checked == true)
                    {
                        WiFi wifi = new WiFi(nombre_wifi, contraseña, WiFi.Authentication.WPA);
                        QRCodeGenerator qRCode = new QRCodeGenerator();
                        QRCodeData qRDatos = qRCode.CreateQrCode(wifi, QRCodeGenerator.ECCLevel.H);
                        QRCode qRCodigo = new QRCode(qRDatos);
                        Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                        pictureBox1.Image = QRImagen;
                    }
                    if (checkBox3.Checked == true)
                    {
                        WiFi wifi = new WiFi(nombre_wifi, contraseña, WiFi.Authentication.WEP);
                        QRCodeGenerator qRCode = new QRCodeGenerator();
                        QRCodeData qRDatos = qRCode.CreateQrCode(wifi, QRCodeGenerator.ECCLevel.H);
                        QRCode qRCodigo = new QRCode(qRDatos);
                        Bitmap QRImagen = qRCodigo.GetGraphic(10, Color.Black, Color.White, Properties.Resources.logo);
                        pictureBox1.Image = QRImagen;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Contraseña de WIFI")
            {
                textBox1.Visible = false;
                textBox2.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
            }
            if (comboBox1.Text != "Contraseña de WIFI")
            {
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }
        private void Codigo_QR_Load(object sender, EventArgs e) { }
        private void comboBox1_MouseClick(object sender, MouseEventArgs e) { }
    }
    #region Copyright
    /*
    En esta sección debería escribir algo que tenga que ver con el Copyright, pero no se me ocurre absolutamente nada, por lo tanto lo dejaré así.  
    @Hasyei ©
     */
    #endregion
}
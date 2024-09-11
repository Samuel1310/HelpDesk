using MySql.Data.MySqlClient;
using Projetinho;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.txtbox_usuario = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtbox_senha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.labelTitle.Location = new System.Drawing.Point(120, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(334, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Login to DeskMaster";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(40, 100);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(84, 18);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username:";
            // 
            // txtbox_usuario
            // 
            this.txtbox_usuario.Location = new System.Drawing.Point(130, 100);
            this.txtbox_usuario.Name = "txtbox_usuario";
            this.txtbox_usuario.Size = new System.Drawing.Size(250, 20);
            this.txtbox_usuario.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(40, 150);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(82, 18);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // txtbox_senha
            // 
            this.txtbox_senha.Location = new System.Drawing.Point(130, 150);
            this.txtbox_senha.Name = "txtbox_senha";
            this.txtbox_senha.PasswordChar = '*';
            this.txtbox_senha.Size = new System.Drawing.Size(250, 20);
            this.txtbox_senha.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(130, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 30);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Location = new System.Drawing.Point(130, 250);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(114, 13);
            this.linkForgotPassword.TabIndex = 6;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Forgot your password?";
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(130, 280);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.linkForgotPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbox_senha);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtbox_usuario);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string usuario = txtbox_usuario.Text;
                string senha = txtbox_senha.Text;
                ClassUsuario.nome = usuario;

                if (usuario.Length < 4)
                {
                    MessageBox.Show("Login deve ter pelo menos 5 caracteres",
                      "Erro Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtbox_usuario.Focus();

                    return;
                }
                if (senha.Length < 4)
                {
                    MessageBox.Show("A Senha deve ter pelo menos 5 caracteres",
                      "Erro Senha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtbox_senha.Focus();
                    return;
                }





                string sql = "SELECT * FROM usuarios WHERE usuario= @usuario and senha=@senha";

                Chupa respeita = new Chupa();

                ClassConexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, ClassConexao.conn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("senha", senha);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count == 1)
                {

                    string Usuario = dt.Rows[0].ItemArray[1].ToString();
                    MessageBox.Show("Olá " + Usuario + " Seja Bem Vindo!", "ACESSO PERMITIDO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                    respeita.Show();
                    

                }


                else
                {
                    txtbox_senha.Text = "";
                    txtbox_usuario.Text = "";

                    MessageBox.Show("Usuário ou Senha incorretos!", "Erro",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbox_usuario.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lógica para recuperação de senha
            MessageBox.Show("Password recovery process started.");
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox txtbox_usuario;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtbox_senha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Label labelError;
    }
}

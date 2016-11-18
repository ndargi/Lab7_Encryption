namespace Lab7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Encrypt_Button = new System.Windows.Forms.Button();
            this.Decrypt_Button = new System.Windows.Forms.Button();
            this.Get_File_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 93);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(516, 49);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 204);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(316, 43);
            this.textBox2.TabIndex = 3;
            // 
            // Encrypt_Button
            // 
            this.Encrypt_Button.Location = new System.Drawing.Point(62, 311);
            this.Encrypt_Button.Name = "Encrypt_Button";
            this.Encrypt_Button.Size = new System.Drawing.Size(173, 50);
            this.Encrypt_Button.TabIndex = 4;
            this.Encrypt_Button.Text = "Encrypt";
            this.Encrypt_Button.UseVisualStyleBackColor = true;
            // 
            // Decrypt_Button
            // 
            this.Decrypt_Button.Location = new System.Drawing.Point(313, 311);
            this.Decrypt_Button.Name = "Decrypt_Button";
            this.Decrypt_Button.Size = new System.Drawing.Size(169, 50);
            this.Decrypt_Button.TabIndex = 5;
            this.Decrypt_Button.Text = "Decrypt";
            this.Decrypt_Button.UseVisualStyleBackColor = true;
            // 
            // Get_File_Button
            // 
            this.Get_File_Button.Location = new System.Drawing.Point(643, 93);
            this.Get_File_Button.Name = "Get_File_Button";
            this.Get_File_Button.Size = new System.Drawing.Size(61, 59);
            this.Get_File_Button.TabIndex = 6;
            this.Get_File_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 404);
            this.Controls.Add(this.Get_File_Button);
            this.Controls.Add(this.Decrypt_Button);
            this.Controls.Add(this.Encrypt_Button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "File Encrypt/Decrypt - Nicholas Dargi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Encrypt_Button;
        private System.Windows.Forms.Button Decrypt_Button;
        private System.Windows.Forms.Button Get_File_Button;
    }
}


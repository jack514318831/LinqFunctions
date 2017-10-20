namespace LinqFunctions
{
    partial class ClientForm
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
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIPAdrress = new System.Windows.Forms.TextBox();
            this.btnConnet = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(469, 330);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(101, 23);
            this.btnSendMessage.TabIndex = 15;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(59, 330);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(373, 20);
            this.tbMessage.TabIndex = 14;
            this.tbMessage.Text = "Hallo";
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(59, 78);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(485, 227);
            this.tbInfo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(343, 40);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(89, 20);
            this.tbPort.TabIndex = 11;
            this.tbPort.Text = "56661";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP";
            // 
            // tbIPAdrress
            // 
            this.tbIPAdrress.Location = new System.Drawing.Point(79, 40);
            this.tbIPAdrress.Name = "tbIPAdrress";
            this.tbIPAdrress.Size = new System.Drawing.Size(200, 20);
            this.tbIPAdrress.TabIndex = 9;
            this.tbIPAdrress.Text = "192.168.123.49";
            // 
            // btnConnet
            // 
            this.btnConnet.Location = new System.Drawing.Point(469, 40);
            this.btnConnet.Name = "btnConnet";
            this.btnConnet.Size = new System.Drawing.Size(75, 23);
            this.btnConnet.TabIndex = 8;
            this.btnConnet.Text = "Connect";
            this.btnConnet.UseVisualStyleBackColor = true;
            this.btnConnet.Click += new System.EventHandler(this.btnConnet_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(469, 359);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(101, 23);
            this.btnSendFile.TabIndex = 16;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIPAdrress);
            this.Controls.Add(this.btnConnet);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIPAdrress;
        private System.Windows.Forms.Button btnConnet;
        private System.Windows.Forms.Button btnSendFile;
    }
}
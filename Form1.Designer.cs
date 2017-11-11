namespace CoffeeMachine
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
            this.components = new System.ComponentModel.Container();
            this.baglanButton = new System.Windows.Forms.Button();
            this.koparButton = new System.Windows.Forms.Button();
            this.portCombo = new System.Windows.Forms.ComboBox();
            this.baudCombo = new System.Windows.Forms.ComboBox();
            this.durumLabel = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerMAIN = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dersCombo = new System.Windows.Forms.ComboBox();
            this.ogretimGorevlisiCombo = new System.Windows.Forms.ComboBox();
            this.bolumCombo = new System.Windows.Forms.ComboBox();
            this.errorProviderPort = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderRate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderBolum = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderHoca = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDers = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHoca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDers)).BeginInit();
            this.SuspendLayout();
            // 
            // baglanButton
            // 
            this.baglanButton.Location = new System.Drawing.Point(70, 224);
            this.baglanButton.Name = "baglanButton";
            this.baglanButton.Size = new System.Drawing.Size(66, 59);
            this.baglanButton.TabIndex = 0;
            this.baglanButton.Text = "Bağlan";
            this.baglanButton.UseVisualStyleBackColor = true;
            this.baglanButton.Click += new System.EventHandler(this.baglanButton_Click);
            // 
            // koparButton
            // 
            this.koparButton.Enabled = false;
            this.koparButton.Location = new System.Drawing.Point(265, 224);
            this.koparButton.Name = "koparButton";
            this.koparButton.Size = new System.Drawing.Size(66, 59);
            this.koparButton.TabIndex = 1;
            this.koparButton.Text = "Kopar";
            this.koparButton.UseVisualStyleBackColor = true;
            this.koparButton.Click += new System.EventHandler(this.koparButton_Click);
            // 
            // portCombo
            // 
            this.portCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portCombo.FormattingEnabled = true;
            this.portCombo.Location = new System.Drawing.Point(223, 23);
            this.portCombo.Name = "portCombo";
            this.portCombo.Size = new System.Drawing.Size(108, 21);
            this.portCombo.TabIndex = 2;
            // 
            // baudCombo
            // 
            this.baudCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudCombo.FormattingEnabled = true;
            this.baudCombo.Location = new System.Drawing.Point(223, 66);
            this.baudCombo.Name = "baudCombo";
            this.baudCombo.Size = new System.Drawing.Size(108, 21);
            this.baudCombo.TabIndex = 3;
            this.baudCombo.SelectedIndexChanged += new System.EventHandler(this.baudCombo_SelectedIndexChanged);
            // 
            // durumLabel
            // 
            this.durumLabel.AutoSize = true;
            this.durumLabel.Location = new System.Drawing.Point(183, 247);
            this.durumLabel.Name = "durumLabel";
            this.durumLabel.Size = new System.Drawing.Size(36, 13);
            this.durumLabel.TabIndex = 4;
            this.durumLabel.Text = "Kapalı";
            // 
            // timerMAIN
            // 
            this.timerMAIN.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Portlar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bağlantı Hızı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bölüm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Öğretim Görevlisi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ders";
            // 
            // dersCombo
            // 
            this.dersCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dersCombo.Location = new System.Drawing.Point(223, 183);
            this.dersCombo.Name = "dersCombo";
            this.dersCombo.Size = new System.Drawing.Size(108, 21);
            this.dersCombo.TabIndex = 2;
            this.dersCombo.SelectedIndexChanged += new System.EventHandler(this.dersCombo_SelectedIndexChanged);
            // 
            // ogretimGorevlisiCombo
            // 
            this.ogretimGorevlisiCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ogretimGorevlisiCombo.Location = new System.Drawing.Point(223, 142);
            this.ogretimGorevlisiCombo.Name = "ogretimGorevlisiCombo";
            this.ogretimGorevlisiCombo.Size = new System.Drawing.Size(108, 21);
            this.ogretimGorevlisiCombo.TabIndex = 1;
            this.ogretimGorevlisiCombo.SelectedIndexChanged += new System.EventHandler(this.ogretimGorevlisiCombo_SelectedIndexChanged);
            // 
            // bolumCombo
            // 
            this.bolumCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bolumCombo.Items.AddRange(new object[] {
            "1",
            "2"});
            this.bolumCombo.Location = new System.Drawing.Point(223, 108);
            this.bolumCombo.Name = "bolumCombo";
            this.bolumCombo.Size = new System.Drawing.Size(108, 21);
            this.bolumCombo.TabIndex = 0;
            this.bolumCombo.SelectedIndexChanged += new System.EventHandler(this.bolumCombo_SelectedIndexChanged);
            // 
            // errorProviderPort
            // 
            this.errorProviderPort.ContainerControl = this;
            // 
            // errorProviderRate
            // 
            this.errorProviderRate.ContainerControl = this;
            // 
            // errorProviderBolum
            // 
            this.errorProviderBolum.ContainerControl = this;
            // 
            // errorProviderHoca
            // 
            this.errorProviderHoca.ContainerControl = this;
            // 
            // errorProviderDers
            // 
            this.errorProviderDers.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 318);
            this.Controls.Add(this.bolumCombo);
            this.Controls.Add(this.ogretimGorevlisiCombo);
            this.Controls.Add(this.dersCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.durumLabel);
            this.Controls.Add(this.baudCombo);
            this.Controls.Add(this.portCombo);
            this.Controls.Add(this.koparButton);
            this.Controls.Add(this.baglanButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHoca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baglanButton;
        private System.Windows.Forms.Button koparButton;
        private System.Windows.Forms.ComboBox portCombo;
        private System.Windows.Forms.ComboBox baudCombo;
        private System.Windows.Forms.Label durumLabel;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerMAIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dersCombo;
        private System.Windows.Forms.ComboBox ogretimGorevlisiCombo;
        private System.Windows.Forms.ComboBox bolumCombo;
        private System.Windows.Forms.ErrorProvider errorProviderPort;
        private System.Windows.Forms.ErrorProvider errorProviderRate;
        private System.Windows.Forms.ErrorProvider errorProviderBolum;
        private System.Windows.Forms.ErrorProvider errorProviderHoca;
        private System.Windows.Forms.ErrorProvider errorProviderDers;
    }
}


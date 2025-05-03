namespace DesktopClientUCNFlight.GuiLayer
{
    partial class Form3
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
            labelFlightInfo = new Label();
            groupBox1 = new GroupBox();
            labelBirthDate = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelPassport = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonNext2 = new Button();
            panelGang = new Panel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelFlightInfo
            // 
            labelFlightInfo.AutoSize = true;
            labelFlightInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFlightInfo.Location = new Point(35, 33);
            labelFlightInfo.Name = "labelFlightInfo";
            labelFlightInfo.Size = new Size(290, 28);
            labelFlightInfo.TabIndex = 0;
            labelFlightInfo.Text = "Information is displayed here";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelBirthDate);
            groupBox1.Controls.Add(labelLastName);
            groupBox1.Controls.Add(labelFirstName);
            groupBox1.Controls.Add(labelPassport);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(35, 288);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 402);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Please fill in the information";
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBirthDate.Location = new Point(69, 302);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(116, 28);
            labelBirthDate.TabIndex = 7;
            labelBirthDate.Text = "Birth Date:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLastName.Location = new Point(68, 236);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(117, 28);
            labelLastName.TabIndex = 6;
            labelLastName.Text = "Last Name:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFirstName.Location = new Point(65, 165);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(120, 28);
            labelFirstName.TabIndex = 5;
            labelFirstName.Text = "First Name:";
            // 
            // labelPassport
            // 
            labelPassport.AutoSize = true;
            labelPassport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassport.Location = new Point(56, 94);
            labelPassport.Name = "labelPassport";
            labelPassport.Size = new Size(129, 28);
            labelPassport.TabIndex = 4;
            labelPassport.Text = "Passport no:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(201, 302);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(174, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(201, 236);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(174, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(201, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(201, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(741, 113);
            label1.Name = "label1";
            label1.Size = new Size(257, 54);
            label1.TabIndex = 2;
            label1.Text = "Select a seat";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(568, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(577, 508);
            panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(panelGang, 3, 0);
            tableLayoutPanel1.Location = new Point(572, 186);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(569, 500);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonNext2
            // 
            buttonNext2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonNext2.Location = new Point(1174, 659);
            buttonNext2.Name = "buttonNext2";
            buttonNext2.Size = new Size(69, 31);
            buttonNext2.TabIndex = 4;
            buttonNext2.Text = "Next";
            buttonNext2.UseVisualStyleBackColor = true;
            // 
            // panelGang
            // 
            panelGang.BackColor = SystemColors.ButtonHighlight;
            panelGang.Location = new Point(216, 3);
            panelGang.Name = "panelGang";
            tableLayoutPanel1.SetRowSpan(panelGang, 10);
            panelGang.Size = new Size(136, 494);
            panelGang.TabIndex = 5;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 729);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(buttonNext2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(labelFlightInfo);
            Name = "Form3";
            Text = "UCN Airlines";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFlightInfo;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label labelBirthDate;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelPassport;
        private DataGridViewTextBoxColumn Column1A;
        private DataGridViewTextBoxColumn Column1B;
        private DataGridViewTextBoxColumn Column1C;
        private DataGridViewTextBoxColumn ColGang;
        private DataGridViewTextBoxColumn Column1D;
        private DataGridViewTextBoxColumn Column1E;
        private DataGridViewTextBoxColumn Column1F;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column20;
        private DataGridViewTextBoxColumn Column21;
        private DataGridViewTextBoxColumn Column22;
        private DataGridViewTextBoxColumn Column23;
        private DataGridViewTextBoxColumn Column24;
        private DataGridViewTextBoxColumn Column25;
        private DataGridViewTextBoxColumn Column26;
        private DataGridViewTextBoxColumn Column27;
        private DataGridViewTextBoxColumn Column28;
        private DataGridViewTextBoxColumn Column29;
        private DataGridViewTextBoxColumn Column30;
        private DataGridViewTextBoxColumn Column31;
        private DataGridViewTextBoxColumn Column32;
        private DataGridViewTextBoxColumn Column33;
        private DataGridViewTextBoxColumn Column34;
        private DataGridViewTextBoxColumn Column35;
        private DataGridViewTextBoxColumn Column36;
        private DataGridViewTextBoxColumn Column37;
        private DataGridViewTextBoxColumn Column38;
        private DataGridViewTextBoxColumn Column39;
        private DataGridViewTextBoxColumn Column40;
        private DataGridViewTextBoxColumn Column41;
        private DataGridViewTextBoxColumn Column42;
        private DataGridViewTextBoxColumn Column43;
        private DataGridViewTextBoxColumn Column44;
        private DataGridViewTextBoxColumn Column45;
        private DataGridViewTextBoxColumn Column46;
        private DataGridViewTextBoxColumn Column47;
        private DataGridViewTextBoxColumn Column48;
        private DataGridViewTextBoxColumn Column49;
        private DataGridViewTextBoxColumn Column50;
        private DataGridViewTextBoxColumn Column51;
        private DataGridViewTextBoxColumn Column52;
        private DataGridViewTextBoxColumn Column53;
        private DataGridViewTextBoxColumn Column54;
        private DataGridViewTextBoxColumn Column55;
        private DataGridViewTextBoxColumn Column56;
        private DataGridViewTextBoxColumn Column57;
        private DataGridViewTextBoxColumn Column58;
        private DataGridViewTextBoxColumn Column59;
        private DataGridViewTextBoxColumn Column60;
        private Label label1;
        private Panel panel1;
        private Button buttonNext2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelGang;
    }
}
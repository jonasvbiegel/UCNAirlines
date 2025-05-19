<<<<<<< HEAD
using System.Windows.Forms;

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
                                    dateTimePickerBirth = new DateTimePicker();
                                    textBoxLastName = new TextBox();
                                    textBoxFirstName = new TextBox();
                                    textBoxPassport = new TextBox();
                                    label1 = new Label();
                                    buttonNext2 = new Button();
                                    labelPassengerInfo = new Label();
                                    panel1 = new Panel();
                                    tableLayoutPanel1 = new TableLayoutPanel();
                                    groupBox1.SuspendLayout();
                                    panel1.SuspendLayout();
                                    SuspendLayout();
                                    // 
                                    // labelFlightInfo
                                    // 
                                    labelFlightInfo.AutoSize = true;
                                    labelFlightInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelFlightInfo.Location = new Point(35, 33);
                                    labelFlightInfo.Name = "labelFlightInfo";
                                    labelFlightInfo.Size = new Size(261, 25);
                                    labelFlightInfo.TabIndex = 0;
                                    labelFlightInfo.Text = "Information is displayed here";
                                    // 
                                    // groupBox1
                                    // 
                                    groupBox1.Controls.Add(labelBirthDate);
                                    groupBox1.Controls.Add(labelLastName);
                                    groupBox1.Controls.Add(labelFirstName);
                                    groupBox1.Controls.Add(labelPassport);
                                    groupBox1.Controls.Add(dateTimePickerBirth);
                                    groupBox1.Controls.Add(textBoxLastName);
                                    groupBox1.Controls.Add(textBoxFirstName);
                                    groupBox1.Controls.Add(textBoxPassport);
                                    groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    groupBox1.Location = new Point(35, 237);
                                    groupBox1.Name = "groupBox1";
                                    groupBox1.Size = new Size(489, 453);
                                    groupBox1.TabIndex = 1;
                                    groupBox1.TabStop = false;
                                    groupBox1.Text = "Please fill in the information";
                                    // 
                                    // labelBirthDate
                                    // 
                                    labelBirthDate.AutoSize = true;
                                    labelBirthDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelBirthDate.Location = new Point(69, 290);
                                    labelBirthDate.Name = "labelBirthDate";
                                    labelBirthDate.Size = new Size(116, 28);
                                    labelBirthDate.TabIndex = 7;
                                    labelBirthDate.Text = "Birth Date:";
                                    // 
                                    // labelLastName
                                    // 
                                    labelLastName.AutoSize = true;
                                    labelLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelLastName.Location = new Point(72, 167);
                                    labelLastName.Name = "labelLastName";
                                    labelLastName.Size = new Size(117, 28);
                                    labelLastName.TabIndex = 6;
                                    labelLastName.Text = "Last Name:";
                                    // 
                                    // labelFirstName
                                    // 
                                    labelFirstName.AutoSize = true;
                                    labelFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelFirstName.Location = new Point(69, 101);
                                    labelFirstName.Name = "labelFirstName";
                                    labelFirstName.Size = new Size(120, 28);
                                    labelFirstName.TabIndex = 5;
                                    labelFirstName.Text = "First Name:";
                                    // 
                                    // labelPassport
                                    // 
                                    labelPassport.AutoSize = true;
                                    labelPassport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelPassport.Location = new Point(60, 228);
                                    labelPassport.Name = "labelPassport";
                                    labelPassport.Size = new Size(129, 28);
                                    labelPassport.TabIndex = 4;
                                    labelPassport.Text = "Passport no:";
                                    // 
                                    // dateTimePickerBirth
                                    // 
                                    dateTimePickerBirth.Location = new Point(201, 292);
                                    dateTimePickerBirth.Name = "dateTimePickerBirth";
                                    dateTimePickerBirth.Size = new Size(174, 27);
                                    dateTimePickerBirth.TabIndex = 3;
                                    dateTimePickerBirth.CustomFormat = "dd-MM-yyyy";
                                    dateTimePickerBirth.Format = DateTimePickerFormat.Custom;
                                    // 
                                    // textBoxLastName
                                    // 
                                    textBoxLastName.Location = new Point(201, 168);
                                    textBoxLastName.Name = "textBoxLastName";
                                    textBoxLastName.Size = new Size(174, 27);
                                    textBoxLastName.TabIndex = 2;
                                    // 
                                    // textBoxFirstName
                                    // 
                                    textBoxFirstName.Location = new Point(201, 102);
                                    textBoxFirstName.Name = "textBoxFirstName";
                                    textBoxFirstName.Size = new Size(174, 27);
                                    textBoxFirstName.TabIndex = 1;
                                    // 
                                    // textBoxPassport
                                    // 
                                    textBoxPassport.Location = new Point(201, 228);
                                    textBoxPassport.Name = "textBoxPassport";
                                    textBoxPassport.Size = new Size(174, 27);
                                    textBoxPassport.TabIndex = 0;
                                    // 
                                    // label1
                                    // 
                                    label1.AutoSize = true;
                                    label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    label1.Location = new Point(780, 65);
                                    label1.Name = "label1";
                                    label1.Size = new Size(257, 54);
                                    label1.TabIndex = 2;
                                    label1.Text = "Select a seat";
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
                                    buttonNext2.Click += buttonNext2_Click;
                                    // 
                                    // labelPassengerInfo
                                    // 
                                    labelPassengerInfo.AutoSize = true;
                                    labelPassengerInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    labelPassengerInfo.Location = new Point(210, 182);
                                    labelPassengerInfo.Name = "labelPassengerInfo";
                                    labelPassengerInfo.Size = new Size(174, 25);
                                    labelPassengerInfo.TabIndex = 5;
                                    labelPassengerInfo.Text = "labelPassengerInfo";
                                    // 
                                    // panel1
                                    // 
                                    panel1.AutoScroll = true;
                                    panel1.Controls.Add(tableLayoutPanel1);
                                    panel1.Location = new Point(571, 62);
                                    panel1.Name = "panel1";
                                    panel1.Size = new Size(703, 591);
                                    panel1.TabIndex = 7;
                                    // 
                                    // tableLayoutPanel1
                                    // 
                                    tableLayoutPanel1.AutoScroll = true;
                                    tableLayoutPanel1.AutoSize = true;
                                    tableLayoutPanel1.ColumnCount = 2;
                                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
                                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
                                    tableLayoutPanel1.Location = new Point(97, 89);
                                    tableLayoutPanel1.Name = "tableLayoutPanel1";
                                    tableLayoutPanel1.RowCount = 2;
                                    tableLayoutPanel1.RowStyles.Add(new RowStyle());
                                    tableLayoutPanel1.RowStyles.Add(new RowStyle());
                                    tableLayoutPanel1.Size = new Size(575, 485);
                                    tableLayoutPanel1.TabIndex = 6;
                                    // 
                                    // Form3
                                    // 
                                    AutoScaleDimensions = new SizeF(8F, 20F);
                                    AutoScaleMode = AutoScaleMode.Font;
                                    ClientSize = new Size(1282, 729);
                                    Controls.Add(labelPassengerInfo);
                                    Controls.Add(buttonNext2);
                                    Controls.Add(label1);
                                    Controls.Add(groupBox1);
                                    Controls.Add(labelFlightInfo);
                                    Controls.Add(panel1);
                                    Name = "Form3";
                                    Text = "UCN Airlines";
                                    groupBox1.ResumeLayout(false);
                                    groupBox1.PerformLayout();
                                    panel1.ResumeLayout(false);
                                    panel1.PerformLayout();
                                    ResumeLayout(false);
                                    PerformLayout();
                        }

                        #endregion

                        private Label labelFlightInfo;
                        private GroupBox groupBox1;
                        private DateTimePicker dateTimePickerBirth;
                        private TextBox textBoxLastName;
                        private TextBox textBoxFirstName;
                        private TextBox textBoxPassport;
                        private Label labelBirthDate;
                        private Label labelLastName;
                        private Label labelFirstName;
                        private Label labelPassport;
                        private Label label1;
                        private Button buttonNext2;
                        private Label labelPassengerInfo;
                        private Panel panel1;
                        private TableLayoutPanel tableLayoutPanel1;
            }
=======

using System.Windows.Forms;


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
            dateTimePickerBirth = new DateTimePicker();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxPassport = new TextBox();
            label1 = new Label();
            buttonNext2 = new Button();
            labelPassengerInfo = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelFlightInfo
            // 
            labelFlightInfo.AutoSize = true;
            labelFlightInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFlightInfo.Location = new Point(35, 33);
            labelFlightInfo.Name = "labelFlightInfo";
            labelFlightInfo.Size = new Size(261, 25);
            labelFlightInfo.TabIndex = 0;
            labelFlightInfo.Text = "Information is displayed here";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelBirthDate);
            groupBox1.Controls.Add(labelLastName);
            groupBox1.Controls.Add(labelFirstName);
            groupBox1.Controls.Add(labelPassport);
            groupBox1.Controls.Add(dateTimePickerBirth);
            groupBox1.Controls.Add(textBoxLastName);
            groupBox1.Controls.Add(textBoxFirstName);
            groupBox1.Controls.Add(textBoxPassport);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(35, 237);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 453);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Please fill in the information";
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBirthDate.Location = new Point(69, 290);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(116, 28);
            labelBirthDate.TabIndex = 7;
            labelBirthDate.Text = "Birth Date:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLastName.Location = new Point(72, 167);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(117, 28);
            labelLastName.TabIndex = 6;
            labelLastName.Text = "Last Name:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFirstName.Location = new Point(69, 101);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(120, 28);
            labelFirstName.TabIndex = 5;
            labelFirstName.Text = "First Name:";
            // 
            // labelPassport
            // 
            labelPassport.AutoSize = true;
            labelPassport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassport.Location = new Point(60, 228);
            labelPassport.Name = "labelPassport";
            labelPassport.Size = new Size(129, 28);
            labelPassport.TabIndex = 4;
            labelPassport.Text = "Passport no:";
            // 
            // dateTimePickerBirth
            // 
            dateTimePickerBirth.Location = new Point(201, 292);
            dateTimePickerBirth.Name = "dateTimePickerBirth";
            dateTimePickerBirth.Size = new Size(174, 27);
            dateTimePickerBirth.TabIndex = 3;
            dateTimePickerBirth.CustomFormat = "dd-MM-yyyy";
            dateTimePickerBirth.Format = DateTimePickerFormat.Custom;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(201, 168);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(174, 27);
            textBoxLastName.TabIndex = 2;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(201, 102);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(174, 27);
            textBoxFirstName.TabIndex = 1;
            // 
            // textBoxPassport
            // 
            textBoxPassport.Location = new Point(201, 228);
            textBoxPassport.Name = "textBoxPassport";
            textBoxPassport.Size = new Size(174, 27);
            textBoxPassport.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(780, 65);
            label1.Name = "label1";
            label1.Size = new Size(257, 54);
            label1.TabIndex = 2;
            label1.Text = "Select a seat";
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
            buttonNext2.Click += buttonNext2_Click;
            // 
            // labelPassengerInfo
            // 
            labelPassengerInfo.AutoSize = true;
            labelPassengerInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassengerInfo.Location = new Point(210, 182);
            labelPassengerInfo.Name = "labelPassengerInfo";
            labelPassengerInfo.Size = new Size(174, 25);
            labelPassengerInfo.TabIndex = 5;
            labelPassengerInfo.Text = "labelPassengerInfo";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(571, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 591);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(97, 89);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(575, 485);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 729);
            Controls.Add(labelPassengerInfo);
            Controls.Add(buttonNext2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(labelFlightInfo);
            Controls.Add(panel1);
            Name = "Form3";
            Text = "UCN Airlines";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        

        private Label labelFlightInfo;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePickerBirth;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxPassport;
        private Label labelBirthDate;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelPassport;
        private Label label1;
        private Button buttonNext2;
        private Label labelPassengerInfo;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
>>>>>>> develop
}

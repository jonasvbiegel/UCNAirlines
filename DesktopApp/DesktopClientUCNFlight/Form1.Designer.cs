namespace DesktopClientUCNFlight
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            labelPersons = new Label();
            labelTo = new Label();
            labelFrom = new Label();
            monthCalendar1 = new MonthCalendar();
            comboBoxPersons = new ComboBox();
            comboBoxArrival = new ComboBox();
            comboBoxDeparture = new ComboBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            buttonLogIn = new Button();
            buttonFindReservation = new Button();
            buttonCheckIn = new Button();
            labelBookaTrip = new Label();
            buttonNext = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelPersons);
            groupBox1.Controls.Add(labelTo);
            groupBox1.Controls.Add(labelFrom);
            groupBox1.Controls.Add(monthCalendar1);
            groupBox1.Controls.Add(comboBoxPersons);
            groupBox1.Controls.Add(comboBoxArrival);
            groupBox1.Controls.Add(comboBoxDeparture);
            groupBox1.Location = new Point(279, 339);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(781, 512);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fly";
            // 
            // labelPersons
            // 
            labelPersons.AutoSize = true;
            labelPersons.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPersons.Location = new Point(59, 209);
            labelPersons.Name = "labelPersons";
            labelPersons.Size = new Size(89, 28);
            labelPersons.TabIndex = 6;
            labelPersons.Text = "Persons:";
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTo.Location = new Point(59, 157);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(39, 28);
            labelTo.TabIndex = 5;
            labelTo.Text = "To:";
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFrom.Location = new Point(59, 108);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(65, 28);
            labelFrom.TabIndex = 4;
            labelFrom.Text = "From:";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(456, 79);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            // 
            // comboBoxPersons
            // 
            comboBoxPersons.FormattingEnabled = true;
            comboBoxPersons.Location = new Point(251, 209);
            comboBoxPersons.Name = "comboBoxPersons";
            comboBoxPersons.Size = new Size(65, 28);
            comboBoxPersons.TabIndex = 2;
            // 
            // comboBoxArrival
            // 
            comboBoxArrival.FormattingEnabled = true;
            comboBoxArrival.Location = new Point(154, 157);
            comboBoxArrival.Name = "comboBoxArrival";
            comboBoxArrival.Size = new Size(162, 28);
            comboBoxArrival.TabIndex = 1;
            // 
            // comboBoxDeparture
            // 
            comboBoxDeparture.FormattingEnabled = true;
            comboBoxDeparture.Location = new Point(154, 108);
            comboBoxDeparture.Name = "comboBoxDeparture";
            comboBoxDeparture.Size = new Size(162, 28);
            comboBoxDeparture.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UCNAirlines;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1282, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(buttonLogIn);
            panel1.Controls.Add(buttonFindReservation);
            panel1.Controls.Add(buttonCheckIn);
            panel1.Location = new Point(0, 174);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 49);
            panel1.TabIndex = 2;
            // 
            // buttonLogIn
            // 
            buttonLogIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogIn.Location = new Point(1119, 8);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(151, 37);
            buttonLogIn.TabIndex = 2;
            buttonLogIn.Text = "Log ind";
            buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // buttonFindReservation
            // 
            buttonFindReservation.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonFindReservation.Location = new Point(153, 8);
            buttonFindReservation.Name = "buttonFindReservation";
            buttonFindReservation.Size = new Size(208, 38);
            buttonFindReservation.TabIndex = 1;
            buttonFindReservation.Text = "Find Reservation";
            buttonFindReservation.UseVisualStyleBackColor = true;
            // 
            // buttonCheckIn
            // 
            buttonCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCheckIn.Location = new Point(12, 8);
            buttonCheckIn.Name = "buttonCheckIn";
            buttonCheckIn.Size = new Size(135, 38);
            buttonCheckIn.TabIndex = 0;
            buttonCheckIn.Text = "Check in";
            buttonCheckIn.UseVisualStyleBackColor = true;
            // 
            // labelBookaTrip
            // 
            labelBookaTrip.AutoSize = true;
            labelBookaTrip.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookaTrip.Location = new Point(518, 271);
            labelBookaTrip.Name = "labelBookaTrip";
            labelBookaTrip.Size = new Size(231, 54);
            labelBookaTrip.TabIndex = 3;
            labelBookaTrip.Text = "Book a trip";
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(1157, 812);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(94, 29);
            buttonNext.TabIndex = 4;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += ButtonNext_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 853);
            Controls.Add(buttonNext);
            Controls.Add(labelBookaTrip);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "UCN Airline";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MonthCalendar monthCalendar1;
        private ComboBox comboBoxPersons;
        private ComboBox comboBoxArrival;
        private ComboBox comboBoxDeparture;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button buttonLogIn;
        private Button buttonFindReservation;
        private Button buttonCheckIn;
        private Label labelPersons;
        private Label labelTo;
        private Label labelFrom;
        private Label labelBookaTrip;
        private Button buttonNext;
    }
}

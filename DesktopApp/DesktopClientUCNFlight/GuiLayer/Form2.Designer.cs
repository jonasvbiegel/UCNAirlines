namespace DesktopClientUCNFlight
{
    partial class Form2
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
            labelInfo = new Label();
            label1 = new Label();
            listViewFlights = new ListView();
            buttonBack = new Button();
            buttonNext2 = new Button();
            SuspendLayout();
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(29, 60);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(328, 31);
            labelInfo.TabIndex = 0;
            labelInfo.Text = "Information is displayed here";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(316, 192);
            label1.Name = "label1";
            label1.Size = new Size(720, 54);
            label1.TabIndex = 1;
            label1.Text = "Available flights on the selected date";
            // 
            // listViewFlights
            // 
            listViewFlights.BackColor = SystemColors.ControlLight;
            listViewFlights.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listViewFlights.FullRowSelect = true;
            listViewFlights.GridLines = true;
            listViewFlights.Location = new Point(250, 249);
            listViewFlights.Name = "listViewFlights";
            listViewFlights.Size = new Size(813, 440);
            listViewFlights.TabIndex = 2;
            listViewFlights.UseCompatibleStateImageBehavior = false;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBack.Location = new Point(29, 655);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(116, 34);
            buttonBack.TabIndex = 3;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonNext2
            // 
            buttonNext2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonNext2.Location = new Point(1129, 656);
            buttonNext2.Name = "buttonNext2";
            buttonNext2.Size = new Size(105, 33);
            buttonNext2.TabIndex = 4;
            buttonNext2.Text = "Next";
            buttonNext2.UseVisualStyleBackColor = true;
            buttonNext2.Click += buttonNext2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 729);
            Controls.Add(buttonNext2);
            Controls.Add(buttonBack);
            Controls.Add(listViewFlights);
            Controls.Add(label1);
            Controls.Add(labelInfo);
            Name = "Form2";
            Text = "UCN Airlines";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInfo;
        private Label label1;
        private ListView listViewFlights;
        private Button buttonBack;
        private Button buttonNext2;
    }
}
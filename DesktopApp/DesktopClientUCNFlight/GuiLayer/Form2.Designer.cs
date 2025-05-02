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
            buttonSelect1 = new Button();
            buttonSelect2 = new Button();
            buttonSelect3 = new Button();
            SuspendLayout();
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(29, 60);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(160, 31);
            labelInfo.TabIndex = 0;
            labelInfo.Text = "Her vises info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(316, 192);
            label1.Name = "label1";
            label1.Size = new Size(663, 54);
            label1.TabIndex = 1;
            label1.Text = "Ledige flytider på den valgte dato";
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
            // buttonSelect1
            // 
            buttonSelect1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSelect1.Location = new Point(884, 290);
            buttonSelect1.Name = "buttonSelect1";
            buttonSelect1.Size = new Size(86, 26);
            buttonSelect1.TabIndex = 5;
            buttonSelect1.Text = "SELECT";
            buttonSelect1.UseVisualStyleBackColor = true;
            // 
            // buttonSelect2
            // 
            buttonSelect2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSelect2.Location = new Point(884, 322);
            buttonSelect2.Name = "buttonSelect2";
            buttonSelect2.Size = new Size(86, 30);
            buttonSelect2.TabIndex = 6;
            buttonSelect2.Text = "SELECT";
            buttonSelect2.UseVisualStyleBackColor = true;
            // 
            // buttonSelect3
            // 
            buttonSelect3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSelect3.Location = new Point(884, 358);
            buttonSelect3.Name = "buttonSelect3";
            buttonSelect3.Size = new Size(86, 28);
            buttonSelect3.TabIndex = 7;
            buttonSelect3.Text = "SELECT";
            buttonSelect3.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 729);
            Controls.Add(buttonSelect3);
            Controls.Add(buttonSelect2);
            Controls.Add(buttonSelect1);
            Controls.Add(buttonNext2);
            Controls.Add(buttonBack);
            Controls.Add(listViewFlights);
            Controls.Add(label1);
            Controls.Add(labelInfo);
            Name = "Form2";
            Text = "UCN Airline";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInfo;
        private Label label1;
        private ListView listViewFlights;
        private Button buttonBack;
        private Button buttonNext2;
        private Button buttonSelect1;
        private Button buttonSelect2;
        private Button buttonSelect3;
    }
}
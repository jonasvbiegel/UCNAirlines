namespace DesktopClientUCNFlight.GuiLayer
{
    partial class Form4
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
            panel1 = new Panel();
            textBoxOverview = new TextBox();
            buttonConfirm = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxOverview);
            panel1.Location = new Point(42, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(1001, 604);
            panel1.TabIndex = 0;
            // 
            // textBoxOverview
            // 
            textBoxOverview.Dock = DockStyle.Fill;
            textBoxOverview.Enabled = false;
            textBoxOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxOverview.Location = new Point(0, 0);
            textBoxOverview.Multiline = true;
            textBoxOverview.Name = "textBoxOverview";
            textBoxOverview.ReadOnly = true;
            textBoxOverview.ScrollBars = ScrollBars.Vertical;
            textBoxOverview.Size = new Size(1001, 604);
            textBoxOverview.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConfirm.Location = new Point(1112, 603);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(94, 29);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 729);
            Controls.Add(buttonConfirm);
            Controls.Add(panel1);
            Name = "Form4";
            Text = "UCN Airlines";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxOverview;
        private Button buttonConfirm;
    }
}
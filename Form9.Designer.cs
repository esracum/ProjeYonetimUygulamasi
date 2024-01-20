namespace EmployeesProject
{
    partial class Form9
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
            this.button1 = new System.Windows.Forms.Button();
            this.startdate = new System.Windows.Forms.MaskedTextBox();
            this.enddate = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDeleteProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(293, 327);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // startdate
            // 
            this.startdate.Location = new System.Drawing.Point(293, 187);
            this.startdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.startdate.Mask = "00/00/0000";
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(164, 35);
            this.startdate.TabIndex = 1;
            this.startdate.ValidatingType = typeof(System.DateTime);
            this.startdate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.startdate_MaskInputRejected);
            // 
            // enddate
            // 
            this.enddate.Location = new System.Drawing.Point(293, 261);
            this.enddate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.enddate.Mask = "00/00/0000";
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(164, 35);
            this.enddate.TabIndex = 2;
            this.enddate.ValidatingType = typeof(System.DateTime);
            this.enddate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.enddate_MaskInputRejected);
            // 
            // textBoxDeleteProjectName
            // 
            this.textBoxDeleteProjectName.Location = new System.Drawing.Point(293, 124);
            this.textBoxDeleteProjectName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxDeleteProjectName.Name = "textBoxDeleteProjectName";
            this.textBoxDeleteProjectName.Size = new System.Drawing.Size(164, 35);
            this.textBoxDeleteProjectName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project Name:";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(635, 483);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDeleteProjectName);
            this.Controls.Add(this.enddate);
            this.Controls.Add(this.startdate);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form9";
            this.Text = "Delete Project";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox startdate;
        private System.Windows.Forms.MaskedTextBox enddate;
        private System.Windows.Forms.TextBox textBoxDeleteProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
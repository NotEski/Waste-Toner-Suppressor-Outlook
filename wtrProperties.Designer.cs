namespace WasteToner
{
    partial class wtrProperties
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblHold = new System.Windows.Forms.Label();
            this.txtFolderLocation = new System.Windows.Forms.TextBox();
            this.numCheck = new System.Windows.Forms.NumericUpDown();
            this.numHold = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHold)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(66, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(180, 187);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(15, 46);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(91, 20);
            this.lblFolder.TabIndex = 6;
            this.lblFolder.Text = "Alert Folder";
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(15, 87);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(105, 20);
            this.lblCheck.TabIndex = 7;
            this.lblCheck.Text = "Check x Days";
            // 
            // lblHold
            // 
            this.lblHold.AutoSize = true;
            this.lblHold.Location = new System.Drawing.Point(15, 130);
            this.lblHold.Name = "lblHold";
            this.lblHold.Size = new System.Drawing.Size(81, 20);
            this.lblHold.TabIndex = 8;
            this.lblHold.Text = "Hold Data";
            // 
            // txtFolderLocation
            // 
            this.txtFolderLocation.Location = new System.Drawing.Point(126, 46);
            this.txtFolderLocation.Name = "txtFolderLocation";
            this.txtFolderLocation.Size = new System.Drawing.Size(222, 26);
            this.txtFolderLocation.TabIndex = 0;
            // 
            // numCheck
            // 
            this.numCheck.Location = new System.Drawing.Point(126, 85);
            this.numCheck.Name = "numCheck";
            this.numCheck.Size = new System.Drawing.Size(138, 26);
            this.numCheck.TabIndex = 1;
            // 
            // numHold
            // 
            this.numHold.Location = new System.Drawing.Point(126, 128);
            this.numHold.Name = "numHold";
            this.numHold.Size = new System.Drawing.Size(138, 26);
            this.numHold.TabIndex = 2;
            // 
            // wtrProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 229);
            this.Controls.Add(this.numHold);
            this.Controls.Add(this.numCheck);
            this.Controls.Add(this.txtFolderLocation);
            this.Controls.Add(this.lblHold);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "wtrProperties";
            this.Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblHold;
        private System.Windows.Forms.TextBox txtFolderLocation;
        private System.Windows.Forms.NumericUpDown numCheck;
        private System.Windows.Forms.NumericUpDown numHold;
    }
}
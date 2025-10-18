using System.Windows.Forms;

namespace GenerateCode
{
    partial class frmColumnSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpColumns;
        private Button btnSelectAll;
        private Button btnDeselectAll;
        private Button btnOK;
        private Button btnCancel;
        private Panel panelButtons;
        private Label labelTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flpColumns = new System.Windows.Forms.FlowLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpColumns
            // 
            this.flpColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpColumns.AutoScroll = true;
            this.flpColumns.BackColor = System.Drawing.Color.White;
            this.flpColumns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpColumns.Location = new System.Drawing.Point(20, 60);
            this.flpColumns.Name = "flpColumns";
            this.flpColumns.Padding = new System.Windows.Forms.Padding(10);
            this.flpColumns.Size = new System.Drawing.Size(490, 367);
            this.flpColumns.TabIndex = 3;
            this.flpColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.flpColumns_Paint);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnDeselectAll);
            this.panelButtons.Controls.Add(this.btnSelectAll);
            this.panelButtons.Location = new System.Drawing.Point(20, 437);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(490, 60);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(390, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(300, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnDeselectAll.FlatAppearance.BorderSize = 0;
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeselectAll.ForeColor = System.Drawing.Color.White;
            this.btnDeselectAll.Location = new System.Drawing.Point(130, 15);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(100, 30);
            this.btnDeselectAll.TabIndex = 1;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(20, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(100, 30);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelTitle.Location = new System.Drawing.Point(15, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(420, 32);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Select Columns for FindBy Methods";
            // 
            // frmColumnSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 517);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.flpColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColumnSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Column Selection";
            this.Load += new System.EventHandler(this.frmColumnSelectionForm_Load);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
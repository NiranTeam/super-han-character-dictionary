

namespace EntryEditor
{
    partial class MainForm
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
            txtSearch = new TextBox();
            btnFind = new Button();
            btnAddOrUpdate = new Button();
            dgwMain = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwMain).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(592, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(783, 23);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(94, 29);
            btnFind.TabIndex = 2;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnAddOrUpdate
            // 
            btnAddOrUpdate.Location = new Point(893, 22);
            btnAddOrUpdate.Name = "btnAddOrUpdate";
            btnAddOrUpdate.Size = new Size(198, 29);
            btnAddOrUpdate.TabIndex = 3;
            btnAddOrUpdate.Text = "AddOrUpdate";
            btnAddOrUpdate.UseVisualStyleBackColor = true;
            btnAddOrUpdate.Click += btnAddOrUpdate_Click;
            // 
            // dgwMain
            // 
            dgwMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgwMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwMain.Location = new Point(12, 78);
            dgwMain.Name = "dgwMain";
            dgwMain.RowHeadersWidth = 51;
            dgwMain.Size = new Size(1079, 399);
            dgwMain.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 489);
            Controls.Add(dgwMain);
            Controls.Add(btnAddOrUpdate);
            Controls.Add(btnFind);
            Controls.Add(txtSearch);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgwMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TextBox txtSearch;
        private Button btnFind;
        private Button btnAddOrUpdate;
        private DataGridView dgwMain;
    }
}

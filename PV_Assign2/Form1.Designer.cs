namespace PV_Assign2
{
    partial class Form1
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
            this.groceryListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteSelectedItemButton = new System.Windows.Forms.Button();
            this.UpdateRestockedQtyForSelectedItemButton = new System.Windows.Forms.Button();
            this.qtyRestockedTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qtySoldTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateSoldQtyForSelectedItemButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SaveRestockNeedsButton = new System.Windows.Forms.Button();
            this.SaveSalesButton = new System.Windows.Forms.Button();
            this.SaveGroceryDataButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groceryListBox
            // 
            this.groceryListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groceryListBox.FormattingEnabled = true;
            this.groceryListBox.ItemHeight = 18;
            this.groceryListBox.Location = new System.Drawing.Point(12, 65);
            this.groceryListBox.Name = "groceryListBox";
            this.groceryListBox.Size = new System.Drawing.Size(1377, 238);
            this.groceryListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Grocery Application";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupBox1.Controls.Add(this.LoadDataButton);
            this.groupBox1.Location = new System.Drawing.Point(101, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Data";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(32, 42);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(159, 46);
            this.LoadDataButton.TabIndex = 0;
            this.LoadDataButton.Text = "Load Grocery Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupBox2.Controls.Add(this.DeleteSelectedItemButton);
            this.groupBox2.Controls.Add(this.UpdateRestockedQtyForSelectedItemButton);
            this.groupBox2.Controls.Add(this.qtyRestockedTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.qtySoldTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.UpdateSoldQtyForSelectedItemButton);
            this.groupBox2.Location = new System.Drawing.Point(376, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(617, 179);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Data";
            // 
            // DeleteSelectedItemButton
            // 
            this.DeleteSelectedItemButton.Location = new System.Drawing.Point(187, 126);
            this.DeleteSelectedItemButton.Name = "DeleteSelectedItemButton";
            this.DeleteSelectedItemButton.Size = new System.Drawing.Size(218, 40);
            this.DeleteSelectedItemButton.TabIndex = 6;
            this.DeleteSelectedItemButton.Text = "Delete Selected Grocery Item";
            this.DeleteSelectedItemButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedItemButton.Click += new System.EventHandler(this.DeleteSelectedItemButton_Click);
            // 
            // UpdateRestockedQtyForSelectedItemButton
            // 
            this.UpdateRestockedQtyForSelectedItemButton.Location = new System.Drawing.Point(374, 63);
            this.UpdateRestockedQtyForSelectedItemButton.Name = "UpdateRestockedQtyForSelectedItemButton";
            this.UpdateRestockedQtyForSelectedItemButton.Size = new System.Drawing.Size(174, 46);
            this.UpdateRestockedQtyForSelectedItemButton.TabIndex = 5;
            this.UpdateRestockedQtyForSelectedItemButton.Text = "Update Restocked Qty For Selected Item";
            this.UpdateRestockedQtyForSelectedItemButton.UseVisualStyleBackColor = true;
            this.UpdateRestockedQtyForSelectedItemButton.Click += new System.EventHandler(this.UpdateRestockedQtyForSelectedItemButton_Click);
            // 
            // qtyRestockedTextBox
            // 
            this.qtyRestockedTextBox.Location = new System.Drawing.Point(478, 29);
            this.qtyRestockedTextBox.Name = "qtyRestockedTextBox";
            this.qtyRestockedTextBox.Size = new System.Drawing.Size(100, 22);
            this.qtyRestockedTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity Restocked:";
            // 
            // qtySoldTextBox
            // 
            this.qtySoldTextBox.Location = new System.Drawing.Point(142, 29);
            this.qtySoldTextBox.Name = "qtySoldTextBox";
            this.qtySoldTextBox.Size = new System.Drawing.Size(100, 22);
            this.qtySoldTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity Sold:";
            // 
            // UpdateSoldQtyForSelectedItemButton
            // 
            this.UpdateSoldQtyForSelectedItemButton.Location = new System.Drawing.Point(72, 63);
            this.UpdateSoldQtyForSelectedItemButton.Name = "UpdateSoldQtyForSelectedItemButton";
            this.UpdateSoldQtyForSelectedItemButton.Size = new System.Drawing.Size(139, 46);
            this.UpdateSoldQtyForSelectedItemButton.TabIndex = 0;
            this.UpdateSoldQtyForSelectedItemButton.Text = "Update Sold Qty For Selected Item";
            this.UpdateSoldQtyForSelectedItemButton.UseVisualStyleBackColor = true;
            this.UpdateSoldQtyForSelectedItemButton.Click += new System.EventHandler(this.UpdateSoldQtyForSelectedItemButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupBox3.Controls.Add(this.SaveRestockNeedsButton);
            this.groupBox3.Controls.Add(this.SaveSalesButton);
            this.groupBox3.Controls.Add(this.SaveGroceryDataButton);
            this.groupBox3.Location = new System.Drawing.Point(1045, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 200);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Data";
            // 
            // SaveRestockNeedsButton
            // 
            this.SaveRestockNeedsButton.Location = new System.Drawing.Point(16, 145);
            this.SaveRestockNeedsButton.Name = "SaveRestockNeedsButton";
            this.SaveRestockNeedsButton.Size = new System.Drawing.Size(216, 34);
            this.SaveRestockNeedsButton.TabIndex = 2;
            this.SaveRestockNeedsButton.Text = "Save Restock Needs Report";
            this.SaveRestockNeedsButton.UseVisualStyleBackColor = true;
            this.SaveRestockNeedsButton.Click += new System.EventHandler(this.SaveRestockNeedsButton_Click);
            // 
            // SaveSalesButton
            // 
            this.SaveSalesButton.Location = new System.Drawing.Point(44, 89);
            this.SaveSalesButton.Name = "SaveSalesButton";
            this.SaveSalesButton.Size = new System.Drawing.Size(159, 34);
            this.SaveSalesButton.TabIndex = 1;
            this.SaveSalesButton.Text = "Save Sales Report";
            this.SaveSalesButton.UseVisualStyleBackColor = true;
            this.SaveSalesButton.Click += new System.EventHandler(this.SaveSalesButton_Click);
            // 
            // SaveGroceryDataButton
            // 
            this.SaveGroceryDataButton.Location = new System.Drawing.Point(44, 32);
            this.SaveGroceryDataButton.Name = "SaveGroceryDataButton";
            this.SaveGroceryDataButton.Size = new System.Drawing.Size(159, 34);
            this.SaveGroceryDataButton.TabIndex = 0;
            this.SaveGroceryDataButton.Text = "Save Grocery Data";
            this.SaveGroceryDataButton.UseVisualStyleBackColor = true;
            this.SaveGroceryDataButton.Click += new System.EventHandler(this.SaveGroceryDataButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.DarkGray;
            this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(376, 508);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(617, 62);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = " Operation Status Update Displayed Here";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1401, 580);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groceryListBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Grocery Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox groceryListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteSelectedItemButton;
        private System.Windows.Forms.Button UpdateRestockedQtyForSelectedItemButton;
        private System.Windows.Forms.TextBox qtyRestockedTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox qtySoldTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateSoldQtyForSelectedItemButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SaveRestockNeedsButton;
        private System.Windows.Forms.Button SaveSalesButton;
        private System.Windows.Forms.Button SaveGroceryDataButton;
        private System.Windows.Forms.Label statusLabel;
    }
}


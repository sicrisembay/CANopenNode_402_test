
namespace SimpleUI
{
    partial class SimpleTest
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
            if (disposing && ( components != null )) {
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
            this.groupBox_connection = new System.Windows.Forms.GroupBox();
            this.btn_release = new System.Windows.Forms.Button();
            this.btn_initialize = new System.Windows.Forms.Button();
            this.btn_HwRefresh = new System.Windows.Forms.Button();
            this.cbb_vendor = new System.Windows.Forms.ComboBox();
            this.cbb_channel = new System.Windows.Forms.ComboBox();
            this.cbb_baudrates = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_connection.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_connection
            // 
            this.groupBox_connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_connection.Controls.Add(this.btn_release);
            this.groupBox_connection.Controls.Add(this.btn_initialize);
            this.groupBox_connection.Controls.Add(this.btn_HwRefresh);
            this.groupBox_connection.Controls.Add(this.cbb_vendor);
            this.groupBox_connection.Controls.Add(this.cbb_channel);
            this.groupBox_connection.Controls.Add(this.cbb_baudrates);
            this.groupBox_connection.Controls.Add(this.label31);
            this.groupBox_connection.Controls.Add(this.label1);
            this.groupBox_connection.Controls.Add(this.label2);
            this.groupBox_connection.Location = new System.Drawing.Point(12, 12);
            this.groupBox_connection.Name = "groupBox_connection";
            this.groupBox_connection.Size = new System.Drawing.Size(776, 87);
            this.groupBox_connection.TabIndex = 48;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Connection";
            // 
            // btn_release
            // 
            this.btn_release.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_release.Enabled = false;
            this.btn_release.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_release.Location = new System.Drawing.Point(636, 25);
            this.btn_release.Name = "btn_release";
            this.btn_release.Size = new System.Drawing.Size(65, 40);
            this.btn_release.TabIndex = 35;
            this.btn_release.Text = "Release";
            this.btn_release.Click += new System.EventHandler(this.btn_release_Click);
            // 
            // btn_initialize
            // 
            this.btn_initialize.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_initialize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_initialize.Location = new System.Drawing.Point(565, 25);
            this.btn_initialize.Name = "btn_initialize";
            this.btn_initialize.Size = new System.Drawing.Size(65, 40);
            this.btn_initialize.TabIndex = 34;
            this.btn_initialize.Text = "Connect";
            this.btn_initialize.Click += new System.EventHandler(this.btn_initialize_Click);
            // 
            // btn_HwRefresh
            // 
            this.btn_HwRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_HwRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_HwRefresh.Location = new System.Drawing.Point(494, 25);
            this.btn_HwRefresh.Name = "btn_HwRefresh";
            this.btn_HwRefresh.Size = new System.Drawing.Size(65, 40);
            this.btn_HwRefresh.TabIndex = 45;
            this.btn_HwRefresh.Text = "Refresh";
            this.btn_HwRefresh.Click += new System.EventHandler(this.btn_HwRefresh_Click);
            // 
            // cbb_vendor
            // 
            this.cbb_vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_vendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_vendor.Location = new System.Drawing.Point(26, 37);
            this.cbb_vendor.Name = "cbb_vendor";
            this.cbb_vendor.Size = new System.Drawing.Size(154, 21);
            this.cbb_vendor.TabIndex = 32;
            this.cbb_vendor.SelectedIndexChanged += new System.EventHandler(this.cbb_vendor_SelectedIndexChanged);
            // 
            // cbb_channel
            // 
            this.cbb_channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_channel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_channel.Location = new System.Drawing.Point(197, 37);
            this.cbb_channel.Name = "cbb_channel";
            this.cbb_channel.Size = new System.Drawing.Size(119, 21);
            this.cbb_channel.TabIndex = 32;
            this.cbb_channel.SelectedIndexChanged += new System.EventHandler(this.cbb_channel_SelectedIndexChanged);
            // 
            // cbb_baudrates
            // 
            this.cbb_baudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_baudrates.Location = new System.Drawing.Point(325, 37);
            this.cbb_baudrates.Name = "cbb_baudrates";
            this.cbb_baudrates.Size = new System.Drawing.Size(152, 21);
            this.cbb_baudrates.TabIndex = 36;
            this.cbb_baudrates.SelectedIndexChanged += new System.EventHandler(this.cbb_baudrates_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(23, 19);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 15);
            this.label31.TabIndex = 40;
            this.label31.Text = "Vendor";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(194, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 40;
            this.label1.Text = "Channel:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(322, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "Baudrate:";
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_connection);
            this.Name = "SimpleTest";
            this.Text = "Form1";
            this.groupBox_connection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_connection;
        private System.Windows.Forms.Button btn_release;
        private System.Windows.Forms.Button btn_initialize;
        private System.Windows.Forms.Button btn_HwRefresh;
        private System.Windows.Forms.ComboBox cbb_vendor;
        private System.Windows.Forms.ComboBox cbb_channel;
        private System.Windows.Forms.ComboBox cbb_baudrates;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}



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
            this.components = new System.ComponentModel.Container();
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
            this.label_stateMotorOne = new System.Windows.Forms.Label();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.label_dcLinkMotorOne = new System.Windows.Forms.Label();
            this.button_EnableMotorOne = new System.Windows.Forms.Button();
            this.button_DisableMotorOne = new System.Windows.Forms.Button();
            this.button_SwitchOnMotorOne = new System.Windows.Forms.Button();
            this.button_SwitchOffMotorOne = new System.Windows.Forms.Button();
            this.button_ResetNodes = new System.Windows.Forms.Button();
            this.button_ResetComms = new System.Windows.Forms.Button();
            this.button_ReadyMotorOne = new System.Windows.Forms.Button();
            this.cbb_ModeOfOperation = new System.Windows.Forms.ComboBox();
            this.label_ModeOfOperation = new System.Windows.Forms.Label();
            this.button_SetMode = new System.Windows.Forms.Button();
            this.textBox_targetVelocity = new System.Windows.Forms.TextBox();
            this.button_setTargetVelocity = new System.Windows.Forms.Button();
            this.groupBox_MotorOne = new System.Windows.Forms.GroupBox();
            this.groupBox_ProfileVelocity = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_actualSpeedMotorOne = new System.Windows.Forms.Label();
            this.label_actualCurrentMotorOne = new System.Windows.Forms.Label();
            this.label_actualPositionMotorOne = new System.Windows.Forms.Label();
            this.button_clearFaultMotorOne = new System.Windows.Forms.Button();
            this.groupBox_connection.SuspendLayout();
            this.groupBox_MotorOne.SuspendLayout();
            this.groupBox_ProfileVelocity.SuspendLayout();
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
            this.groupBox_connection.Size = new System.Drawing.Size(776, 77);
            this.groupBox_connection.TabIndex = 48;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Connection";
            // 
            // btn_release
            // 
            this.btn_release.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_release.Enabled = false;
            this.btn_release.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_release.Location = new System.Drawing.Point(679, 21);
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
            this.btn_initialize.Location = new System.Drawing.Point(608, 21);
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
            this.btn_HwRefresh.Location = new System.Drawing.Point(537, 21);
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
            this.cbb_vendor.Size = new System.Drawing.Size(165, 21);
            this.cbb_vendor.TabIndex = 32;
            this.cbb_vendor.SelectedIndexChanged += new System.EventHandler(this.cbb_vendor_SelectedIndexChanged);
            // 
            // cbb_channel
            // 
            this.cbb_channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_channel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_channel.Location = new System.Drawing.Point(197, 37);
            this.cbb_channel.Name = "cbb_channel";
            this.cbb_channel.Size = new System.Drawing.Size(153, 21);
            this.cbb_channel.TabIndex = 32;
            this.cbb_channel.SelectedIndexChanged += new System.EventHandler(this.cbb_channel_SelectedIndexChanged);
            // 
            // cbb_baudrates
            // 
            this.cbb_baudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_baudrates.Location = new System.Drawing.Point(356, 37);
            this.cbb_baudrates.Name = "cbb_baudrates";
            this.cbb_baudrates.Size = new System.Drawing.Size(170, 21);
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
            this.label2.Location = new System.Drawing.Point(353, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "Baudrate:";
            // 
            // label_stateMotorOne
            // 
            this.label_stateMotorOne.AutoSize = true;
            this.label_stateMotorOne.Location = new System.Drawing.Point(22, 30);
            this.label_stateMotorOne.Name = "label_stateMotorOne";
            this.label_stateMotorOne.Size = new System.Drawing.Size(44, 13);
            this.label_stateMotorOne.TabIndex = 49;
            this.label_stateMotorOne.Text = "State: --";
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // label_dcLinkMotorOne
            // 
            this.label_dcLinkMotorOne.AutoSize = true;
            this.label_dcLinkMotorOne.Location = new System.Drawing.Point(9, 72);
            this.label_dcLinkMotorOne.Name = "label_dcLinkMotorOne";
            this.label_dcLinkMotorOne.Size = new System.Drawing.Size(57, 13);
            this.label_dcLinkMotorOne.TabIndex = 50;
            this.label_dcLinkMotorOne.Text = "DC Link: --";
            // 
            // button_EnableMotorOne
            // 
            this.button_EnableMotorOne.Location = new System.Drawing.Point(207, 198);
            this.button_EnableMotorOne.Name = "button_EnableMotorOne";
            this.button_EnableMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_EnableMotorOne.TabIndex = 51;
            this.button_EnableMotorOne.Text = "Enable";
            this.button_EnableMotorOne.UseVisualStyleBackColor = true;
            this.button_EnableMotorOne.Click += new System.EventHandler(this.button_EnableMotorOne_Click);
            // 
            // button_DisableMotorOne
            // 
            this.button_DisableMotorOne.Location = new System.Drawing.Point(207, 235);
            this.button_DisableMotorOne.Name = "button_DisableMotorOne";
            this.button_DisableMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_DisableMotorOne.TabIndex = 51;
            this.button_DisableMotorOne.Text = "Disable";
            this.button_DisableMotorOne.UseVisualStyleBackColor = true;
            this.button_DisableMotorOne.Click += new System.EventHandler(this.button_DisableMotorOne_Click);
            // 
            // button_SwitchOnMotorOne
            // 
            this.button_SwitchOnMotorOne.Location = new System.Drawing.Point(207, 127);
            this.button_SwitchOnMotorOne.Name = "button_SwitchOnMotorOne";
            this.button_SwitchOnMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_SwitchOnMotorOne.TabIndex = 51;
            this.button_SwitchOnMotorOne.Text = "Swtich ON";
            this.button_SwitchOnMotorOne.UseVisualStyleBackColor = true;
            this.button_SwitchOnMotorOne.Click += new System.EventHandler(this.button_SwitchOnMotorOne_Click);
            // 
            // button_SwitchOffMotorOne
            // 
            this.button_SwitchOffMotorOne.Location = new System.Drawing.Point(207, 164);
            this.button_SwitchOffMotorOne.Name = "button_SwitchOffMotorOne";
            this.button_SwitchOffMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_SwitchOffMotorOne.TabIndex = 51;
            this.button_SwitchOffMotorOne.Text = "Swtich OFF";
            this.button_SwitchOffMotorOne.UseVisualStyleBackColor = true;
            this.button_SwitchOffMotorOne.Click += new System.EventHandler(this.button_SwitchOffMotorOne_Click);
            // 
            // button_ResetNodes
            // 
            this.button_ResetNodes.Location = new System.Drawing.Point(207, 19);
            this.button_ResetNodes.Name = "button_ResetNodes";
            this.button_ResetNodes.Size = new System.Drawing.Size(127, 31);
            this.button_ResetNodes.TabIndex = 51;
            this.button_ResetNodes.Text = "Reset Node";
            this.button_ResetNodes.UseVisualStyleBackColor = true;
            this.button_ResetNodes.Click += new System.EventHandler(this.button_ResetNodes_Click);
            // 
            // button_ResetComms
            // 
            this.button_ResetComms.Location = new System.Drawing.Point(207, 53);
            this.button_ResetComms.Name = "button_ResetComms";
            this.button_ResetComms.Size = new System.Drawing.Size(127, 31);
            this.button_ResetComms.TabIndex = 51;
            this.button_ResetComms.Text = "Reset Communication";
            this.button_ResetComms.UseVisualStyleBackColor = true;
            this.button_ResetComms.Click += new System.EventHandler(this.button_ResetComms_Click);
            // 
            // button_ReadyMotorOne
            // 
            this.button_ReadyMotorOne.Location = new System.Drawing.Point(207, 90);
            this.button_ReadyMotorOne.Name = "button_ReadyMotorOne";
            this.button_ReadyMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_ReadyMotorOne.TabIndex = 51;
            this.button_ReadyMotorOne.Text = "Ready";
            this.button_ReadyMotorOne.UseVisualStyleBackColor = true;
            this.button_ReadyMotorOne.Click += new System.EventHandler(this.button_ReadyMotorOne_Click);
            // 
            // cbb_ModeOfOperation
            // 
            this.cbb_ModeOfOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_ModeOfOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ModeOfOperation.Location = new System.Drawing.Point(12, 278);
            this.cbb_ModeOfOperation.Name = "cbb_ModeOfOperation";
            this.cbb_ModeOfOperation.Size = new System.Drawing.Size(181, 21);
            this.cbb_ModeOfOperation.TabIndex = 32;
            // 
            // label_ModeOfOperation
            // 
            this.label_ModeOfOperation.AutoSize = true;
            this.label_ModeOfOperation.Location = new System.Drawing.Point(20, 51);
            this.label_ModeOfOperation.Name = "label_ModeOfOperation";
            this.label_ModeOfOperation.Size = new System.Drawing.Size(46, 13);
            this.label_ModeOfOperation.TabIndex = 49;
            this.label_ModeOfOperation.Text = "Mode: --";
            // 
            // button_SetMode
            // 
            this.button_SetMode.Location = new System.Drawing.Point(207, 272);
            this.button_SetMode.Name = "button_SetMode";
            this.button_SetMode.Size = new System.Drawing.Size(127, 31);
            this.button_SetMode.TabIndex = 52;
            this.button_SetMode.Text = "Set Mode";
            this.button_SetMode.UseVisualStyleBackColor = true;
            this.button_SetMode.Click += new System.EventHandler(this.button_SetMode_Click);
            // 
            // textBox_targetVelocity
            // 
            this.textBox_targetVelocity.Location = new System.Drawing.Point(93, 25);
            this.textBox_targetVelocity.Name = "textBox_targetVelocity";
            this.textBox_targetVelocity.Size = new System.Drawing.Size(50, 20);
            this.textBox_targetVelocity.TabIndex = 53;
            this.textBox_targetVelocity.Text = "3000";
            // 
            // button_setTargetVelocity
            // 
            this.button_setTargetVelocity.Location = new System.Drawing.Point(9, 54);
            this.button_setTargetVelocity.Name = "button_setTargetVelocity";
            this.button_setTargetVelocity.Size = new System.Drawing.Size(134, 33);
            this.button_setTargetVelocity.TabIndex = 54;
            this.button_setTargetVelocity.Text = "Set Target Velocity";
            this.button_setTargetVelocity.UseVisualStyleBackColor = true;
            this.button_setTargetVelocity.Click += new System.EventHandler(this.button_setTargetVelocity_Click);
            // 
            // groupBox_MotorOne
            // 
            this.groupBox_MotorOne.Controls.Add(this.button_clearFaultMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.label_actualCurrentMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.label_actualPositionMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.label_actualSpeedMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.groupBox_ProfileVelocity);
            this.groupBox_MotorOne.Controls.Add(this.label_stateMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.label_ModeOfOperation);
            this.groupBox_MotorOne.Controls.Add(this.label_dcLinkMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.button_SetMode);
            this.groupBox_MotorOne.Controls.Add(this.button_ResetNodes);
            this.groupBox_MotorOne.Controls.Add(this.cbb_ModeOfOperation);
            this.groupBox_MotorOne.Controls.Add(this.button_SwitchOffMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.button_DisableMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.button_ResetComms);
            this.groupBox_MotorOne.Controls.Add(this.button_EnableMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.button_SwitchOnMotorOne);
            this.groupBox_MotorOne.Controls.Add(this.button_ReadyMotorOne);
            this.groupBox_MotorOne.Enabled = false;
            this.groupBox_MotorOne.Location = new System.Drawing.Point(12, 95);
            this.groupBox_MotorOne.Name = "groupBox_MotorOne";
            this.groupBox_MotorOne.Size = new System.Drawing.Size(354, 350);
            this.groupBox_MotorOne.TabIndex = 55;
            this.groupBox_MotorOne.TabStop = false;
            this.groupBox_MotorOne.Text = "AXLE 1";
            // 
            // groupBox_ProfileVelocity
            // 
            this.groupBox_ProfileVelocity.Controls.Add(this.label3);
            this.groupBox_ProfileVelocity.Controls.Add(this.textBox_targetVelocity);
            this.groupBox_ProfileVelocity.Controls.Add(this.button_setTargetVelocity);
            this.groupBox_ProfileVelocity.Enabled = false;
            this.groupBox_ProfileVelocity.Location = new System.Drawing.Point(31, 162);
            this.groupBox_ProfileVelocity.Name = "groupBox_ProfileVelocity";
            this.groupBox_ProfileVelocity.Size = new System.Drawing.Size(160, 104);
            this.groupBox_ProfileVelocity.TabIndex = 53;
            this.groupBox_ProfileVelocity.TabStop = false;
            this.groupBox_ProfileVelocity.Text = "Profile Velocity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Target Velocity:";
            // 
            // label_actualSpeedMotorOne
            // 
            this.label_actualSpeedMotorOne.AutoSize = true;
            this.label_actualSpeedMotorOne.Location = new System.Drawing.Point(16, 114);
            this.label_actualSpeedMotorOne.Name = "label_actualSpeedMotorOne";
            this.label_actualSpeedMotorOne.Size = new System.Drawing.Size(50, 13);
            this.label_actualSpeedMotorOne.TabIndex = 54;
            this.label_actualSpeedMotorOne.Text = "Speed: --";
            // 
            // label_actualCurrentMotorOne
            // 
            this.label_actualCurrentMotorOne.AutoSize = true;
            this.label_actualCurrentMotorOne.Location = new System.Drawing.Point(13, 135);
            this.label_actualCurrentMotorOne.Name = "label_actualCurrentMotorOne";
            this.label_actualCurrentMotorOne.Size = new System.Drawing.Size(53, 13);
            this.label_actualCurrentMotorOne.TabIndex = 54;
            this.label_actualCurrentMotorOne.Text = "Current: --";
            // 
            // label_actualPositionMotorOne
            // 
            this.label_actualPositionMotorOne.AutoSize = true;
            this.label_actualPositionMotorOne.Location = new System.Drawing.Point(10, 93);
            this.label_actualPositionMotorOne.Name = "label_actualPositionMotorOne";
            this.label_actualPositionMotorOne.Size = new System.Drawing.Size(56, 13);
            this.label_actualPositionMotorOne.TabIndex = 54;
            this.label_actualPositionMotorOne.Text = "Position: --";
            // 
            // button_clearFaultMotorOne
            // 
            this.button_clearFaultMotorOne.Location = new System.Drawing.Point(207, 309);
            this.button_clearFaultMotorOne.Name = "button_clearFaultMotorOne";
            this.button_clearFaultMotorOne.Size = new System.Drawing.Size(127, 31);
            this.button_clearFaultMotorOne.TabIndex = 55;
            this.button_clearFaultMotorOne.Text = "Clear Fault";
            this.button_clearFaultMotorOne.UseVisualStyleBackColor = true;
            this.button_clearFaultMotorOne.Click += new System.EventHandler(this.button_clearFaultMotorOne_Click);
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.groupBox_MotorOne);
            this.Controls.Add(this.groupBox_connection);
            this.Name = "SimpleTest";
            this.Text = "Form1";
            this.groupBox_connection.ResumeLayout(false);
            this.groupBox_MotorOne.ResumeLayout(false);
            this.groupBox_MotorOne.PerformLayout();
            this.groupBox_ProfileVelocity.ResumeLayout(false);
            this.groupBox_ProfileVelocity.PerformLayout();
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
        private System.Windows.Forms.Label label_stateMotorOne;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.Label label_dcLinkMotorOne;
        private System.Windows.Forms.Button button_EnableMotorOne;
        private System.Windows.Forms.Button button_DisableMotorOne;
        private System.Windows.Forms.Button button_SwitchOnMotorOne;
        private System.Windows.Forms.Button button_SwitchOffMotorOne;
        private System.Windows.Forms.Button button_ResetNodes;
        private System.Windows.Forms.Button button_ResetComms;
        private System.Windows.Forms.Button button_ReadyMotorOne;
        private System.Windows.Forms.ComboBox cbb_ModeOfOperation;
        private System.Windows.Forms.Label label_ModeOfOperation;
        private System.Windows.Forms.Button button_SetMode;
        private System.Windows.Forms.TextBox textBox_targetVelocity;
        private System.Windows.Forms.Button button_setTargetVelocity;
        private System.Windows.Forms.GroupBox groupBox_MotorOne;
        private System.Windows.Forms.GroupBox groupBox_ProfileVelocity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_actualSpeedMotorOne;
        private System.Windows.Forms.Label label_actualCurrentMotorOne;
        private System.Windows.Forms.Label label_actualPositionMotorOne;
        private System.Windows.Forms.Button button_clearFaultMotorOne;
    }
}


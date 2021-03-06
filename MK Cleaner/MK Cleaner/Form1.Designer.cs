﻿namespace MK_Cleaner
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.P_Main = new System.Windows.Forms.Panel();
            this.P_CustomSettings = new System.Windows.Forms.Panel();
            this.NUpD_HLNetworkLicense = new System.Windows.Forms.NumericUpDown();
            this.NUpD_SLNetworkLicense = new System.Windows.Forms.NumericUpDown();
            this.NUpD_LocalLicense = new System.Windows.Forms.NumericUpDown();
            this.CB_UnlockedTrialware = new System.Windows.Forms.CheckBox();
            this.L_HLNetworkLicense = new System.Windows.Forms.Label();
            this.L_SLNetworkLicense = new System.Windows.Forms.Label();
            this.L_LocalLicense = new System.Windows.Forms.Label();
            this.RB_Custom = new System.Windows.Forms.RadioButton();
            this.RB_DefaultHL = new System.Windows.Forms.RadioButton();
            this.RB_DefaultSL = new System.Windows.Forms.RadioButton();
            this.RB_DefaultMix = new System.Windows.Forms.RadioButton();
            this.L_CleanSettings = new System.Windows.Forms.Label();
            this.L_Logs = new System.Windows.Forms.Label();
            this.TB_Logs = new System.Windows.Forms.TextBox();
            this.P_Bottom = new System.Windows.Forms.Panel();
            this.B_BrowsePathToHLC2V = new System.Windows.Forms.Button();
            this.TB_PathToHLC2V = new System.Windows.Forms.TextBox();
            this.L_HLC2V = new System.Windows.Forms.Label();
            this.B_BrowsePathToVendorCode = new System.Windows.Forms.Button();
            this.B_Start = new System.Windows.Forms.Button();
            this.TB_PathToVendorCode = new System.Windows.Forms.TextBox();
            this.L_VendorCode = new System.Windows.Forms.Label();
            this.TT_WhyNeedPathToHLC2V = new System.Windows.Forms.ToolTip(this.components);
            this.P_Main.SuspendLayout();
            this.P_CustomSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_HLNetworkLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_SLNetworkLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_LocalLicense)).BeginInit();
            this.P_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Main
            // 
            this.P_Main.BackColor = System.Drawing.Color.LightGray;
            this.P_Main.Controls.Add(this.P_CustomSettings);
            this.P_Main.Controls.Add(this.RB_Custom);
            this.P_Main.Controls.Add(this.RB_DefaultHL);
            this.P_Main.Controls.Add(this.RB_DefaultSL);
            this.P_Main.Controls.Add(this.RB_DefaultMix);
            this.P_Main.Controls.Add(this.L_CleanSettings);
            this.P_Main.Controls.Add(this.L_Logs);
            this.P_Main.Controls.Add(this.TB_Logs);
            this.P_Main.Controls.Add(this.P_Bottom);
            this.P_Main.Location = new System.Drawing.Point(0, 0);
            this.P_Main.Name = "P_Main";
            this.P_Main.Size = new System.Drawing.Size(490, 290);
            this.P_Main.TabIndex = 1;
            // 
            // P_CustomSettings
            // 
            this.P_CustomSettings.BackColor = System.Drawing.Color.LightGray;
            this.P_CustomSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P_CustomSettings.Controls.Add(this.NUpD_HLNetworkLicense);
            this.P_CustomSettings.Controls.Add(this.NUpD_SLNetworkLicense);
            this.P_CustomSettings.Controls.Add(this.NUpD_LocalLicense);
            this.P_CustomSettings.Controls.Add(this.CB_UnlockedTrialware);
            this.P_CustomSettings.Controls.Add(this.L_HLNetworkLicense);
            this.P_CustomSettings.Controls.Add(this.L_SLNetworkLicense);
            this.P_CustomSettings.Controls.Add(this.L_LocalLicense);
            this.P_CustomSettings.Location = new System.Drawing.Point(289, 20);
            this.P_CustomSettings.Name = "P_CustomSettings";
            this.P_CustomSettings.Size = new System.Drawing.Size(183, 100);
            this.P_CustomSettings.TabIndex = 8;
            // 
            // NUpD_HLNetworkLicense
            // 
            this.NUpD_HLNetworkLicense.Location = new System.Drawing.Point(111, 55);
            this.NUpD_HLNetworkLicense.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUpD_HLNetworkLicense.Name = "NUpD_HLNetworkLicense";
            this.NUpD_HLNetworkLicense.Size = new System.Drawing.Size(60, 20);
            this.NUpD_HLNetworkLicense.TabIndex = 6;
            this.NUpD_HLNetworkLicense.ValueChanged += new System.EventHandler(this.NUpD_HLNetworkLicense_ValueChanged);
            // 
            // NUpD_SLNetworkLicense
            // 
            this.NUpD_SLNetworkLicense.Location = new System.Drawing.Point(111, 29);
            this.NUpD_SLNetworkLicense.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUpD_SLNetworkLicense.Name = "NUpD_SLNetworkLicense";
            this.NUpD_SLNetworkLicense.Size = new System.Drawing.Size(60, 20);
            this.NUpD_SLNetworkLicense.TabIndex = 5;
            this.NUpD_SLNetworkLicense.ValueChanged += new System.EventHandler(this.NUpD_SLNetworkLicense_ValueChanged);
            // 
            // NUpD_LocalLicense
            // 
            this.NUpD_LocalLicense.Location = new System.Drawing.Point(111, 3);
            this.NUpD_LocalLicense.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUpD_LocalLicense.Name = "NUpD_LocalLicense";
            this.NUpD_LocalLicense.Size = new System.Drawing.Size(60, 20);
            this.NUpD_LocalLicense.TabIndex = 4;
            this.NUpD_LocalLicense.ValueChanged += new System.EventHandler(this.NUpD_LocalLicense_ValueChanged);
            // 
            // CB_UnlockedTrialware
            // 
            this.CB_UnlockedTrialware.AutoSize = true;
            this.CB_UnlockedTrialware.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_UnlockedTrialware.Location = new System.Drawing.Point(2, 80);
            this.CB_UnlockedTrialware.Name = "CB_UnlockedTrialware";
            this.CB_UnlockedTrialware.Size = new System.Drawing.Size(166, 17);
            this.CB_UnlockedTrialware.TabIndex = 3;
            this.CB_UnlockedTrialware.Text = "Unlocked Trialware license:   ";
            this.CB_UnlockedTrialware.UseVisualStyleBackColor = true;
            this.CB_UnlockedTrialware.CheckedChanged += new System.EventHandler(this.CB_UnlockedTrialware_CheckedChanged);
            // 
            // L_HLNetworkLicense
            // 
            this.L_HLNetworkLicense.AutoSize = true;
            this.L_HLNetworkLicense.Location = new System.Drawing.Point(3, 57);
            this.L_HLNetworkLicense.Name = "L_HLNetworkLicense";
            this.L_HLNetworkLicense.Size = new System.Drawing.Size(103, 13);
            this.L_HLNetworkLicense.TabIndex = 2;
            this.L_HLNetworkLicense.Text = "HL Network license:";
            // 
            // L_SLNetworkLicense
            // 
            this.L_SLNetworkLicense.AutoSize = true;
            this.L_SLNetworkLicense.Location = new System.Drawing.Point(3, 31);
            this.L_SLNetworkLicense.Name = "L_SLNetworkLicense";
            this.L_SLNetworkLicense.Size = new System.Drawing.Size(102, 13);
            this.L_SLNetworkLicense.TabIndex = 1;
            this.L_SLNetworkLicense.Text = "SL Network license:";
            // 
            // L_LocalLicense
            // 
            this.L_LocalLicense.AutoSize = true;
            this.L_LocalLicense.Location = new System.Drawing.Point(3, 5);
            this.L_LocalLicense.Name = "L_LocalLicense";
            this.L_LocalLicense.Size = new System.Drawing.Size(75, 13);
            this.L_LocalLicense.TabIndex = 0;
            this.L_LocalLicense.Text = "Local license: ";
            // 
            // RB_Custom
            // 
            this.RB_Custom.AutoSize = true;
            this.RB_Custom.Location = new System.Drawing.Point(30, 89);
            this.RB_Custom.Name = "RB_Custom";
            this.RB_Custom.Size = new System.Drawing.Size(60, 17);
            this.RB_Custom.TabIndex = 7;
            this.RB_Custom.Text = "Custom";
            this.RB_Custom.UseVisualStyleBackColor = true;
            this.RB_Custom.CheckedChanged += new System.EventHandler(this.RB_Custom_CheckedChanged);
            // 
            // RB_DefaultHL
            // 
            this.RB_DefaultHL.AutoSize = true;
            this.RB_DefaultHL.Location = new System.Drawing.Point(30, 66);
            this.RB_DefaultHL.Name = "RB_DefaultHL";
            this.RB_DefaultHL.Size = new System.Drawing.Size(185, 17);
            this.RB_DefaultHL.TabIndex = 6;
            this.RB_DefaultHL.Text = "Default HL ({zz} network licenses)";
            this.RB_DefaultHL.UseVisualStyleBackColor = true;
            this.RB_DefaultHL.CheckedChanged += new System.EventHandler(this.RB_DefaultHL_CheckedChanged);
            // 
            // RB_DefaultSL
            // 
            this.RB_DefaultSL.AutoSize = true;
            this.RB_DefaultSL.Location = new System.Drawing.Point(30, 43);
            this.RB_DefaultSL.Name = "RB_DefaultSL";
            this.RB_DefaultSL.Size = new System.Drawing.Size(232, 17);
            this.RB_DefaultSL.TabIndex = 5;
            this.RB_DefaultSL.Text = "Default SL ({xx} local/{yy} network licenses)";
            this.RB_DefaultSL.UseVisualStyleBackColor = true;
            this.RB_DefaultSL.CheckedChanged += new System.EventHandler(this.RB_DefaultSL_CheckedChanged);
            // 
            // RB_DefaultMix
            // 
            this.RB_DefaultMix.AutoSize = true;
            this.RB_DefaultMix.Checked = true;
            this.RB_DefaultMix.Location = new System.Drawing.Point(30, 20);
            this.RB_DefaultMix.Name = "RB_DefaultMix";
            this.RB_DefaultMix.Size = new System.Drawing.Size(260, 17);
            this.RB_DefaultMix.TabIndex = 4;
            this.RB_DefaultMix.TabStop = true;
            this.RB_DefaultMix.Text = "Default Mix (SL: {xx}/{yy} + HL: {zz} + Provisional)";
            this.RB_DefaultMix.UseVisualStyleBackColor = true;
            this.RB_DefaultMix.CheckedChanged += new System.EventHandler(this.RB_DefaultMix_CheckedChanged);
            // 
            // L_CleanSettings
            // 
            this.L_CleanSettings.AutoSize = true;
            this.L_CleanSettings.Location = new System.Drawing.Point(12, 3);
            this.L_CleanSettings.Name = "L_CleanSettings";
            this.L_CleanSettings.Size = new System.Drawing.Size(76, 13);
            this.L_CleanSettings.TabIndex = 3;
            this.L_CleanSettings.Text = "Clean settings:";
            // 
            // L_Logs
            // 
            this.L_Logs.AutoSize = true;
            this.L_Logs.Location = new System.Drawing.Point(12, 113);
            this.L_Logs.Name = "L_Logs";
            this.L_Logs.Size = new System.Drawing.Size(33, 13);
            this.L_Logs.TabIndex = 2;
            this.L_Logs.Text = "Logs:";
            // 
            // TB_Logs
            // 
            this.TB_Logs.Location = new System.Drawing.Point(12, 129);
            this.TB_Logs.Multiline = true;
            this.TB_Logs.Name = "TB_Logs";
            this.TB_Logs.ReadOnly = true;
            this.TB_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Logs.Size = new System.Drawing.Size(460, 60);
            this.TB_Logs.TabIndex = 1;
            this.TB_Logs.TextChanged += new System.EventHandler(this.TB_Logs_TextChanged);
            // 
            // P_Bottom
            // 
            this.P_Bottom.BackColor = System.Drawing.Color.DimGray;
            this.P_Bottom.Controls.Add(this.B_BrowsePathToHLC2V);
            this.P_Bottom.Controls.Add(this.TB_PathToHLC2V);
            this.P_Bottom.Controls.Add(this.L_HLC2V);
            this.P_Bottom.Controls.Add(this.B_BrowsePathToVendorCode);
            this.P_Bottom.Controls.Add(this.B_Start);
            this.P_Bottom.Controls.Add(this.TB_PathToVendorCode);
            this.P_Bottom.Controls.Add(this.L_VendorCode);
            this.P_Bottom.Location = new System.Drawing.Point(0, 195);
            this.P_Bottom.Name = "P_Bottom";
            this.P_Bottom.Size = new System.Drawing.Size(490, 80);
            this.P_Bottom.TabIndex = 0;
            // 
            // B_BrowsePathToHLC2V
            // 
            this.B_BrowsePathToHLC2V.BackColor = System.Drawing.Color.Red;
            this.B_BrowsePathToHLC2V.Location = new System.Drawing.Point(360, 43);
            this.B_BrowsePathToHLC2V.Name = "B_BrowsePathToHLC2V";
            this.B_BrowsePathToHLC2V.Size = new System.Drawing.Size(30, 22);
            this.B_BrowsePathToHLC2V.TabIndex = 6;
            this.B_BrowsePathToHLC2V.Text = "...";
            this.TT_WhyNeedPathToHLC2V.SetToolTip(this.B_BrowsePathToHLC2V, resources.GetString("B_BrowsePathToHLC2V.ToolTip"));
            this.B_BrowsePathToHLC2V.UseVisualStyleBackColor = false;
            this.B_BrowsePathToHLC2V.Click += new System.EventHandler(this.B_BrowsePathToHLC2V_Click);
            // 
            // TB_PathToHLC2V
            // 
            this.TB_PathToHLC2V.Location = new System.Drawing.Point(120, 44);
            this.TB_PathToHLC2V.Name = "TB_PathToHLC2V";
            this.TB_PathToHLC2V.ReadOnly = true;
            this.TB_PathToHLC2V.Size = new System.Drawing.Size(240, 20);
            this.TB_PathToHLC2V.TabIndex = 5;
            // 
            // L_HLC2V
            // 
            this.L_HLC2V.AutoSize = true;
            this.L_HLC2V.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.L_HLC2V.Location = new System.Drawing.Point(12, 47);
            this.L_HLC2V.Name = "L_HLC2V";
            this.L_HLC2V.Size = new System.Drawing.Size(102, 13);
            this.L_HLC2V.TabIndex = 4;
            this.L_HLC2V.Text = "HL (Driverless) C2V:";
            // 
            // B_BrowsePathToVendorCode
            // 
            this.B_BrowsePathToVendorCode.BackColor = System.Drawing.Color.Red;
            this.B_BrowsePathToVendorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_BrowsePathToVendorCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_BrowsePathToVendorCode.Location = new System.Drawing.Point(360, 8);
            this.B_BrowsePathToVendorCode.Name = "B_BrowsePathToVendorCode";
            this.B_BrowsePathToVendorCode.Size = new System.Drawing.Size(30, 22);
            this.B_BrowsePathToVendorCode.TabIndex = 3;
            this.B_BrowsePathToVendorCode.Text = "...";
            this.B_BrowsePathToVendorCode.UseVisualStyleBackColor = false;
            this.B_BrowsePathToVendorCode.Click += new System.EventHandler(this.B_BrowsePathToVendorCode_Click);
            // 
            // B_Start
            // 
            this.B_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Start.Location = new System.Drawing.Point(397, 8);
            this.B_Start.Name = "B_Start";
            this.B_Start.Size = new System.Drawing.Size(75, 22);
            this.B_Start.TabIndex = 2;
            this.B_Start.Text = "Start";
            this.B_Start.UseVisualStyleBackColor = true;
            this.B_Start.Click += new System.EventHandler(this.B_Start_Click);
            // 
            // TB_PathToVendorCode
            // 
            this.TB_PathToVendorCode.Location = new System.Drawing.Point(90, 9);
            this.TB_PathToVendorCode.Name = "TB_PathToVendorCode";
            this.TB_PathToVendorCode.ReadOnly = true;
            this.TB_PathToVendorCode.Size = new System.Drawing.Size(270, 20);
            this.TB_PathToVendorCode.TabIndex = 1;
            // 
            // L_VendorCode
            // 
            this.L_VendorCode.AutoSize = true;
            this.L_VendorCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.L_VendorCode.Location = new System.Drawing.Point(12, 12);
            this.L_VendorCode.Name = "L_VendorCode";
            this.L_VendorCode.Size = new System.Drawing.Size(72, 13);
            this.L_VendorCode.TabIndex = 0;
            this.L_VendorCode.Text = "Vendor Code:";
            // 
            // TT_WhyNeedPathToHLC2V
            // 
            this.TT_WhyNeedPathToHLC2V.AutoPopDelay = 30000;
            this.TT_WhyNeedPathToHLC2V.InitialDelay = 500;
            this.TT_WhyNeedPathToHLC2V.ReshowDelay = 100;
            this.TT_WhyNeedPathToHLC2V.ToolTipTitle = "Why we need to provide HL C2V?";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 264);
            this.Controls.Add(this.P_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(498, 303);
            this.MinimumSize = new System.Drawing.Size(498, 303);
            this.Name = "Form_Main";
            this.Text = "MK Cleaner {vv}";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.P_Main.ResumeLayout(false);
            this.P_Main.PerformLayout();
            this.P_CustomSettings.ResumeLayout(false);
            this.P_CustomSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_HLNetworkLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_SLNetworkLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpD_LocalLicense)).EndInit();
            this.P_Bottom.ResumeLayout(false);
            this.P_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel P_Main;
        private System.Windows.Forms.Panel P_CustomSettings;
        private System.Windows.Forms.RadioButton RB_Custom;
        private System.Windows.Forms.RadioButton RB_DefaultHL;
        private System.Windows.Forms.RadioButton RB_DefaultSL;
        private System.Windows.Forms.RadioButton RB_DefaultMix;
        private System.Windows.Forms.Label L_CleanSettings;
        private System.Windows.Forms.Label L_Logs;
        private System.Windows.Forms.TextBox TB_Logs;
        private System.Windows.Forms.Panel P_Bottom;
        private System.Windows.Forms.Button B_BrowsePathToVendorCode;
        private System.Windows.Forms.Button B_Start;
        private System.Windows.Forms.TextBox TB_PathToVendorCode;
        private System.Windows.Forms.Label L_VendorCode;
        private System.Windows.Forms.NumericUpDown NUpD_HLNetworkLicense;
        private System.Windows.Forms.NumericUpDown NUpD_SLNetworkLicense;
        private System.Windows.Forms.NumericUpDown NUpD_LocalLicense;
        private System.Windows.Forms.CheckBox CB_UnlockedTrialware;
        private System.Windows.Forms.Label L_HLNetworkLicense;
        private System.Windows.Forms.Label L_SLNetworkLicense;
        private System.Windows.Forms.Label L_LocalLicense;
        private System.Windows.Forms.Button B_BrowsePathToHLC2V;
        private System.Windows.Forms.TextBox TB_PathToHLC2V;
        private System.Windows.Forms.Label L_HLC2V;
        private System.Windows.Forms.ToolTip TT_WhyNeedPathToHLC2V;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sentinel.Ldk;
using Sentinel.Ldk.LicGen;

namespace MK_Cleaner
{
    public partial class Form_Main : Form
    {
        public static string ProgramVersion = "3.0";
        public string InitParam = null;
        public LicGenAPIHelper LicGenHelper = new LicGenAPIHelper();
        public sntl_lg_status_t Status;
        public int LocalActivation, NetworkActivationSL, NetworkActivationHL, s4_1;
        public static int defaultNumberOfLic = 15;
        public bool UnlockedTrialware;
        public string VendorCode = "";
        public string CurrentStateForHL = "";
        public string CurrentStateForSL = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                        "<hasp_info>" +
                                        "<host_fingerprint type=\"SL-AdminMode\" crc=\"4060457780\">MXhJSYlRKl9ihkHMmHXkZgmNukfG5ERNBEUErJqPHzuKqJylWSUTEBE3bjWDwAsAUROGmfYmd0cKB3MlcRGqViaKRiUR</host_fingerprint>" +
                                        "</hasp_info>";

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("{vv}", ProgramVersion);
            RB_DefaultMix.Text = RB_DefaultMix.Text.Replace("{xx}", defaultNumberOfLic.ToString());
            RB_DefaultMix.Text = RB_DefaultMix.Text.Replace("{yy}", defaultNumberOfLic.ToString());
            RB_DefaultMix.Text = RB_DefaultMix.Text.Replace("{zz}", defaultNumberOfLic.ToString());
            RB_DefaultSL.Text = RB_DefaultSL.Text.Replace("{xx}", defaultNumberOfLic.ToString());
            RB_DefaultSL.Text = RB_DefaultSL.Text.Replace("{yy}", defaultNumberOfLic.ToString());
            RB_DefaultHL.Text = RB_DefaultHL.Text.Replace("{zz}", defaultNumberOfLic.ToString());

            P_CustomSettings.Visible = false;
            B_Start.Enabled = false;
            LocalActivation = defaultNumberOfLic;
            NetworkActivationSL = defaultNumberOfLic;
            NetworkActivationHL = defaultNumberOfLic;
            UnlockedTrialware = true;

            Status = LicGenHelper.sntl_lg_initialize(InitParam);
            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
                TB_Logs.Text = TB_Logs.Text + "LicGen API initialization error: " + Status;
            }
            else
            {
                TB_Logs.Text = TB_Logs.Text + "LicGen API initialization is successfully.";
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Status = LicGenHelper.sntl_lg_cleanup();
            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
            }
        }

        private void TB_Logs_TextChanged(object sender, EventArgs e)
        {
            TB_Logs.SelectionStart = TB_Logs.Text.Length;
            TB_Logs.ScrollToCaret();
        }

        private void NUpD_LocalLicense_ValueChanged(object sender, EventArgs e)
        {
            LocalActivation = Convert.ToInt32(NUpD_LocalLicense.Value);

            if (LocalActivation < 1 && NetworkActivationSL > 0)
            {
                NetworkActivationSL = 0;
                NUpD_SLNetworkLicense.Value = 0;
            }
        }

        private void NUpD_SLNetworkLicense_ValueChanged(object sender, EventArgs e)
        {
            NetworkActivationSL = Convert.ToInt32(NUpD_SLNetworkLicense.Value);

            if (NetworkActivationSL > 0 && LocalActivation < 1) {
                LocalActivation = 1;
                NUpD_LocalLicense.Value = 1;
            } 
        }

        private void NUpD_HLNetworkLicense_ValueChanged(object sender, EventArgs e)
        {
            NetworkActivationHL = Convert.ToInt32(NUpD_HLNetworkLicense.Value);

            if (NetworkActivationHL > 0)
            {
                P_Bottom.Location = new Point(0, 195);
                TB_Logs.Size = new Size(460, 60);
                TB_Logs.MinimumSize = new Size(460, 60);
                TB_Logs.MaximumSize = new Size(460, 60);

                if (CurrentStateForHL != "" && VendorCode != "")
                {
                    B_Start.Enabled = true;
                }
                else
                {
                    B_Start.Enabled = false;
                }
            }
            else 
            {
                if (NetworkActivationHL == 0)
                {
                    P_Bottom.Location = new Point(0, 230);
                    TB_Logs.Size = new Size(460, 100);
                    TB_Logs.MinimumSize = new Size(460, 100);
                    TB_Logs.MaximumSize = new Size(460, 100);

                    if (VendorCode != "")
                    {
                        B_Start.Enabled = true;
                    }
                    else
                    {
                        B_Start.Enabled = false;
                    }
                }
            }
        }

        private void RB_DefaultMix_CheckedChanged(object sender, EventArgs e)
        {
            NUpD_LocalLicense.Value = 0;
            NUpD_SLNetworkLicense.Value = 0;
            NUpD_HLNetworkLicense.Value = 0;

            P_CustomSettings.Visible = false;
            P_Bottom.Location = new Point(0, 195);
            TB_Logs.Size = new Size(460, 60);
            TB_Logs.MinimumSize = new Size(460, 60);
            TB_Logs.MaximumSize = new Size(460, 60);
            LocalActivation = defaultNumberOfLic;
            NetworkActivationSL = defaultNumberOfLic;
            NetworkActivationHL = defaultNumberOfLic;
            UnlockedTrialware = true;

            if (CurrentStateForHL != "" && VendorCode != "")
            {
                B_Start.Enabled = true;
            }
            else
            {
                B_Start.Enabled = false;
            }
        }

        private void RB_DefaultSL_CheckedChanged(object sender, EventArgs e)
        {
            NUpD_LocalLicense.Value = 0;
            NUpD_SLNetworkLicense.Value = 0;
            NUpD_HLNetworkLicense.Value = 0;

            P_CustomSettings.Visible = false;
            P_Bottom.Location = new Point(0, 230);
            TB_Logs.Size = new Size(460, 100);
            TB_Logs.MinimumSize = new Size(460, 100);
            TB_Logs.MaximumSize = new Size(460, 100);
            LocalActivation = defaultNumberOfLic;
            NetworkActivationSL = defaultNumberOfLic;
            NetworkActivationHL = 0;
            UnlockedTrialware = false;

            if (RB_DefaultSL.Checked == true && VendorCode != "")
            {
                B_Start.Enabled = true;
            }
            else
            {
                B_Start.Enabled = false;
            }
        }

        private void RB_DefaultHL_CheckedChanged(object sender, EventArgs e)
        {
            NUpD_LocalLicense.Value = 0;
            NUpD_SLNetworkLicense.Value = 0;
            NUpD_HLNetworkLicense.Value = 0;

            P_CustomSettings.Visible = false;
            P_Bottom.Location = new Point(0, 195);
            TB_Logs.Size = new Size(460, 60);
            TB_Logs.MinimumSize = new Size(460, 60);
            TB_Logs.MaximumSize = new Size(460, 60);
            LocalActivation = 0;
            NetworkActivationSL = 0;
            NetworkActivationHL = defaultNumberOfLic;
            UnlockedTrialware = false;

            if (CurrentStateForHL != "" && VendorCode != "")
            {
                B_Start.Enabled = true;
            }
            else
            {
                B_Start.Enabled = false;
            }
        }

        private void RB_Custom_CheckedChanged(object sender, EventArgs e)
        {
            NUpD_LocalLicense.Value = 0;
            NUpD_SLNetworkLicense.Value = 0;
            NUpD_HLNetworkLicense.Value = 0;

            P_CustomSettings.Visible = true;
            P_Bottom.Location = new Point(0, 230);
            TB_Logs.Size = new Size(460, 100);
            TB_Logs.MinimumSize = new Size(460, 100);
            TB_Logs.MaximumSize = new Size(460, 100);
            LocalActivation = Convert.ToInt32(NUpD_LocalLicense.Value);
            NetworkActivationSL = Convert.ToInt32(NUpD_SLNetworkLicense.Value);
            NetworkActivationHL = Convert.ToInt32(NUpD_HLNetworkLicense.Value);
            UnlockedTrialware = CB_UnlockedTrialware.Checked;

            if (RB_Custom.Checked == true && VendorCode != "" && NetworkActivationHL == 0)
            {
                B_Start.Enabled = true;
            }
            else
            {
                if (CurrentStateForHL != "" && VendorCode != "")
                {
                    B_Start.Enabled = true;
                }
                else
                {
                    B_Start.Enabled = false;
                }
            }
        }

        private void B_BrowsePathToVendorCode_Click(object sender, EventArgs e)
        {
            Stream MyStream = null;
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "hvc files (*.hvc)|*.hvc|txt files (*.txt)|*.txt|xml files (*.xml)|*.xml";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((MyStream = OpenFileDialog1.OpenFile()) != null)
                    {
                        using (MyStream)
                        {
                            StreamReader Add = new StreamReader(MyStream);
                            VendorCode = "";
                            VendorCode = Add.ReadToEnd();
                            Add.Close();
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Vendor Code is loaded successfully.";
                            TB_PathToVendorCode.Text = OpenFileDialog1.FileName;
                            B_BrowsePathToVendorCode.BackColor = Color.WhiteSmoke;

                            if (RB_DefaultMix.Checked == true && CurrentStateForHL != "" && VendorCode != "")
                            {
                                B_Start.Enabled = true;
                            }
                            else if (RB_DefaultSL.Checked == true && VendorCode != "") 
                            {
                                B_Start.Enabled = true;
                            }
                            else if (RB_DefaultHL.Checked == true && CurrentStateForHL != "" && VendorCode != "")
                            {
                                B_Start.Enabled = true;
                            }
                            else
                            {
                                if (RB_Custom.Checked == true && VendorCode != "" && NetworkActivationHL == 0)
                                {
                                    B_Start.Enabled = true;
                                }
                                else
                                {
                                    if (CurrentStateForHL != "" && VendorCode != "")
                                    {
                                        B_Start.Enabled = true;
                                    }
                                    else
                                    {
                                        B_Start.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Could not read file with Vendor code from disk! Error: " + ex;
                    B_Start.Enabled = false;
                }
            }
        }

        private void B_BrowsePathToHLC2V_Click(object sender, EventArgs e)
        {
            Stream MyStream2 = null;
            OpenFileDialog OpenFileDialog2 = new OpenFileDialog();
            OpenFileDialog2.Filter = "c2v files (*.c2v)|*.c2v|txt files (*.txt)|*.txt|xml files (*.xml)|*.xml";
            if (OpenFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((MyStream2 = OpenFileDialog2.OpenFile()) != null)
                    {
                        using (MyStream2)
                        {
                            StreamReader Add2 = new StreamReader(MyStream2);
                            CurrentStateForHL = "";
                            CurrentStateForHL = Add2.ReadToEnd();
                            Add2.Close();
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "C2V from Driverless HL Key is loaded successfully.";
                            TB_PathToHLC2V.Text = OpenFileDialog2.FileName;
                            B_BrowsePathToHLC2V.BackColor = Color.WhiteSmoke;

                            if (RB_DefaultMix.Checked == true && CurrentStateForHL != "" && VendorCode != "")
                            {
                                B_Start.Enabled = true;
                            }
                            else if (RB_DefaultSL.Checked == true && VendorCode != "")
                            {
                                B_Start.Enabled = true;
                            }
                            else if (RB_DefaultHL.Checked == true && CurrentStateForHL != "" && VendorCode != "")
                            {
                                B_Start.Enabled = true;
                            }
                            else
                            {
                                if (RB_Custom.Checked == true && VendorCode != "" && NetworkActivationHL == 0)
                                {
                                    B_Start.Enabled = true;
                                }
                                else
                                {
                                    if (CurrentStateForHL != "" && VendorCode != "")
                                    {
                                        B_Start.Enabled = true;
                                    }
                                    else
                                    {
                                        B_Start.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Could not read file with C2V from Driverless HL Key from disk! Error: " + ex;
                    B_Start.Enabled = false;
                }
            }
        }

        private void B_Start_Click(object sender, EventArgs e)
        {
            DialogResult WarningMessageDialogResult = MessageBox.Show(
                                            "Check list of licenses for deduct:" + Environment.NewLine +
                                            "   New SL key Pool: " + LocalActivation + Environment.NewLine +
                                            "   SL Pool of Seats: " + NetworkActivationSL + Environment.NewLine +
                                            "   HL Pool of Seats: " + NetworkActivationHL + Environment.NewLine +
                                            "   Start Unlocked license: " + UnlockedTrialware + Environment.NewLine,
                                            "Warning message",
                                            MessageBoxButtons.OKCancel);

            if (WarningMessageDialogResult == DialogResult.OK)
            {
                string tmpGenPLicStatus;
                string tmpGenSLNetLicStatus;
                string tmpGenSLLocalLicStatus;
                string tmpGenHLLicStatus;

                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Start session ==============================";

                if (RB_DefaultMix.Checked == true)
                {
                    #region Unlocked Trialware in SL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    tmpGenPLicStatus = UnlockedTrialwareLicense();
                    if (tmpGenPLicStatus == "success")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Unlocked Trialware";
                    }
                    else if (tmpGenPLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenPLicStatus + " | Unlocked Trialware";
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion

                    #region SL Network license in SL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    tmpGenSLNetLicStatus = NetworkLicenseSL(NetworkActivationSL);
                    if (tmpGenSLNetLicStatus == "success")
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationSL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | SL network license " + (s4_1 + 1);
                        }

                        LocalActivation--;
                    }
                    else if (tmpGenSLNetLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | SL network license " + (s4_1 + 1);
                        }
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion

                    #region SL Local license in SL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    for (s4_1 = 0; s4_1 < LocalActivation; s4_1++)
                    {
                        tmpGenSLLocalLicStatus = LocalLicense();
                        if (tmpGenSLLocalLicStatus == "success")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (s4_1 + 1);
                        }
                        else if (tmpGenSLLocalLicStatus == "break")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLLocalLicStatus + " | Local license " + (s4_1 + 1);
                        }
                    }
                    if (tmpGenSLNetLicStatus == "success")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (LocalActivation + 1);
                    }
                    else if (tmpGenSLNetLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | Local license " + (LocalActivation + 1);
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion

                    #region HL Network license in HL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    tmpGenHLLicStatus = NetworkLicenseHL(NetworkActivationHL);
                    if (tmpGenHLLicStatus == "success")
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | HL network license " + (s4_1 + 1);
                        }
                    }
                    else if (tmpGenHLLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenHLLicStatus + " | HL network license " + (s4_1 + 1);
                        }
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion
                }
                else if (RB_DefaultSL.Checked == true)
                {
                    #region SL Network license in SL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    tmpGenSLNetLicStatus = NetworkLicenseSL(NetworkActivationSL);
                    if (tmpGenSLNetLicStatus == "success")
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationSL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | SL network license " + (s4_1 + 1);
                        }

                        LocalActivation--;
                    }
                    else if (tmpGenSLNetLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | SL network license " + (s4_1 + 1);
                        }
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion

                    #region SL Local license in SL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    for (s4_1 = 0; s4_1 < LocalActivation; s4_1++)
                    {
                        tmpGenSLLocalLicStatus = LocalLicense();
                        if (tmpGenSLLocalLicStatus == "success")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (s4_1 + 1);
                        }
                        else if (tmpGenSLLocalLicStatus == "break")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLLocalLicStatus + " | Local license " + (s4_1 + 1);
                        }
                    }
                    if (tmpGenSLNetLicStatus == "success")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (LocalActivation + 1);
                    }
                    else if (tmpGenSLNetLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | Local license " + (LocalActivation + 1);
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion
                }
                else if (RB_DefaultHL.Checked == true)
                {
                    #region HL Network license in HL Default Mode
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    tmpGenHLLicStatus = NetworkLicenseHL(NetworkActivationHL);
                    if (tmpGenHLLicStatus == "success")
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | HL network license " + (s4_1 + 1);
                        }
                    }
                    else if (tmpGenHLLicStatus == "break")
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                        return;
                    }
                    else
                    {
                        for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenHLLicStatus + " | HL network license " + (s4_1 + 1);
                        }
                    }
                    TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    #endregion
                }
                else if (RB_Custom.Checked == true) 
                {
                    #region Unlocked Trialware in Custom Mode
                    if (CB_UnlockedTrialware.Checked == true)
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                        tmpGenPLicStatus = UnlockedTrialwareLicense();
                        if (tmpGenPLicStatus == "success")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Unlocked Trialware";
                        }
                        else if (tmpGenPLicStatus == "break") 
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenPLicStatus + " | Unlocked Trialware";
                        }
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    }
                    #endregion

                    #region HL Network license in Custom Mode
                    if (NetworkActivationHL > 0)
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                        tmpGenHLLicStatus = NetworkLicenseHL(NetworkActivationHL);
                        if (tmpGenHLLicStatus == "success")
                        {
                            for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | HL network license " + (s4_1 + 1);
                            }
                        }
                        else if (tmpGenHLLicStatus == "break")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenHLLicStatus + " | HL network license " + (s4_1 + 1);
                            }
                        }
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    }
                    #endregion

                    #region SL Network & Local license in Custom Mode
                    if (NetworkActivationSL > 0 && LocalActivation > 0)
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                        tmpGenSLNetLicStatus = NetworkLicenseSL(NetworkActivationSL);
                        if (tmpGenSLNetLicStatus == "success")
                        {
                            for (s4_1 = 0; s4_1 < NetworkActivationSL; s4_1++)
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | SL network license " + (s4_1 + 1);
                            }

                            LocalActivation--;
                        }
                        else if (tmpGenSLNetLicStatus == "break")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            for (s4_1 = 0; s4_1 < NetworkActivationHL; s4_1++)
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | SL network license " + (s4_1 + 1);
                            }
                        }
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";

                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                        for (s4_1 = 0; s4_1 < LocalActivation; s4_1++)
                        {
                            tmpGenSLLocalLicStatus = LocalLicense();
                            if (tmpGenSLLocalLicStatus == "success")
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (s4_1 + 1);
                            }
                            else if (tmpGenSLLocalLicStatus == "break")
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                                return;
                            }
                            else
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLLocalLicStatus + " | Local license " + (s4_1 + 1);
                            }
                        }
                        if (tmpGenSLNetLicStatus == "success")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | Local license " + (LocalActivation + 1);
                        }
                        else if (tmpGenSLNetLicStatus == "break")
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                            return;
                        }
                        else
                        {
                            TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLNetLicStatus + " | Local license " + (LocalActivation + 1);
                        }
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    }
                    else if (NetworkActivationSL == 0 && LocalActivation > 0) 
                    {
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                        for (s4_1 = 0; s4_1 < LocalActivation; s4_1++)
                        {
                            tmpGenSLLocalLicStatus = LocalLicense();
                            if (tmpGenSLLocalLicStatus == "success")
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License was generated!" + " | SL local license " + (s4_1 + 1);
                            }
                            else if (tmpGenSLLocalLicStatus == "break")
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "Early completion session ==============================";
                                return;
                            }
                            else
                            {
                                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "License can't be generation! Error: " + tmpGenSLLocalLicStatus + " | SL local license " + (s4_1 + 1);
                            }
                        }
                        TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "---------";
                    }
                    #endregion
                }

                TB_Logs.Text = TB_Logs.Text + Environment.NewLine + "End session ==============================";
            }
        }

        private void CB_UnlockedTrialware_CheckedChanged(object sender, EventArgs e)
        {
            UnlockedTrialware = CB_UnlockedTrialware.Checked;
        }

        public string UnlockedTrialwareLicense()
        {
            string StartParam = null;
            sntl_lg_license_type_t LicenseType = sntl_lg_license_type_t.SNTL_LG_LICENSE_TYPE_PROVISIONAL;
            string Definition =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            " <sentinel_ldk:license schema_version=\"1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sentinel_ldk=\"http://www.safenet-inc.com/sentinelldk\">" +
            "   <enforcement_type>SL-AdminMode</enforcement_type>" +
            "   <product>" +
            "      <id>123</id>" +
            "      <name>Sample Product 123</name>" +
            "      <feature>" +
            "         <id>1000</id>" +
            "         <name>Sample Feature 1000</name>" +
            "         <license_properties>" +
            "            <!-- You can specify the number of days until the license expires -->" +
            "            <days_to_expiration>30</days_to_expiration>" +
            "            <!-- You can specify the remote desktop accessibility flag. Possible values are \"Yes\" or \"No\" --> " +
            "            <remote_desktop_access>Yes</remote_desktop_access>" +
            "            <!-- You can specify the virtual machine accessibility flag. Possible values are \"Yes\" or \"No\" -->" +
            "            <virtual_machine_access>No</virtual_machine_access>" +
            "         </license_properties>" +
            "      </feature>" +
            "   </product>" +
            " </sentinel_ldk:license>";
            string CurrentStateProvisional = null;
            Status = LicGenHelper.sntl_lg_start(StartParam, VendorCode, LicenseType, Definition, CurrentStateProvisional);
            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
                return "StartS_" + Convert.ToString(Status);
            }
            else
            {
                string genStatus;
                genStatus = GenerationLicense();

                return genStatus;
            }
        }

        public string LocalLicense()
        {
            string StartParam = null;
            sntl_lg_license_type_t LicenseType = sntl_lg_license_type_t.SNTL_LG_LICENSE_TYPE_UPDATE;
            string Definition =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            " <sentinel_ldk:license schema_version=\"1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sentinel_ldk=\"http://www.safenet-inc.com/sentinelldk\">" +
            "   <!-- You can specify the acknowledgement request flag. Possible values are \"Yes\" or \"No\"-->" +
            "   <acknowledgement_request>Yes</acknowledgement_request>" +
            "   <!-- You can specify the enforcement type. Possible values are \"HL\", \"SL-AdminMode\", \"SL-UserMode\", \"HL or SL-AdminMode\" or \"HL or SL-AdminMode or SL-UserMode\"-->" +
            "   <enforcement_type>HL or SL-AdminMode or SL-UserMode</enforcement_type>" +
            "   <product>" +
            "      <id>123</id>" +
            "      <name>Sample Product 123</name>" +
            "      <feature>" +
            "         <id>1000</id>" +
            "         <name>Sample Feature 1000</name>" +
            "         <license_properties>" +
            "            <!-- Only one of the below license model can be specified. -->" +
            "            <perpetual/>" +
            "            <!-- <expiration_date>2011-12-31</expiration_date> -->" +
            "            <!-- <execution_count>30</execution_count> -->" +
            "            <!-- <days_to_expiration>90</days_to_expiration> -->" +
            "            <!-- You can specify the remote desktop accessibility flag. Possible values are \"Yes\" or \"No\" --> " +
            "            <remote_desktop_access>Yes</remote_desktop_access>" +
            "            <virtual_machine_access>Yes</virtual_machine_access>" +
            "         </license_properties>" +
            "      </feature>" +
            "   </product>" +
            " </sentinel_ldk:license>";
            Status = LicGenHelper.sntl_lg_start(StartParam, VendorCode, LicenseType, Definition, CurrentStateForSL);
            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
                return "StartS_" + Convert.ToString(Status);
            }
            else
            {
                string genStatus;
                genStatus = GenerationLicense();

                return genStatus;
            }
        }

        public string NetworkLicenseSL(int licNumber)
        {
            string StartParam = null;
            sntl_lg_license_type_t LicenseType = sntl_lg_license_type_t.SNTL_LG_LICENSE_TYPE_UPDATE;
            string Definition =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            " <sentinel_ldk:license schema_version=\"1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sentinel_ldk=\"http://www.safenet-inc.com/sentinelldk\">" +
            "   <!-- You can specify the acknowledgement request flag. Possible values are \"Yes\" or \"No\"-->" +
            "   <acknowledgement_request>Yes</acknowledgement_request>" +
            "   <!-- You can specify the enforcement type. Possible values are \"HL\", \"SL-AdminMode\", \"SL-UserMode\", \"HL or SL-AdminMode\" or \"HL or SL-AdminMode or SL-UserMode\"-->" +
            "   <enforcement_type>SL-AdminMode</enforcement_type>" +
            "   <product>" +
            "      <id>123</id>" +
            "      <name>Sample Product 123</name>" +
            "      <feature>" +
            "         <id>1000</id>" +
            "         <name>Sample Feature 1000</name>" +
            "         <license_properties>" +
            "            <!-- Only one of the below license model can be specified. -->" +
            "            <perpetual/>" +
            "            <!-- <expiration_date>2011-12-31</expiration_date> -->" +
            "            <!-- <execution_count>30</execution_count> -->" +
            "            <!-- <days_to_expiration>90</days_to_expiration> -->" +
            "            <!-- You can specify the remote desktop accessibility flag. Possible values are \"Yes\" or \"No\" --> " +
            "            <concurrency>" +
            "               <count>" + licNumber + "</count>" +
            "               <count_criteria>Per Station</count_criteria>" +
            "               <network_access>Yes</network_access>" +
            "               <detachable>No</detachable>" +
            "            </concurrency>" +
            "            <remote_desktop_access>Yes</remote_desktop_access>" +
            "            <virtual_machine_access>Yes</virtual_machine_access>" +
            "         </license_properties>" +
            "      </feature>" +
            "   </product>" +
            " </sentinel_ldk:license>";
            Status = LicGenHelper.sntl_lg_start(StartParam, VendorCode, LicenseType, Definition, CurrentStateForSL);

            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
                return "StartS_" + Convert.ToString(Status);
            }
            else
            {
                string genStatus;
                genStatus = GenerationLicense();

                return genStatus;
            }
        }

        public string NetworkLicenseHL(int licNumber)
        {
            string StartParam = null;
            sntl_lg_license_type_t LicenseType = sntl_lg_license_type_t.SNTL_LG_LICENSE_TYPE_UPDATE;
            string Definition =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            " <sentinel_ldk:license schema_version=\"1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sentinel_ldk=\"http://www.safenet-inc.com/sentinelldk\">" +
            "   <!-- You can specify the acknowledgement request flag. Possible values are \"Yes\" or \"No\"-->" +
            "   <acknowledgement_request>Yes</acknowledgement_request>" +
            "   <!-- You can specify the enforcement type. Possible values are \"HL\", \"SL-AdminMode\", \"SL-UserMode\", \"HL or SL-AdminMode\" or \"HL or SL-AdminMode or SL-UserMode\"-->" +
            "   <enforcement_type>HL</enforcement_type>" +
            "   <upgrade_to_driverless>Yes</upgrade_to_driverless>" +
            "   <product>" +
            "      <id>123</id>" +
            "      <name>Sample Product 123</name>" +
            "      <use_vclock>No</use_vclock>" +
            "      <feature>" +
            "         <id>1000</id>" +
            "         <name>Sample Feature 1000</name>" +
            "         <license_properties>" +
            "            <!-- Only one of the below license model can be specified. -->" +
            "            <perpetual/>" +
            "            <!-- <expiration_date>2011-12-31</expiration_date> -->" +
            "            <!-- <execution_count>30</execution_count> -->" +
            "            <!-- <days_to_expiration>90</days_to_expiration> -->" +
            "            <!-- You can specify the remote desktop accessibility flag. Possible values are \"Yes\" or \"No\" --> " +
            "            <concurrency>" +
            "               <count>" + licNumber + "</count>" +
            "               <count_criteria>Per Station</count_criteria>" +
            "               <network_access>Yes</network_access>" +
            "            </concurrency>" +
            "            <remote_desktop_access>Yes</remote_desktop_access>" +
            "         </license_properties>" +
            "      </feature>" +
            "   </product>" +
            " </sentinel_ldk:license>";
            Status = LicGenHelper.sntl_lg_start(StartParam, VendorCode, LicenseType, Definition, CurrentStateForHL);

            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                /*handle error*/
                return "StartS_" + Convert.ToString(Status);
            }
            else
            {
                string genStatus;
                genStatus = GenerationLicense();

                return genStatus;
            }
        }

        public string GenerationLicense()
        {
            string GenerationParam = null;
            string License = null;
            string UpdatedState = null;
            Status = LicGenHelper.sntl_lg_generate_license(GenerationParam, ref License, ref UpdatedState);
            if (sntl_lg_status_t.SNTL_LG_STATUS_OK != Status)
            {
                return "GenS_" + Convert.ToString(Status);
            }
            else if (sntl_lg_status_t.SNTL_LG_MASTER_KEY_IO_ERROR == Status) 
            {
                DialogResult ErrorMessageDialogResult = MessageBox.Show(
                                            "Error Message: " + Environment.NewLine +
                                            Status + Environment.NewLine +
                                            "Error code: 5025 - may happened if you login on PC via RDP." + Environment.NewLine +
                                            "Please check RDP connection firstly and then push:" + Environment.NewLine +
                                            "Abort - if you would like to stop cleaning process." + Environment.NewLine +
                                            "Retry - if you would like to try do last generation again." + Environment.NewLine +
                                            "Ignore - if you would like to ignore last error. " + Environment.NewLine,
                                            "!Error message!",
                                            MessageBoxButtons.AbortRetryIgnore);

                if (ErrorMessageDialogResult == DialogResult.Abort)
                {
                    return "break";
                }
                else if (ErrorMessageDialogResult == DialogResult.Retry)
                {
                    return GenerationLicense();
                }
                else // if (ErrorMessageDialogResult == DialogResult.Ignore)
                {
                    return "GenS_" + Convert.ToString(Status);
                }
            }
            else
            {
                return "success";
            }
        }
    }
}

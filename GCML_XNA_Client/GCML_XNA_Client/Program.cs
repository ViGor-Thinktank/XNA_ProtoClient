using System;
using System.Windows.Forms;
using GenericCampaignMasterLib;


namespace GCML_XNA_Client
{
  static class Program
  {
      public static CampaignController m_objCampaign;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        if (MessageBox.Show("Schachbrett?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            Program.m_objCampaign = new CampaignController(new CampaignEngine(new Field_Schachbrett(5, 5)));
        }
        else
        {
            Program.m_objCampaign = new CampaignController(new CampaignEngine(new Field_Schlauch(8)));
        }
 
      using (clsProtoClient game = new clsProtoClient())
      {
        game.Run();
      }
    }
  }
}


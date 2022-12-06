using Connect.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_getSNSlot
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectDB oCon = new ConnectDB();
            ConnectDBSMT oConSMT = new ConnectDBSMT();

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            DataTable dt = new DataTable();

            cmd.CommandText = "Select * From TempSNTEST with(nolock)";
            cmd.CommandTimeout = 180;
            dt = oCon.Query(cmd);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        //--loop exec--
                        cmd1 = new SqlCommand();
                        oCon = new ConnectDB();
                        cmd1.CommandText = "EXEC TraceReport_GetCompBySN_Test 'one', '" + row["SN"].ToString().Trim() + "', '', 'excel'";
                        //cmd1.CommandTimeout = 100000;
                        oCon.ExecuteCommand(cmd1);
                    }
                    catch (Exception ex)
                    {}
                }
            }
            ////--Clear DATA compPN <> ('FBNHC013010', 'FBNHC014010')==
            //oCon = new ConnectDB();
            //cmd2.CommandText = "Delete From TempResult Where CompPN <> 'FBNHC013010' AND CompPN <> 'FBNHC014010'";
            //cmd2.CommandTimeout = 180;
            //oCon.ExecuteCommand(cmd2);

            //--Loop SN from TempResult--
            //DataTable dt2 = new DataTable();
            //oCon = new ConnectDB();
            //cmd3.CommandText = "Select * From TempResult with(nolock)";
            //cmd3.CommandTimeout = 1000;
            //dt2 = oCon.Query(cmd3);

            //DataTable dt3 = new DataTable();
            //SqlCommand cmd4 = new SqlCommand();
            //SqlCommand cmd5 = new SqlCommand();
            //SqlCommand cmd6 = new SqlCommand();
            //if (dt2.Rows.Count > 0)
            //{
            //    //--Get AOI from SN_AOI--
            //    foreach (DataRow row in dt2.Rows)
            //    {
            //        cmd4 = new SqlCommand();
            //        cmd4.CommandText = "Select SN, AOI From SN_AOI with(nolock) Where AOI = '"+row["AOI"].ToString().Trim()+ "' Union All Select SN, AOI From SMTHistory..SN_AOI with(nolock)Where AOI = '" + row["AOI"].ToString().Trim() + "'";
            //        cmd4.CommandTimeout = 180;
            //        dt3 = oConSMT.Query(cmd4);

            //        if (dt3.Rows.Count > 0)
            //        {
            //            int i = 1;
            //            foreach (DataRow row1 in dt3.Rows)
            //            {
            //                if (row1["SN"].ToString().Trim() == row["SN"].ToString().Trim())
            //                {
            //                    if (i == 1 || i == 3 || i == 6 || i == 8 || i == 9 || i == 11)
            //                    {
            //                        //--Update slotInPanel = 2--
            //                        oConSMT = new ConnectDBSMT();
            //                        cmd5 = new SqlCommand();
            //                        cmd5.CommandText = "Update TempResult set SlotInPanel = 2 Where Wo = '"+row["WO"].ToString().Trim()+"' AND AOI = '"+row["AOI"].ToString().Trim()+"' AND SN = '"+row["SN"].ToString().Trim()+"' AND DID = '"+row["DID"].ToString().Trim()+"'";
            //                        cmd5.CommandTimeout = 180;
            //                        oConSMT.ExecuteCommand(cmd5);
            //                    }
            //                    else
            //                    {
            //                        //--Update slotInPanel = 1--
            //                        oConSMT = new ConnectDBSMT();
            //                        cmd6 = new SqlCommand();
            //                        cmd6.CommandText = "Update TempResult set SlotInPanel = 1 Where Wo = '" + row["WO"].ToString().Trim() + "' AND AOI = '" + row["AOI"].ToString().Trim() + "' AND SN = '" + row["SN"].ToString().Trim() + "' AND DID = '" + row["DID"].ToString().Trim() + "'";
            //                        cmd6.CommandTimeout = 180;
            //                        oConSMT.ExecuteCommand(cmd6);
            //                    }
            //                }
            //                i++;
            //            }
            //        }
            //    }
            //}
        }
    }
}

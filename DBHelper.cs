using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <Summary>
///		Standardize Database operation
/// 	Before using these functions, you must configure connectionstring named "ProductionPerformance" in Web.config file.
/// </Summary>

public class DBHelper{
	
	// Function to check if username and password is correct. return true if correct, else return false
	public static bool validateUser(string username, string password)
	{
		DataTable result = null;
		// SQL Statement to retrieve password value from Database Table 
		string strSQLPWD = "SELECT 1 From Users Where username = @uname and password=@pwd";
		try {
			using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["ProductPerformance"].ConnectionStrings.ToString()))
				{
					using (SqlCommand cmd = conn.CreateCommand())
					{
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = strSQLPWD;
						cmd.Parameters.Add(new SqlParamenter("@uname",username));
						cmd.Parameters.Add(new SqlParamenter("@pwd",password));
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
							{
								result = new DataTable();
								da.Fill(result);
							}
							if (result.Rows.Count == 1)
							{
								// username and password match
								return true;
							}
					}
				}
		}
		catch (Exception e){
			
			// Exception handling
		}
		return false;
	}
	
	// Function to retrieve user's roles, it returned a string seperated by ";".
	public static string getUserRoles (string username){
		DataTable result = null;
		string strSQLRoles = "SELECT roles from users where username=@uname";
		try {
			using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["ProductPerformance"].ConnectionStrings.ToString()))
				{
					using (SqlCommand cmd = conn.CreateCommand())
					{
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = strSQLRoles;
						cmd.Parameters.Add(new SqlParamenter("@uname",username));
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
							{
								result = new DataTable();
								da.Fill(result);
							}
							if (result.Rows.Count==1)
							
							{
								// return user roles seperated by ";"
								return result.Rows[0]["Roles"].ToString().Trim();
							}
					}
				}
		}
		catch (Exception e)
		{
			
		}
		//Nothing returned
		return "";
	}
	
}
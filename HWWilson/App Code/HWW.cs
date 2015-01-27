using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HWWilson.App_Code
{

    public class Products
    {
        public SqlDataReader GetProducts()
        {

            string myConnectionString;
            string sql1;

            //Instantiate connection object //
            SqlConnection myConn = new SqlConnection();

            //Initialise myConnectionString variable
            myConnectionString = "Data Source= BUNNY-TOSH;Initial Catalog=HWWilson;Integrated Security=True";
               
            //Initilaise ConnectionString property of myConn
            myConn.ConnectionString = myConnectionString;

            // create the sql to run against the database
            sql1 = "SELECT product_name, prod_barcode, prod_stock_level FROM tProduct" ;


            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = sql1;
            myCommand.Connection = myConn;

            // Open the connection //
            myConn.Open();

            // Build and fill the dataReader //
            // Notice if you close the connection before using the DataReader it generates an error
            // so CommandBehavior.CloseConnection will close the connection after the datareader is
            // used on the calling page.
            SqlDataReader myDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            // Close connection before data is used from datareader to show error message
            // myConn.Close();
            // Return the datareader to the calling program - here it is page_load method of this page.
            return myDataReader;

        } // end method getProducts

    }

}
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
    public abstract class hwConn
    {
        // Defines the server and Database to connect to, this will be used by the methods to connect to the HWWWilson Database
        public SqlConnection ConnHWW = new SqlConnection("Data Source= BUNNY-TOSH;Initial Catalog=HWWilson;Integrated Security=True");

    } // ends hwConn class

    public class Products:hwConn
    {
        //defines the properties of the class
        private String _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private Int64 _prodBar;
        public Int64 prodBar
        {
            get { return _prodBar;}
            set { _prodBar = value; }
        }

        private int _prodMinLevel;
        public int prodMinLevel
        {
            get { return _prodMinLevel; }
            set { _prodMinLevel = value; }
        }

        private int _prodStockLevel;
        public int prodStockLevel
        {
            get { return _prodStockLevel; }
            set { _prodStockLevel = value; }
        }

        private String _prodStockCode;
        public string prodStockCode
        {
            get { return _prodStockCode; }
            set { _prodStockCode = value; }
        }

        private int _prodCatID;
        public int prodCatID
        {
            get { return _prodCatID; }
            set { _prodCatID = value; }
        }
        //End defining the class properties

        public SqlDataReader GetProduct()
            //this method retrieves all products from the database using stored procedure spGetProducts
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetProducts";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProduct method

        public void AddNewProduct()
            // this method is used to add a new product to the HWWilson databse using stored procedure spAddProduct
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spAddProduct";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@product_name", _productName);
            command.Parameters.AddWithValue("@prod_barcode", _prodBar);
            command.Parameters.AddWithValue("@product_min_level", _prodMinLevel);
            command.Parameters.AddWithValue("@prod_stock_level", _prodStockLevel);
            command.Parameters.AddWithValue("@prod_stock_code", _prodStockCode);
            command.Parameters.AddWithValue("@prod_cat_id", _prodCatID);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// closes the AddNewProduct methods
        
    }//Closes the Products class

    public class JobNumbers:hwConn
    {
        public SqlDataReader GetJobNo()
        //this method retrieves all products from the database using stored procedure spGetProducts
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetJobNo";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProduct method
    }// closes the class JobNumbers

} // closes the namespace
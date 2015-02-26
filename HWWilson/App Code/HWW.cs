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
    // Defines the server and Database to connect to, this will be used by every function to connect to the HWW Database
    public abstract class hwConn
    {   //this is the address of the database to connect to  
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

        private String _jobNo;
        public string jobNo
        {
            get { return _jobNo; }
            set { _jobNo = value; }
        }

        private String _jobDesc;
        public string jobDesc
        {
            get { return _jobDesc; }
            set { _jobDesc = value; }
        }

        private String  _jobStatus;
        public string jobStatus
        {
            get { return _jobStatus; }
            set { _jobStatus = value; }
        }
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
        
        public SqlDataReader GetJobNoFilter()
        // this method is used to retrieve job description from the database using stroed procedure spGetJobDesc which requires a
        // a job number to be passed as a parameter
        {           
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetJobDesc";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@job_number", _jobNo);
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader; 
          
        } // ends the GetJobNoFilter method

        
    }// closes the class JobNumbers

    public class Employees:hwConn
    {
        private Int64 _empId;
        public Int64 empId
        {
            get { return _empId; }
            set { _empId = value; }
        }

        private String _fName;
        public string fName
        {
            get { return _fName; }
            set { _fName = value; }
        }

        private String _Sname;
        public string Sname
        {
            get { return _Sname; }
            set { _Sname = value; }
        }

        private int _roleId;
        public int roleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public void AddNewEmp()
        // this method is used to add a new product to the HWWilson databse using stored procedure spAddProduct
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spAddEmployee";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employee_id", _empId);
            command.Parameters.AddWithValue("@emp_firstname", _fName);
            command.Parameters.AddWithValue("@emp_surname ", _Sname);
            command.Parameters.AddWithValue("@role_id ", _roleId);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// closes the AddNewProduct methods

    } // closes the employee class
} // closes the namespace
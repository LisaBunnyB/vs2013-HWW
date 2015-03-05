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
        public SqlConnection ConnHWW = new SqlConnection("Data Source= BUNNY-TOSH;Initial Catalog=HWW;Integrated Security=True");

    } // ends hwConn class

    public class Products : hwConn
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
            get { return _prodBar; }
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
            command.Parameters.AddWithValue("@barcode", _prodBar);
            command.Parameters.AddWithValue("@product_min_level", _prodMinLevel);
            command.Parameters.AddWithValue("@prod_stock_level", _prodStockLevel);
            command.Parameters.AddWithValue("@prod_stock_code", _prodStockCode);
            command.Parameters.AddWithValue("@prod_cat_id", _prodCatID);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// closes the AddNewProduct methods

    }//Closes the Products class

    public class JobNumbers : hwConn
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

        private String _jobStatus;
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

    public class Employees : hwConn
    {

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

        private String _userName;
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private String _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }


        public void AddNewEmp()
        // this method is used to add a new product to the HWWilson databse using stored procedure spAddProduct
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spAddEmployee";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@emp_firstname", _fName);
            command.Parameters.AddWithValue("@emp_surname ", _Sname);
            command.Parameters.AddWithValue("@role_id ", _roleId);
            command.Parameters.AddWithValue("@username ", _userName);
            command.Parameters.AddWithValue("@userpassword", _password);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// closes the AddNewProduct methods

    } // closes the employee class

    public class Order : hwConn
    {
        private String _jobNo;
        public string jobNo
        {
            get { return _jobNo; }
            set { _jobNo = value; }
        }

        private Int32 _ordEmp;
        public Int32 ordEmp
        {
            get { return _ordEmp; }
            set { _ordEmp = value; }
        }
        private Int32 _sordNo;
        public Int32 sordNo
        {
            get { return _sordNo; }
            set { _sordNo = value; }
        }

        private Int32 _prodId;
        public Int32 prodId
        {
            get { return _prodId; }
            set { _prodId = value; }
        }

        private Int64 _barcode;
        public Int64 barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private Int32 _ordQty;
        public Int32 ordQty
        {
            get { return _ordQty; }
            set { _ordQty = value; }
        }

        /* this method is used to add a new Order to the HWW databse using stored procedure spNewOrder
         * ordernumber and job number are passed as parameters. a new order is created and the orderid is returned from
         * the stored procedure and updated in _sordNo. this is converted to a session variable in the bookout.aspx.cs
        */
        public Int32 CreateNewOrder()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spNewOrder";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderEmp", _ordEmp);
            command.Parameters.AddWithValue("@jobNo", _jobNo);
            ConnHWW.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            _sordNo = Convert.ToInt32(reader["orderId"]);
            ConnHWW.Close();
            return _sordNo;

        }// closes the CreateNewOrder methods

        /* this method is used to change the job number in the order table if the job number drop down is updated after the orderid
         * has been created. The orderId session variable and the JobNo are passed as parameters to the stored procedure spChangeJobNo
       */
        public void changeOrderJob()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spChangeJobNo";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.Parameters.AddWithValue("@jobNo", _jobNo);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();
        }// addOrderLines

        /* this method is used to add products to the orderDetail table in the database using the orderid created in
        * CreateNewOrder(). The orderid, barcode and qty are passed as parameters to stored procedure spAddOrderLines3
        * the SP checks if the orderid and prodid(obtained by barcode in the db) exists, if it does it adds the qty to
         * the qty in the record, otherwise it adds a new record for the product
       */
        public void addOrderLines()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spAddOrderLines4";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.Parameters.AddWithValue("@barCode", _barcode);
            command.Parameters.AddWithValue("@ordQty", _ordQty);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();
        }// addOrderLines

        public void removeOrderLines()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spRemoveItem2";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.Parameters.AddWithValue("@prodId", _prodId);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// Closes method removeOrderLines

        public SqlDataReader getOrderDetails()
        //this method retrieves all products added to the current order by seesion id the database using stored procedure spGetProducts
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.CommandText = "spOrderDetails";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProduct method

        /*This method is used when the user click cancel order from the bookout page. The orderId is passed as a parameter
         * to spCancelOrder and the orderDetail records that match the id are deleted and then the order records matchin the 
         * orderid are deleted
         */
        public void cancelOrder()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spUodateStockLevelOnCancel";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// Closes method cancelOrder()

        public void removeOrder()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spRemoveOrder";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// Closes method cancelOrderId()
        

    }// Closes the Order Class
} // closes the namespace
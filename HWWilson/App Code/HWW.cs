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

        private Int16 _prodID;
        public Int16 prodID
        {
            get { return _prodID; }
            set { _prodID = value; }
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

        private Int32 _errNo;
        public Int32 errNo
        {
            get { return _errNo; }
            set { _errNo = value; }
        }

        private String _errMsg;
        public String errMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
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

        public SqlDataReader GetProductByID()
        //this method passes a product ID as a parameter to stored procedure spGetProductsByID and returns the product details
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetProductsByID";
            command.Parameters.AddWithValue("@prodID", _prodID);
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProductByID method

        public SqlDataReader CheckBarcode()
        //this method passes a barcode as a parameter to spCheckBarcodeExists in the database and confirms if it exists
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spCheckBarcodeExists";
            command.Parameters.AddWithValue("@barcode", _prodBar);
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader();
            myReader.Read();
            try
            {
                errNo = Convert.ToInt32(myReader["barcode"]);
            }

            catch
            {
                errNo = Convert.ToInt32(myReader[""]);
            }

            ConnHWW.Close();
            return myReader;
        } // ends the getOrders() method

        public SqlDataReader GetProductByBarcode()
        // this method passes a barcode as a parameter to spGetProductsByBarcode in the database and returns the product details
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetProductsByBarcode";
            command.Parameters.AddWithValue("@barcode", _prodBar);
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProductByBarcode method

        public SqlDataReader GetStockCode()
        //Retrieves all products category ID's and Descriptions used to populate DDL lists of product categories
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spGetstockCat";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProduct method 

        public SqlDataReader GetProdName()
        /*this method retrieves all products from the database using stored procedure spLikeProdName passing name
         * as a parameter and returning products with a similar name
         */
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spLikeProdName";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", _productName);
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the GetProduct method 

        public SqlDataReader GetStockCat()
        // This method passes a product category as a parameter to spProductsByCat and returns products in that category
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spProductsByCat";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cat", _prodStockCode);
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;

        } // ends the GetProduct method

        public void AddNewProduct()
        /*this method is used to add a new product to the HWWilson database using stored procedure spAddProduct
         * it passes product name, barcode, min stock level, number in stock, stock code and cetegory ID as parameters
         * if either the barcode or stock code already exist in the database then an error will be returned and the product will not be created
         */
        {
            try
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
            }
            catch (SqlException sqlex)
            {
                {
                    errNo = sqlex.Number;
                    errMsg = sqlex.Message;
                }
            }
            ConnHWW.Close();
        }// closes the AddNewProduct methods

        public void AmendProduct()
        /* this method is used to amend the details of a product using stored procedure spUpDateProduct
         * it passes product ID product name, barcode, min stock level, number in stock, stock code and cetegory ID as parameters
         * if either the barcode or stock code already exist in the database then an error will be returned and the product will not be amended
         */
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnHWW;
                command.CommandText = "spUpDateProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@product_ID", _prodID);
                command.Parameters.AddWithValue("@product_name", _productName);
                command.Parameters.AddWithValue("@barcode", _prodBar);
                command.Parameters.AddWithValue("@product_min_level", _prodMinLevel);
                command.Parameters.AddWithValue("@prod_stock_level", _prodStockLevel);
                command.Parameters.AddWithValue("@prod_stock_code", _prodStockCode);
                command.Parameters.AddWithValue("@prod_cat_id", _prodCatID);
                ConnHWW.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                {
                    errNo = sqlex.Number;
                    errMsg = sqlex.Message;
                }
            }
            ConnHWW.Close();
        }// closes the  AmendProduct method

        public void AddBarcodeToProduct()
        /*this method is used to add a new barcode to an existing product in the HWWilson database using stored procedure spAddBarcode
         * it passes the product ID and barcode as a parameter. If the product code does not exist or the barcode already exists in the 
         * database than the barcode will not be added to the database.
         */
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnHWW;
                command.CommandText = "spAddBarcode";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productID", _prodID);
                command.Parameters.AddWithValue("@barcode", _prodBar);
                ConnHWW.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                {
                    errNo = sqlex.Number;
                    errMsg = sqlex.Message;
                }
            }
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
        //this method retrieves all Job numbers from the database using stored procedure spGetJobNo
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
        // this method passes a job number as a parameter to spGetJobDesc and returns the job description for the job number              
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
        /*this method is used to add a new employee to the HWWilson database using stored procedure spAddEmployee
         * it passes firstname, surname, role ID, username and password as parameters.
         */
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

        }// closes the AddNewEmp() method


        public SqlDataReader getEmployees()
        //this method retrieves all Employees from the database using stored procedure spViewAllEmployees
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spViewAllEmployees";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the getEmployees) method

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

        /* this method is used to add a new Order to the HWW database using stored procedure spNewOrder
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
        * CreateNewOrder(). The orderid, barcode and qty are passed as parameters to stored procedure spAddOrderLines
        * the SP checks if the orderid and prodid(obtained by barcode in the db) exists, if it does it adds the qty to
         * the qty in the record, otherwise it adds a new record for the product
       */
        public void addOrderLines()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spAddOrderLines";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.Parameters.AddWithValue("@barCode", _barcode);
            command.Parameters.AddWithValue("@ordQty", _ordQty);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();
        }// addOrderLines

        /* this method is used to remove products from the orderDetail table in the database when the user selects Remove
         * on the gridview. The order ID and prod ID are passed as parameters.
       */
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
        //this method is passed the order ID as a parameter and returns all orderline for the order
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            command.CommandText = "spOrderDetails";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the getOrderDetails method

        /*This method is used when the user click cancel order from the bookout page. The orderId is passed as a parameter
         * to spUpdateStockLevel and the orderDetail records that match the id are deleted and then the order record matching the 
         * orderid are deleted
         */
        public void cancelOrder()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spUpdateStockLevel";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderId", _sordNo);
            ConnHWW.Open();
            command.ExecuteNonQuery();
            ConnHWW.Close();

        }// Closes method cancelOrder()

        /*This method is used when the user clicks confirm Order on the bookout page. The orderid is passed as a parameter 
         * if no orderlines exists for the order the order is deleted from the database to ensure only real orders are retained
         */
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

        }// Closes method removeOrder()

        public SqlDataReader getOrders()
        //this method retrieves all Orders from the database using stored procedure spSelectAllOrders
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spSelectAllOrders";
            command.CommandType = CommandType.StoredProcedure;
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the getOrders() method

        public SqlDataReader getOrdersByJob()
        //this method passes the job number as a parameter and returns all order for the job number
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnHWW;
            command.CommandText = "spSelectAllOrdersForJob";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@jobNo", _jobNo);
            ConnHWW.Open();
            SqlDataReader myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        } // ends the getOrders() method



    }// Closes the Order Class
} // closes the namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vmmDAL;
using vmmBLL;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace vmmBAL
{
    public class Operation
    {
        public DBConnection db = new DBConnection();
        public Informations info = new Informations();
        public Bazar bazar = new Bazar();
        public BookMeal book = new BookMeal();


        public int insertUser(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO vmmUser1 VALUES ('" + info.name + "','" + info.userType + "','" +info.refManagrtName + "','" + info.messName + "','" + info.dob + "','" + info.bloodGroup + "','" + info.userName + "','" + info.password + "','" + info.phone + "',null)";
            return db.ExeNonQuery(cmd);
        }

        public DataTable Login(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select * from vmmUser1 where UserName='"+info.userName+"' and Password='"+info.password+"'";
            return db.ExeReader(cmd);
        }

        public int insertBazar(Bazar bazar)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO vmmBazarChart VALUES ("+bazar.userID+",'" + bazar.date + "','" + bazar.userName + "','" + bazar.items + "','" + bazar.quantity + "',"+bazar.amount+",'"+bazar.refManager+"')";
            return db.ExeNonQuery(cmd);
        }


        public DataTable LoadMemberInformation(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id,Name,DOB,Phone,RefManagerName,MessName,Photo from vmmUser1 where RefManagerName='"+info.refManagrtName+"'";
            return db.ExeReader(cmd);
        }

        public int BookMeal(BookMeal book)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO vmmMealChart VALUES ('" + book.date + "'," + book.memberId + ",'" + book.name + "'," + book.breakfast + "," + book.lunch + "," + book.dinner + ",'" + book.refManager + "',"+book.TotalMeal+")";
            return db.ExeNonQuery(cmd);
            
        }

        public DataTable LoadMealHistorySpecificDate(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,Date,Name,Breakfast,Lunch,Dinner,TotalMeal FROM vmmMealChart where refManager='" + info.refManagrtName + "'and Date BETWEEN'"+info.dateFromMeal+"'AND '"+info.dateToMeal+"'";
            return db.ExeReader(cmd);
            
        }

        public DataTable LoadMealHistory(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,Date,Name,Breakfast,Lunch,Dinner,TotalMeal FROM vmmMealChart where refManager='"+info.refManagrtName+"' and Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0)";
            return db.ExeReader1(cmd);
            
        }

        public DataTable LoadBazarHistory(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date,Name,sum(Price) as Total_Price FROM vmmBazarChart where RefManager='" + info.refManagrtName + "' and Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0) group by Name,Date";
            return db.ExeReader1(cmd);
          
        }

        public DataTable LoadBazarHistorySpecificDate(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date,Name,sum(Price) as Total_Price FROM vmmBazarChart where RefManager='" + info.refManagrtName + "'and Date BETWEEN'" + info.dateFromMeal + "'AND '" + info.dateToMeal + "' group by Name,Date";
            return db.ExeReader1(cmd);
        }

        public int MemberToManager(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update vmmUser1 set userType='Manager',UserName='"+info.newAdminName+"' where Id="+info.newAdminId+"";
            return db.ExeNonQuery(cmd);
        }

        public int ManagerToMember(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update vmmUser1 set userType='Member' where UserName='" + info.logInUserName + "'  and Password='" + info.logInPassword+"'";
            return db.ExeNonQuery(cmd);
          
        }

        public int ChangeRerManagerName(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update vmmUser1 set RefManagerName='"+info.newAdminUsername+"' where RefManagerName='"+info.logInUserName+"'";
            return db.ExeNonQuery(cmd);
           
        }

        public DataTable LoadMealHistoryCalculation(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Name,sum(TotalMeal) as Total_Meal FROM vmmMealChart where refManager='" + info.refManagrtName + "'and Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0) group by Name";
            return db.ExeReader1(cmd);
        }
    }
}
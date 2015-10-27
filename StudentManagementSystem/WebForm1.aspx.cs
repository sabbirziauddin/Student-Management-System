using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            SMSentities dbcontext = new SMSentities();
            studinfo stdobj = new studinfo();
            stdobj.Id = int.Parse(IdTextBox.Text);
            stdobj.stuname = NameTextBox.Text;
            stdobj.fathername = FatherTextBox.Text;
            stdobj.mothername = MotherTextBox.Text;
            stdobj.address = AddressTextBox.Text;
            stdobj.contactNo = int.Parse(contTextBox.Text);
            stdobj.email = emailTextBox.Text;
            stdobj.DepartMent = deptTextBox.Text;
            dbcontext.studinfoes.Add(stdobj);
            dbcontext.SaveChanges();
            msgLabel.Text = "added successfully";
            //SMSentities dbcontext=new SMSentities();
            //studinfo obj =new studinfo();
            //obj.Id = int.Parse(IdTextBox.Text);
            //obj.stuname = NameTextBox.Text;
            //obj.fathername = FatherTextBox.Text;
            //obj.mothername = MotherTextBox.Text;
            //obj.address = AddressTextBox.Text;
            //obj.contactNo = int.Parse(contTextBox.Text);
            //obj.email = emailTextBox.Text;
            //obj.DepartMent = deptTextBox.Text;
            //dbcontext.studinfoes.Add(obj);
            //dbcontext.SaveChanges();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SMSentities dbcontex=new SMSentities();
            var studinfor = from dd in dbcontex.studinfoes select dd;
            //var stumarks=from xx in dbcontex.studinfoes
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("stuname");
            dt.Columns.Add("fathername");
            dt.Columns.Add("mothername");
            dt.Columns.Add("address");
            dt.Columns.Add("contactno");
            dt.Columns.Add("email");
            dt.Columns.Add("department");
            foreach (var studd in studinfor)
            {
                DataRow r = dt.NewRow();
                r[0] = studd.Id;
                r[1] = studd.stuname;
                r[2] = studd.fathername;
                r[3] = studd.mothername;
                r[4] = studd.address;
                r[5] = studd.contactNo;
                r[6] = studd.email;
                r[7] = studd.DepartMent;
                dt.Rows.Add(r);

               



            }
            showGridView.DataSource = dt;
            showGridView.DataBind();

        }

        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {
           

        }

        protected void searchbydeptButton_Click(object sender, EventArgs e)
        {
            string dept = searchTextBox.Text;
            SMSentities dbcontex = new SMSentities();
            var studinfor = from xx in dbcontex.studinfoes where xx.DepartMent == dept select xx;
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("stuname");
            dt.Columns.Add("fathername");
            dt.Columns.Add("mothername");
            dt.Columns.Add("address");
            dt.Columns.Add("contactno");
            dt.Columns.Add("email");
            dt.Columns.Add("department");
            foreach (var studentin in studinfor)
            {
                DataRow r = dt.NewRow();
                r[0] = studentin.Id;
                r[1] = studentin.stuname;
                r[2] = studentin.fathername;
                r[3] = studentin.mothername;
                r[4] = studentin.address;
                r[5] = studentin.contactNo;
                r[6] = studentin.email;
                r[7] = studentin.DepartMent;
                dt.Rows.Add(r);
            }
            showGridView.DataSource = dt;
            showGridView.DataBind();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SMSentities dbcontex=new SMSentities();
            StudentManagementSystem.studinfo objStudinfo=new studinfo();
            //try
            {
                int id1 = int.Parse(IdTextBox.Text);
                objStudinfo = dbcontex.studinfoes.FirstOrDefault(xx => xx.Id==id1);
                objStudinfo.DepartMent = deptTextBox.Text;
                objStudinfo.address = AddressTextBox.Text;
                dbcontex.SaveChanges();
                msgLabel.Text = "update successfully";
            }
            //catch (Exception e1)
            {
                msgLabel.Text = "not found id";
                //throw;
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            SMSentities dbcontext=new SMSentities();
            int id1 = int.Parse(IdTextBox.Text);
            var studobj = from xx in dbcontext.studinfoes where xx.Id == id1 select xx;
            bool flag = false;
            foreach (var stdin in studobj)
            {
                NameTextBox.Text = stdin.stuname;
                FatherTextBox.Text = stdin.fathername;
                MotherTextBox.Text = stdin.mothername;
                AddressTextBox.Text = stdin.address;
                contTextBox.Text = stdin.contactNo.ToString();
                emailTextBox.Text = stdin.email;
                deptTextBox.Text = stdin.DepartMent;
                flag = true;


            }
            if (flag == false)
            {
                msgLabel.Text = "not found";

            }
            else
            {
                msgLabel.Text = "found";
            }

        }

        protected void delateButton_Click(object sender, EventArgs e)
        {
            SMSentities dbcontext=new SMSentities();
            StudentManagementSystem.studinfo sobject = new studinfo();
           // try
            {
                int id1 = int.Parse(IdTextBox.Text);
                var sobj = dbcontext.studinfoes.FirstOrDefault(xx => xx.Id == id1);
                dbcontext.studinfoes.Remove(sobj);
                dbcontext.SaveChanges();
                msgLabel.Text = "successfully delated";

            }
           // catch (Exception e1)
            {

                msgLabel.Text = "not found";
            }
          

            {
                
            }



        }

        protected void showResultButton_Click(object sender, EventArgs e)
        {
            SMSentities dbcontext=new SMSentities();
            var stumarks = from xx in dbcontext.stdmarksDetails select xx;
            DataTable dt=new DataTable();
            dt.Columns.Add("idnumber");
            dt.Columns.Add("name");
            dt.Columns.Add("deppartment");
            dt.Columns.Add("email");
            dt.Columns.Add("grade");
            dt.Columns.Add("cgpa");
            dt.Columns.Add("courses");
            dt.Columns.Add("semester");
            foreach (var stdma in stumarks)
            {
                DataRow dr = dt.NewRow();
                dr[0] = stdma.idNumber;
                dr[1] = stdma.name;
                dr[2] = stdma.DeppartMent;
                dr[3] = stdma.Email;
                dr[4] = stdma.grade;
                dr[5] = stdma.cgpa;
                dr[6] = stdma.courses;
                dr[7] = stdma.semester;
                dt.Rows.Add(dr);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
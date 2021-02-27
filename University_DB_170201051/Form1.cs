using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_DB_170201051
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'universityDB_DataSet.Rooms' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.roomsTableAdapter.Fill(this.universityDB_DataSet.Rooms);
            // TODO: Bu kod satırı 'universityDB_DataSet.Faculty' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.facultyTableAdapter.Fill(this.universityDB_DataSet.Faculty);
            // TODO: Bu kod satırı 'universityDB_DataSet.Courses' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
            // TODO: Bu kod satırı 'universityDB_DataSet.Department' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.departmentTableAdapter.Fill(this.universityDB_DataSet.Department);
            // TODO: Bu kod satırı 'universityDB_DataSet.Grade' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
            // TODO: Bu kod satırı 'universityDB_DataSet.EnrollStudentCourse' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
            // TODO: Bu kod satırı 'universityDB_DataSet.Instructor' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
            // TODO: Bu kod satırı 'universityDB_DataSet.Student' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.studentTableAdapter.Fill(this.universityDB_DataSet.Student);
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.InsertQuery(Convert.ToInt32(textBox10.Text), textBox11.Text);
            this.roomsTableAdapter.Fill(this.universityDB_DataSet.Rooms);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.UpdateQuery(Convert.ToInt32(textBox10.Text), textBox11.Text, Convert.ToInt32(textBox12.Text));
            this.roomsTableAdapter.Fill(this.universityDB_DataSet.Rooms);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.DeleteQuery(Convert.ToInt32(textBox12.Text));
            this.roomsTableAdapter.Fill(this.universityDB_DataSet.Rooms);
            //Update Course Deleted Room
            this.coursesTableAdapter.UpdateCourse_DeleteRoom(Convert.ToInt32(textBox12.Text));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
            //Update Instructor Deleted Room
            this.instructorTableAdapter.UpdateInstructor_DeleteRoom(Convert.ToInt32(textBox12.Text));
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox10.Text = this.roomsTableAdapter.SearchRoomNo(Convert.ToInt32(textBox12.Text)).ToString();
            textBox11.Text = this.roomsTableAdapter.SearchRoomPlace(Convert.ToInt32(textBox12.Text));
            this.roomsTableAdapter.Fill(this.universityDB_DataSet.Rooms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.InsertQuery(textBox1.Text,Convert.ToInt32(comboBox1.SelectedValue), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
            this.facultyTableAdapter.Fill(this.universityDB_DataSet.Faculty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = this.facultyTableAdapter.SearchFacultyName(Convert.ToInt32(textBox9.Text));
            comboBox1.SelectedValue = this.facultyTableAdapter.SearchFacIns(Convert.ToInt32(textBox9.Text)).ToString();
            comboBox2.SelectedValue = this.facultyTableAdapter.SearchFacDeanName(Convert.ToInt32(textBox9.Text));
            comboBox3.SelectedValue = this.facultyTableAdapter.SearchFacDeanLastName(Convert.ToInt32(textBox9.Text));

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.UpdateQuery(textBox1.Text, Convert.ToInt32(comboBox1.SelectedValue), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), Convert.ToInt32(textBox9.Text));
            this.facultyTableAdapter.Fill(this.universityDB_DataSet.Faculty);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.DeleteQuery(Convert.ToInt32(textBox9.Text));
            this.facultyTableAdapter.Fill(this.universityDB_DataSet.Faculty);
            //Update Department Deleted Faculty
            this.departmentTableAdapter.UpdateDepartment_DeleteFaculty(Convert.ToInt32(textBox9.Text));
            this.departmentTableAdapter.Fill(this.universityDB_DataSet.Department);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.InsertQuery(textBox2.Text, textBox3.Text, checkedListBox1.SelectedItem.ToString(), maskedTextBox4.Text, maskedTextBox1.Text, textBox6.Text, Convert.ToInt32(comboBox11.SelectedValue), Convert.ToInt32(comboBox12.SelectedValue));
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.DeleteQuery(Convert.ToInt32(textBox4.Text));
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
            //Update Course Deleted Instructor
            this.coursesTableAdapter.UpdateCourse_DeleteInstructor(Convert.ToInt32(textBox4.Text));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
            //Update Faculty Dean Deleted Instructor
            this.facultyTableAdapter.UpdateFaculty_DeleteInstructor(Convert.ToInt32(textBox4.Text));
            this.facultyTableAdapter.Fill(this.universityDB_DataSet.Faculty);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.UpdateQuery(textBox2.Text, textBox3.Text, checkedListBox1.SelectedItem.ToString(), maskedTextBox4.Text, maskedTextBox1.Text, textBox6.Text, Convert.ToInt32(comboBox11.SelectedValue), Convert.ToInt32(comboBox12.SelectedValue), Convert.ToInt32(textBox4.Text));
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = this.instructorTableAdapter.SearchInsName(Convert.ToInt32(textBox4.Text));
            textBox3.Text = this.instructorTableAdapter.SearchInsLastName(Convert.ToInt32(textBox4.Text));
            checkedListBox1.SelectedItem = this.instructorTableAdapter.SearchInsGender(Convert.ToInt32(textBox4.Text));
            maskedTextBox4.Text = this.instructorTableAdapter.SearchInsPhone(Convert.ToInt32(textBox4.Text));
            maskedTextBox1.Text = this.instructorTableAdapter.SearchInsDOB(Convert.ToInt32(textBox4.Text)).ToString();
            textBox6.Text = this.instructorTableAdapter.SearchInsTitle(Convert.ToInt32(textBox4.Text));
            comboBox11.SelectedValue = this.instructorTableAdapter.SearchInsDept(Convert.ToInt32(textBox4.Text)).ToString();
            comboBox12.SelectedValue = this.instructorTableAdapter.SearchInsRoom(Convert.ToInt32(textBox4.Text)).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.InsertQuery(textBox13.Text,Convert.ToInt32(comboBox4.SelectedValue));
            this.departmentTableAdapter.Fill(this.universityDB_DataSet.Department);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.DeleteQuery(Convert.ToInt32(comboBox5.SelectedValue));
            this.departmentTableAdapter.Fill(this.universityDB_DataSet.Department);
            //Update Student Deleted Department 
            this.studentTableAdapter.UpdateStudent_DeleteDepartment(Convert.ToInt32(comboBox5.SelectedValue));
            this.studentTableAdapter.Fill(this.universityDB_DataSet.Student);
            //Update Course Deleted Department
            this.coursesTableAdapter.UpdateCourse_DeleteDepartment(Convert.ToInt32(comboBox5.SelectedValue));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
            //Update Instructor Deleted Department
            this.instructorTableAdapter.UpdateInstructor_DeleteDepartment(Convert.ToInt32(comboBox5.SelectedValue));
            this.instructorTableAdapter.Fill(this.universityDB_DataSet.Instructor);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.UpdateQuery(textBox13.Text, Convert.ToInt32(comboBox4.SelectedValue), Convert.ToInt32(comboBox5.SelectedValue));
            this.departmentTableAdapter.Fill(this.universityDB_DataSet.Department);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox13.Text = this.departmentTableAdapter.SearchDeptName(Convert.ToInt32(comboBox5.SelectedValue));
            comboBox4.SelectedValue = this.departmentTableAdapter.SearchDeptFaculty(Convert.ToInt32(comboBox5.SelectedValue)).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.InsertQuery(textBox14.Text,textBox15.Text,Convert.ToInt32(textBox16.Text), Convert.ToInt32(comboBox7.SelectedValue), Convert.ToInt32(comboBox9.SelectedValue), Convert.ToInt32(comboBox6.SelectedValue));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.DeleteQuery(Convert.ToInt32(comboBox8.SelectedValue));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
            //Update EnrollCourse Deleted Course
            this.enrollStudentCourseTableAdapter.UpdateEnrollCourse_DeleteCourse(Convert.ToInt32(comboBox8.SelectedValue));
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
            //Update EnrollGrade Deleted Course
            this.gradeTableAdapter.UpdateEnrollGrade_DeleteCourse(Convert.ToInt32(comboBox8.SelectedValue));
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.UpdateQuery(textBox14.Text, textBox15.Text, Convert.ToInt32(textBox16.Text), Convert.ToInt32(comboBox7.SelectedValue), Convert.ToInt32(comboBox9.SelectedValue), Convert.ToInt32(comboBox6.SelectedValue), Convert.ToInt32(comboBox8.SelectedValue));
            this.coursesTableAdapter.Fill(this.universityDB_DataSet.Courses);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox14.Text = this.coursesTableAdapter.SearchCourseCode(Convert.ToInt32(comboBox8.SelectedValue)).ToString();
            textBox15.Text = this.coursesTableAdapter.SearchCourseName(Convert.ToInt32(comboBox8.SelectedValue));
            textBox16.Text = this.coursesTableAdapter.SearchCourseCredit(Convert.ToInt32(comboBox8.SelectedValue)).ToString();
            comboBox7.SelectedValue = this.coursesTableAdapter.SearchCourseRoom(Convert.ToInt32(comboBox8.SelectedValue));
            comboBox9.SelectedValue = this.coursesTableAdapter.SearchCourseIns(Convert.ToInt32(comboBox8.SelectedValue));
            comboBox6.SelectedValue = this.coursesTableAdapter.SearchCourseDept(Convert.ToInt32(comboBox8.SelectedValue));

        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.InsertQuery(textBox17.Text,textBox18.Text,maskedTextBox2.Text,checkedListBox2.SelectedItem.ToString(),textBox19.Text,textBox20.Text,maskedTextBox3.Text,Convert.ToInt32(comboBox10.SelectedValue));
            this.studentTableAdapter.Fill(this.universityDB_DataSet.Student);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.DeleteQuery(Convert.ToInt32(textBox22.Text));
            this.studentTableAdapter.Fill(this.universityDB_DataSet.Student);
            //Update EnrollCourse Deleted Student
            this.enrollStudentCourseTableAdapter.UpdateEnrollCourse_DeleteStudent(Convert.ToInt32(textBox22.Text));
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
            //Update EnrollGrade Deleted Student
            this.gradeTableAdapter.UpdateEnrollGrade_DeleteStudent(Convert.ToInt32(textBox22.Text));
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.UpdateQuery(textBox17.Text, textBox18.Text, maskedTextBox2.Text, checkedListBox2.SelectedItem.ToString(), textBox19.Text, textBox20.Text, maskedTextBox3.Text, Convert.ToInt32(comboBox10.SelectedValue),Convert.ToInt32(textBox22.Text));
            this.studentTableAdapter.Fill(this.universityDB_DataSet.Student);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox17.Text = this.studentTableAdapter.SearchStudentName(Convert.ToInt32(textBox22.Text));
            textBox18.Text = this.studentTableAdapter.SearchStdLastname(Convert.ToInt32(textBox22.Text));
            maskedTextBox2.Text = this.studentTableAdapter.SearchStdDOB(Convert.ToInt32(textBox22.Text)).ToString();
            checkedListBox2.SelectedItem = this.studentTableAdapter.SearchStdGender(Convert.ToInt32(textBox22.Text));
            textBox19.Text = this.studentTableAdapter.SearchStdMail(Convert.ToInt32(textBox22.Text));
            textBox20.Text = this.studentTableAdapter.SearchStdAddress(Convert.ToInt32(textBox22.Text));
            maskedTextBox3.Text = this.studentTableAdapter.SearchStdPhone(Convert.ToInt32(textBox22.Text));
            comboBox10.SelectedValue = this.studentTableAdapter.SearchStdDept(Convert.ToInt32(textBox22.Text));

        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.InsertQuery(Convert.ToInt32(textBox5.Text),Convert.ToInt32(comboBox13.SelectedValue),textBox7.Text);
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.UpdateQuery(Convert.ToInt32(textBox5.Text), Convert.ToInt32(comboBox13.SelectedValue), textBox7.Text,Convert.ToInt32(textBox8.Text));
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.DeleteQuery(Convert.ToInt32(textBox8.Text));
            this.enrollStudentCourseTableAdapter.Fill(this.universityDB_DataSet.EnrollStudentCourse);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox5.Text = this.enrollStudentCourseTableAdapter.SearchEnrollStudent(Convert.ToInt32(textBox8.Text)).ToString();
            comboBox13.SelectedValue = this.enrollStudentCourseTableAdapter.SearchEnrollCourse(Convert.ToInt32(textBox8.Text));
            textBox7.Text = this.enrollStudentCourseTableAdapter.SearchEnrollTerm(Convert.ToInt32(textBox8.Text));
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.InsertQuery(Convert.ToInt32(textBox21.Text),Convert.ToInt32(comboBox14.SelectedValue),Convert.ToInt32(textBox23.Text),Convert.ToInt32(textBox24.Text),Convert.ToInt32(textBox25.Text));
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.UpdateQuery(Convert.ToInt32(textBox21.Text), Convert.ToInt32(comboBox14.SelectedValue), Convert.ToInt32(textBox23.Text), Convert.ToInt32(textBox24.Text), Convert.ToInt32(textBox25.Text),Convert.ToInt32(textBox26.Text));
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.DeleteQuery(Convert.ToInt32(textBox26.Text));
            this.gradeTableAdapter.Fill(this.universityDB_DataSet.Grade);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox21.Text = this.gradeTableAdapter.SearchGradeStudent(Convert.ToInt32(textBox26.Text)).ToString();
            comboBox14.SelectedValue = this.gradeTableAdapter.SearchGradeCourse(Convert.ToInt32(textBox26.Text));
            textBox23.Text = this.gradeTableAdapter.SearchGradeMidterm(Convert.ToInt32(textBox26.Text)).ToString();
            textBox24.Text = this.gradeTableAdapter.SearchGradeFinal(Convert.ToInt32(textBox26.Text)).ToString();
            textBox25.Text = this.gradeTableAdapter.SearchGradeMakeUp(Convert.ToInt32(textBox26.Text)).ToString();



        }
    }
}
